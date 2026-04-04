--Create the Database
CREATE DATABASE HealthClinicDB;
GO
USE HealthClinicDB;
GO

-- Create Parent Tables (No dependencies)
CREATE TABLE Specialties (
    SpecialtyID INT PRIMARY KEY IDENTITY(1,1),
    SpecialtyName VARCHAR(100) NOT NULL
);
 -- Patients Table
CREATE TABLE Patients (
    PatientID INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100) NOT NULL,
    DOB DATE,
    Phone VARCHAR(15) UNIQUE,
    Email VARCHAR(100),
    BloodGroup VARCHAR(5)
);

-- Create Child Tables (Linked to Parents)
CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100) NOT NULL,
    SpecialtyID INT FOREIGN KEY REFERENCES Specialties(SpecialtyID),
    ConsultationFee DECIMAL(10,2),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),
    PatientID INT FOREIGN KEY REFERENCES Patients(PatientID),
    DoctorID INT FOREIGN KEY REFERENCES Doctors(DoctorID),
    ApptDate DATE,
    ApptTime TIME,
    Status VARCHAR(20) DEFAULT 'SCHEDULED'
);

CREATE TABLE Visits (
    VisitID INT PRIMARY KEY IDENTITY(1,1),
    AppointmentID INT FOREIGN KEY REFERENCES Appointments(AppointmentID),
    Diagnosis TEXT,
    Notes TEXT,
    VisitDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Bills (
    BillID INT PRIMARY KEY IDENTITY(1,1),
    VisitID INT FOREIGN KEY REFERENCES Visits(VisitID),
    TotalAmount DECIMAL(10,2),
    PaymentStatus VARCHAR(20) DEFAULT 'UNPAID',
    PaymentDate DATETIME,
    PaymentMode VARCHAR(50)
);

CREATE TABLE appointment_audit (
    AuditID INT PRIMARY KEY IDENTITY(1,1),
    AppointmentID INT,
    OldStatus VARCHAR(20),
    NewStatus VARCHAR(20),
    ChangeDate DATETIME DEFAULT GETDATE(),
    ChangedBy NVARCHAR(50)
);