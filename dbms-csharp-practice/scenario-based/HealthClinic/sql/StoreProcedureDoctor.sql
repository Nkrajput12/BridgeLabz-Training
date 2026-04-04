USE HealthClinicDB;
GO

-- Add Doctor
CREATE OR ALTER PROCEDURE sp_AddDoctor
    @FullName VARCHAR(100),
    @SpecialtyID VARCHAR(100),
    @Fee DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Doctors (FullName, SpecialtyID, ConsultationFee)
    VALUES (@FullName, @SpecialtyID, @Fee);
END;
GO

--Update Specialty
CREATE OR ALTER PROCEDURE	sp_UpdateSpecialty
 @UpdateID INT,
 @DoctorID INT
 AS
 BEGIN
	IF NOT EXISTS(SELECT 1 FROM Doctors WHERE DoctorID = @DoctorID)
	BEGIN
		;THROW 50001, 'INVALID DOCTOR ID: DOCTOR DOES NOT EXIST.',1;
	END
	IF NOT EXISTS(SELECT 1 FROM Specialties WHERE SpecialtyID = @UpdateID)
	BEGIN
		;THROW 50002, 'INVALID SPECIALTY ID: SPECIALTIY DOES NOT EXIST.',1;
	END

	UPDATE Doctors SET SpecialtyID = @UpdateID where DoctorID = @DoctorID;
END;
GO


-- Book Appointment with Availability Check
CREATE OR ALTER PROCEDURE sp_BookAppointment
    @PatientID INT,
    @DoctorID INT,
    @ApptDate DATE,
    @ApptTime TIME
AS
BEGIN
    -- Check if doctor is already booked at this time
    IF EXISTS (SELECT 1 FROM Appointments WHERE DoctorID = @DoctorID AND ApptDate = @ApptDate AND ApptTime = @ApptTime)
    BEGIN
        RAISERROR('Doctor is unavailable at this time.', 16, 1);
    END
    ELSE
    BEGIN
        INSERT INTO Appointments (PatientID, DoctorID, ApptDate, ApptTime, Status)
        VALUES (@PatientID, @DoctorID, @ApptDate, @ApptTime, 'SCHEDULED');
    END
END;
GO

-- Cancel Appointment
CREATE OR ALTER PROCEDURE sp_CancelAppointment
    @ApptID INT
AS
BEGIN
    UPDATE Appointments SET Status = 'CANCELLED' WHERE AppointmentID = @ApptID;
END;
GO

--view doctor by specialty
CREATE OR ALTER PROCEDURE sp_ViewDoctorBySpecialty
	@SpecialtyID INT
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Doctors WHERE  SpecialtyID = @SpecialtyID)
	BEGIN
		;THROW 50002,'INVALID SPECIALTY ID: NO DOCTOR EXIST WITH THIS SPECIALTY.',1;
	END

	SELECT d.FullName, s.SpecialtyName
	From Doctors d 
	INNER JOIN Specialties s ON s.SpecialtyID = d.SpecialtyID 
	where d.SpecialtyID = @SpecialtyID;
END;
GO

--Show ALL DOCTORS
CREATE OR ALTER PROCEDURE sp_ShowAllDoctor
AS
BEGIN
	SELECT * FROM Doctors;
END
GO

-- check doctor availability
CREATE OR ALTER PROCEDURE sp_CheckDoctorAvailability
    @DoctorID INT,
    @ApptDate DATE
AS
BEGIN
    
    DECLARE @MaxCapacity INT = 1;

    SELECT 
        ApptTime, 
        COUNT(*) AS BookedSlots,
        @MaxCapacity AS MaxCapacity,
        CASE 
            WHEN COUNT(*) >= @MaxCapacity THEN 'FULL'
            ELSE 'AVAILABLE'
        END AS SlotStatus
    FROM Appointments
    WHERE DoctorID = @DoctorID 
      AND ApptDate = @ApptDate
      AND Status != 'CANCELLED'
    GROUP BY ApptTime
    ORDER BY ApptTime;
END;
GO

--Delete Doctor
CREATE OR ALTER PROCEDURE sp_DeactivateDoctor
    @DoctorID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Check if the doctor exists
    IF NOT EXISTS (SELECT 1 FROM Doctors WHERE DoctorID = @DoctorID)
    BEGIN
        ;THROW 50001, 'Doctor ID does not exist.', 1;
    END

    -- 2. Check for future appointments using nested SELECT
    -- We look for any appointment from "Today" onwards that isn't cancelled
    IF EXISTS (
        SELECT 1 FROM Appointments 
        WHERE DoctorID = @DoctorID 
        AND ApptDate >= CAST(GETDATE() AS DATE)
        AND Status != 'CANCELLED'
    )
    BEGIN
        ;THROW 50007, 'Cannot deactivate: Doctor has pending future appointments.', 1;
    END
   
    UPDATE Doctors 
    SET IsActive = 0 
    WHERE DoctorID = @DoctorID;
END;
GO

--patient medical history
CREATE OR ALTER PROCEDURE sp_GetPatientMedicalHistory
    @PatientID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        V.VisitDate,
        D.FullName AS DoctorName,
        V.Diagnosis,
        V.Notes,
        A.ApptDate,
        A.Status
    FROM Visits V
    INNER JOIN Appointments A ON V.AppointmentID = A.AppointmentID
    INNER JOIN Doctors D ON A.DoctorID = D.DoctorID
    WHERE A.PatientID = @PatientID
    ORDER BY V.VisitDate DESC;
END;
GO

