
--Store Procedure for patients


--Register patient
CREATE PROCEDURE sp_RegisterPatient
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DateOfBirth DATE,
    @Gender VARCHAR(10),
    @Address VARCHAR(255),
    @PhoneNumber VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

    --Insert core patient details
    INSERT INTO Patient (FirstName, LastName, DateOfBirth, Gender, Address)
    VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Address);

    --Get the auto-generated PatientID
    DECLARE @NewPatientID INT = SCOPE_IDENTITY();

    --Insert phone number if provided
    IF @PhoneNumber IS NOT NULL 
    BEGIN
        INSERT INTO PatientPhone (PatientID, PhoneNumber)
        VALUES (@NewPatientID, @PhoneNumber);
    END
END;
Go

--Delete Patient
CREATE PROCEDURE sp_DeletePatient
    @PatientID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Patient
    WHERE PatientID = @PatientID;
END;
Go

--Update patients


CREATE PROCEDURE sp_UpdatePatient
    @PatientID INT,
    @FirstName VARCHAR(50) = NULL,
    @LastName VARCHAR(50) = NULL,
    @DateOfBirth DATE = NULL,
    @Gender VARCHAR(10) = NULL,
    @Address VARCHAR(255) = NULL,
    @PhoneNumber VARCHAR(15) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Update only columns where a non-NULL parameter was passed
    UPDATE Patient
    SET FirstName   = ISNULL(@FirstName, FirstName),
        LastName    = ISNULL(@LastName, LastName),
        DateOfBirth = ISNULL(@DateOfBirth, DateOfBirth),
        Gender      = ISNULL(@Gender, Gender),
        Address     = ISNULL(@Address, Address)
    WHERE PatientID = @PatientID;

    -- Update phone number ONLY if a new value is explicitly provided
    IF @PhoneNumber IS NOT NULL AND @PhoneNumber <> ''
    BEGIN
        DELETE FROM PatientPhone WHERE PatientID = @PatientID;

        INSERT INTO PatientPhone (PatientID, PhoneNumber)
        VALUES (@PatientID, @PhoneNumber);
    END
END;
