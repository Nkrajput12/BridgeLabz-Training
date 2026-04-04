

CREATE TABLE appointment_audit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentID INT,
    OldStatus VARCHAR(50),
    NewStatus VARCHAR(50),
    ChangedAt DATETIME DEFAULT GETDATE(),
    ChangedBy NVARCHAR(100) DEFAULT USER_NAME()
);

CREATE TABLE Prescriptions (
    PrescriptionID INT PRIMARY KEY IDENTITY(1,1),
    VisitID INT NOT NULL,
    MedicineName VARCHAR(200),
    Dosage VARCHAR(100),
    Duration VARCHAR(100),
    FOREIGN KEY (VisitID) REFERENCES Visits(VisitID)
);

USE HealthClinicDB;
GO
CREATE TABLE payment_transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    BillID INT FOREIGN KEY REFERENCES Bills(BillID),
    AmountPaid DECIMAL(10,2),
    TransactionDate DATETIME DEFAULT GETDATE(),
    PaymentMode VARCHAR(50)
);

CREATE TYPE PrescriptionType AS TABLE (
    MedicineName VARCHAR(200),
    Dosage VARCHAR(100),
    Duration VARCHAR(100)
);