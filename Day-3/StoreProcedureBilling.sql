--Store Procedure for Billing

--Get billing
CREATE PROCEDURE sp_GetBillingByPatientID
    @PatientID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.BillID,
        CONCAT(p.FirstName, ' ', p.LastName) AS PatientName,
        b.Amount,
        b.PaymentStatus,
        b.PaymentDate
    FROM Billing b
    INNER JOIN Appointment a ON b.AppointmentID = a.AppointmentID
    INNER JOIN Patient p ON a.PatientID = p.PatientID
    WHERE p.PatientID = @PatientID
    ORDER BY b.BillID DESC;
END;
GO

--Update statys
CREATE PROCEDURE sp_UpdatePaymentStatus
    @BillID INT,
    @PaymentStatus VARCHAR(20) = 'Paid'
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Billing
    SET PaymentStatus = @PaymentStatus,
        PaymentDate = CASE 
            WHEN @PaymentStatus = 'Paid' THEN GETDATE() 
            ELSE NULL 
        END
    WHERE BillID = @BillID;
END;
GO