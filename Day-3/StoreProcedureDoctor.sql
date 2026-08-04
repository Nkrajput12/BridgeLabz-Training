--Store Procedure for Doctor

--Register Doctor
CREATE PROCEDURE sp_RegisterDoctor
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Specialization VARCHAR(100),
    @Phone VARCHAR(15),
    @ConsultationFee DECIMAL(10,2) = 500.00,
    @RoomID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Doctor (FirstName, LastName, Specialization, Phone, ConsultationFee, RoomID)
    VALUES (@FirstName, @LastName, @Specialization, @Phone, @ConsultationFee, @RoomID);
END;
Go

--Update Doctor
CREATE PROCEDURE sp_UpdateDoctor
    @DoctorID INT,
    @FirstName VARCHAR(50) = NULL,
    @LastName VARCHAR(50) = NULL,
    @Specialization VARCHAR(100) = NULL,
    @Phone VARCHAR(15) = NULL,
    @ConsultationFee DECIMAL(10,2) = NULL,
    @RoomID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Doctor
    SET FirstName       = ISNULL(@FirstName, FirstName),
        LastName        = ISNULL(@LastName, LastName),
        Specialization  = ISNULL(@Specialization, Specialization),
        Phone           = ISNULL(@Phone, Phone),
        ConsultationFee = ISNULL(@ConsultationFee, ConsultationFee),
        RoomID          = ISNULL(@RoomID, RoomID)
    WHERE DoctorID = @DoctorID;
END;
Go

--Delete Doctor
CREATE PROCEDURE sp_DeleteDoctor
    @DoctorID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Doctor
    WHERE DoctorID = @DoctorID;
END;

