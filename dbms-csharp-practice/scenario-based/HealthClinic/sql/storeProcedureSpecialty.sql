USE HealthClinicDB;
GO

-- Store Procedure for Add Specility
CREATE OR ALTER PROCEDURE sp_AddSpecialty
@SpecialtyName VARCHAR(50)
AS
BEGIN
 INSERT INTO Specialties(SpecialtyName) 
 VALUES (@SpecialtyName);
 SELECT SCOPE_IDENTITY() AS SpecialtyID;
END;
GO

--Search specility Id by Name

CREATE OR ALTER PROCEDURE sp_GetSpecialtyIdByName
@specialtyName NVARCHAR(100)   
AS
BEGIN

	IF NOT EXISTS(SELECT 1 FROM Specialties WHERE SpecialtyName = @specialtyName)
	BEGIN
		;THROW 50002, 'INVALID SPECIALTY ID: THIS SPECIALTY DOES NOT EXIST.',1;
	END

    
    SELECT SpecialtyID 
    FROM specialties 
    WHERE LOWER(SpecialtyName) = LOWER(@specialtyName);
END;
GO
 
 --Display all available Specialty
 CREATE OR ALTER PROCEDURE sp_DisplaySpecialty
 AS
 BEGIN
  SELECT * FROM Specialties;
END;
GO

