CREATE TABLE audit_log (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    TableName VARCHAR(50),
    ActionType VARCHAR(10), -- INSERT, UPDATE, DELETE
    ActionTimestamp DATETIME DEFAULT GETDATE(),
    RecordID INT
);
GO

-- Example Trigger for the Patients table
CREATE TRIGGER trg_PatientAudit
ON Patients
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
        INSERT INTO audit_log (TableName, ActionType, RecordID) SELECT 'Patients', 'UPDATE', PatientID FROM inserted;
    ELSE IF EXISTS(SELECT * FROM inserted)
        INSERT INTO audit_log (TableName, ActionType, RecordID) SELECT 'Patients', 'INSERT', PatientID FROM inserted;
    ELSE
        INSERT INTO audit_log (TableName, ActionType, RecordID) SELECT 'Patients', 'DELETE', PatientID FROM deleted;
END;