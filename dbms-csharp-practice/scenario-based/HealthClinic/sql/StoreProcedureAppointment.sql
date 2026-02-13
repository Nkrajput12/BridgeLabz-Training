USE HealthClinicDB;
GO

--BOOK APPOINTMENT

CREATE OR ALTER PROCEDURE sp_BookAppointment
@PatientID int,
@DoctorID int,
@ApptDate DATE,
@ApptTime TIME
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Appointments 
               WHERE DoctorID = @DoctorID 
               AND ApptDate = @ApptDate 
               AND ApptTime = @ApptTime
               AND Status != 'CANCELLED')
    BEGIN
        ;THROW 50003, 'The doctor is already booked for this time slot.', 1;
    END

	INSERT INTO Appointments (PatientID, DoctorID, ApptDate, ApptTime, Status)
    VALUES (@PatientID, @DoctorID, @ApptDate, @ApptTime, 'SCHEDULED');
END;
GO

--Cancel Appointment
CREATE OR ALTER PROCEDURE sp_CancelAppointment
    @AppointmentID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Appointments WHERE AppointmentID = @AppointmentID)
    BEGIN
        ;THROW 50006, 'Appointment ID does not exist.', 1;
    END

    UPDATE Appointments 
    SET Status = 'CANCELLED' 
    WHERE AppointmentID = @AppointmentID;
END;
GO

--Show all Appointment
CREATE OR ALTER PROCEDURE sp_ShowAllAppointment
As
BEGIN
 SELECT * FROM Appointments;
END;
GO


-- Reschedule Appointment
CREATE OR ALTER PROCEDURE sp_RescheduleAppointment
    @AppointmentID INT,
    @NewDate DATE,
    @NewTime TIME,
    @NewDoctorID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if ID exists
        IF NOT EXISTS (SELECT 1 FROM Appointments WHERE AppointmentID = @AppointmentID)
        BEGIN
            ;THROW 50006, 'Appointment ID does not exist.', 1;
        END

        -- Check for conflicts (excluding the current appointment itself)
        IF EXISTS (SELECT 1 FROM Appointments 
                   WHERE DoctorID = @NewDoctorID 
                   AND ApptDate = @NewDate 
                   AND ApptTime = @NewTime
                   AND AppointmentID <> @AppointmentID
                   AND Status != 'CANCELLED')
        BEGIN
            ;THROW 50003, 'The doctor is already booked for this new time slot.', 1;
        END

        UPDATE Appointments
        SET ApptDate = @NewDate,
            ApptTime = @NewTime,
            DoctorID = @NewDoctorID,
            Status = 'SCHEDULED'
        WHERE AppointmentID = @AppointmentID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

Select * from Appointments;