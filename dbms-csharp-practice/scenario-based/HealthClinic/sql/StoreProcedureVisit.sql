USE HealthClinicDB;
GO
--Record Patient Visit	
CREATE OR ALTER PROCEDURE sp_RecordPatientVisit
    @AppointmentID INT,
    @Diagnosis VARCHAR(MAX),
    @Notes VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Verify the appointment exists 
        IF NOT EXISTS (SELECT 1 FROM Appointments WHERE AppointmentID = @AppointmentID AND Status = 'SCHEDULED')
        BEGIN
            ;THROW 50006, 'Appointment not found or already processed.', 1;
        END

        -- 2. Insert into Visits 
        INSERT INTO Visits (AppointmentID, Diagnosis, Notes, VisitDate)
        VALUES (@AppointmentID, @Diagnosis, @Notes, GETDATE());

        -- 3. Update Appointment Status
        UPDATE Appointments 
        SET Status = 'COMPLETED' 
        WHERE AppointmentID = @AppointmentID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;


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
        A.Status,
        P.MedicineName,
        P.Dosage,
        P.Duration
    FROM Visits V
    INNER JOIN Appointments A ON V.AppointmentID = A.AppointmentID
    INNER JOIN Doctors D ON A.DoctorID = D.DoctorID
    LEFT JOIN Prescriptions P ON V.VisitID = P.VisitID  -- Join Prescriptions via VisitID
    WHERE A.PatientID = @PatientID
    ORDER BY V.VisitDate DESC;
END;
GO