--Triggers on doctor table

--After Insert

CREATE or alter TRIGGER trg_Doctor_Insert
ON Doctor
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Doctor',
        'INSERT',
        i.DoctorID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT('Doctor registered: Dr. ', i.FirstName, ' ', i.LastName, ' (', i.Specialization, ')')
    FROM inserted i;
END;
GO

--after update
CREATE TRIGGER trg_Doctor_Update
ON Doctor
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Doctor',
        'UPDATE',
        i.DoctorID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT(
            'Updated Doctor ID ', i.DoctorID, ': ',
            'Name (', d.FirstName, ' ', d.LastName, ' -> ', i.FirstName, ' ', i.LastName, '), ',
            'Fee (', d.ConsultationFee, ' -> ', i.ConsultationFee, ')'
        )
    FROM inserted i
    INNER JOIN deleted d ON i.DoctorID = d.DoctorID;
END;
GO

--After Delete
CREATE TRIGGER trg_Doctor_Delete
ON Doctor
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Doctor',
        'DELETE',
        d.DoctorID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT('Deleted Doctor: Dr. ', d.FirstName, ' ', d.LastName, ' (ID: ', d.DoctorID, ')')
    FROM deleted d;
END;
GO