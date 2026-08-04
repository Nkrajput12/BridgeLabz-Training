--Triggers on patient Table 

--After insert
CREATE TRIGGER trg_Patient_Insert
ON Patient
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Patient',
        'INSERT',
        i.PatientID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT('Patient registered: ', i.FirstName, ' ', i.LastName, ' (DOB: ', i.DateOfBirth, ')')
    FROM inserted i;
END;
GO

--After update
CREATE TRIGGER trg_Patient_Update
ON Patient
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Patient',
        'UPDATE',
        i.PatientID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT(
            'Updated Patient ID ', i.PatientID, ': ',
            'Name (', d.FirstName, ' ', d.LastName, ' -> ', i.FirstName, ' ', i.LastName, '), ',
            'Address (', d.Address, ' -> ', i.Address, ')'
        )
    FROM inserted i
    INNER JOIN deleted d ON i.PatientID = d.PatientID;
END;
GO

--after delete
CREATE TRIGGER trg_Patient_Delete
ON Patient
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Patient',
        'DELETE',
        d.PatientID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT('Deleted Patient: ', d.FirstName, ' ', d.LastName, ' (ID: ', d.PatientID, ')')
    FROM deleted d;
END;
GO