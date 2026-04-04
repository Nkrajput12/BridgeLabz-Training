CREATE OR ALTER PROCEDURE sp_RecordVisitWithPrescriptions
    @ApptID INT,
    @Diagnosis VARCHAR(MAX),
    @Notes VARCHAR(MAX),
    @PrescriptionList PrescriptionType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Insert Visit and get the new ID
        DECLARE @VisitID INT;
        INSERT INTO Visits (AppointmentID, Diagnosis, Notes, VisitDate)
        VALUES (@ApptID, @Diagnosis, @Notes, GETDATE());
        SET @VisitID = SCOPE_IDENTITY();

        -- 2. Update Appointment Status (UC-4.1)
        UPDATE Appointments SET Status = 'COMPLETED' WHERE AppointmentID = @ApptID;

        -- 3. Batch Insert Prescriptions (UC-4.3)
        INSERT INTO Prescriptions (VisitID, MedicineName, Dosage, Duration)
        SELECT @VisitID, MedicineName, Dosage, Duration FROM @PrescriptionList;

        COMMIT TRANSACTION;
        SELECT @VisitID AS VisitID; -- Return for the UI/Billing
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;