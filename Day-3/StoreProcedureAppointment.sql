--Store Procedure for Appointment
use HealthClinic;
Go
--Book Appointment
CREATE PROCEDURE sp_BookAppointment
    @PatientID INT,
    @DoctorID INT,
    @AppointmentDate DATE,
    @TimeSlot TIME,
    @Status VARCHAR(20) = 'Scheduled'
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Insert into Appointment table
    INSERT INTO Appointment (PatientID, DoctorID, AppointmentDate, TimeSlot, Status)
    VALUES (@PatientID, @DoctorID, @AppointmentDate, @TimeSlot, @Status);

    -- 2. Get the generated AppointmentID
    DECLARE @NewAppointmentID INT = SCOPE_IDENTITY();

    -- 3. Fetch Doctor's Consultation Fee
    DECLARE @Fee DECIMAL(10,2);
    SELECT @Fee = ConsultationFee FROM Doctor WHERE DoctorID = @DoctorID;

    -- 4. Auto-generate the Billing record
    INSERT INTO Billing (AppointmentID, Amount, PaymentStatus)
    VALUES (@NewAppointmentID, ISNULL(@Fee, 0.00), 'Pending');
END;
Go


--Update Appointment
CREATE PROCEDURE sp_UpdateAppointment
    @AppointmentID INT,
    @PatientID INT = NULL,
    @DoctorID INT = NULL,
    @AppointmentDate DATE = NULL,
    @TimeSlot TIME = NULL,
    @Status VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Appointment
    SET PatientID       = ISNULL(@PatientID, PatientID),
        DoctorID        = ISNULL(@DoctorID, DoctorID),
        AppointmentDate = ISNULL(@AppointmentDate, AppointmentDate),
        TimeSlot        = ISNULL(@TimeSlot, TimeSlot),
        Status          = ISNULL(@Status, Status)
    WHERE AppointmentID = @AppointmentID;
END;
Go

--Cancel Appointment 
CREATE PROCEDURE sp_CancelAppointment
    @AppointmentID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Appointment
    SET Status = 'Cancelled'
    WHERE AppointmentID = @AppointmentID;

    -- Mark corresponding bill as Cancelled
    UPDATE Billing
    SET PaymentStatus = 'Cancelled'
    WHERE AppointmentID = @AppointmentID;
END;