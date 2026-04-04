USE HealthClinicDB;
GO
--Register New Patient
CREATE OR ALTER PROCEDURE sp_RegisterPatient
    @FullName VARCHAR(100),
    @DOB DATE,
    @Phone VARCHAR(15),
    @Email VARCHAR(100),
    @BloodGroup VARCHAR(5)
AS
BEGIN
    INSERT INTO Patients (FullName, DOB, Phone, Email, BloodGroup)
    VALUES (@FullName, @DOB, @Phone, @Email, @BloodGroup);
    SELECT SCOPE_IDENTITY() AS PatientID; -- Returns the new ID
END;
GO

--GetPatient by Id OR PHONE
CREATE OR ALTER PROCEDURE sp_GetPatientByIdorPhone
    @SearchTerm VARCHAR(100)
AS
BEGIN
    -- Query patients table for exact match for ID
   -- Flow: Search patient by ID/phone
    SELECT PatientID, FullName, DOB, Phone, Email, BloodGroup
    FROM Patients
    WHERE CAST(PatientID AS VARCHAR) = @SearchTerm 
       OR Phone = @SearchTerm;
END;
GO


--Update Patient
CREATE OR ALTER PROCEDURE sp_UpdatePatient
    @PatientID INT,
	@FullName VARCHAR(100),
	@DOB VARCHAR(10),
    @Phone VARCHAR(15),
    @Email VARCHAR(100),
	@BloodGroup VARCHAR(5)
AS
BEGIN
    UPDATE Patients SET FullName = @FullName, DOB=@DOB, Phone = @Phone, Email = @Email, BloodGroup = @BloodGroup
    WHERE PatientID = @PatientID;;
END;
GO

-- Search Patients
CREATE OR ALTER PROCEDURE sp_SearchPatients
    @Name VARCHAR(100)
AS
BEGIN
    SELECT * FROM Patients WHERE FullName LIKE '%' + @Name + '%';
END;
GO
-- Delete Patients
CREATE OR ALTER PROCEDURE sp_DeletePatient
	@Name VARCHAR(100)
AS
BEGIN
   DELETE FROM dbo.Patients WHERE FullName = @Name;
END;
GO

--SHOW ALL PATIENT
CREATE OR ALTER PROCEDURE sp_ShowAllPatient
AS
BEGIN
	SELECT * FROM Patients;
END;
GO