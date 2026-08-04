--Add coloumn of ConsultationFee 
ALTER TABLE Doctor
ADD ConsultationFee DECIMAL(10,2) NOT NULL DEFAULT 500.00;

--Add table for billing

CREATE TABLE Billing (
    BillID INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentID INT NOT NULL UNIQUE,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentStatus VARCHAR(20) DEFAULT 'Pending',
    PaymentDate DATETIME NULL,

    CONSTRAINT FK_Billing_Appointment FOREIGN KEY (AppointmentID)
        REFERENCES Appointment(AppointmentID)
        ON DELETE CASCADE
);