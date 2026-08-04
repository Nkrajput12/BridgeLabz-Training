
--Creation of Audit log table

CREATE TABLE AuditLog (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    TableName VARCHAR(50) NOT NULL,
    ActionType VARCHAR(20) NOT NULL,
    RecordID INT NOT NULL,
    PerformedBy VARCHAR(100) DEFAULT SYSTEM_USER,
    PerformedAt DATETIME DEFAULT GETDATE(),
    Details VARCHAR(255)
);

