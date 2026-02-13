USE HealthClinicDB;
GO

CREATE OR ALTER TRIGGER trg_AuditAppointmentCancellation
ON Appointments
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Only log if the Status was actually changed to 'CANCELLED'
    IF UPDATE(Status)
    BEGIN
        INSERT INTO appointment_audit (AppointmentID, OldStatus, NewStatus, ChangedBy)
        SELECT 
            i.AppointmentID, 
            d.Status,    -- Status before update
            i.Status,    -- Status after update
            SYSTEM_USER  -- Captures the database user who made the change
        FROM inserted i
        INNER JOIN deleted d ON i.AppointmentID = d.AppointmentID
        WHERE i.Status = 'CANCELLED';
    END
END;
GO