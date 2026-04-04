USE HealthClinicDB;
GO

--GENERATE BILL
CREATE OR ALTER PROCEDURE sp_GenerateBill
    @VisitID INT,
    @AdditionalCharges DECIMAL(10,2),
    @PaymentMode VARCHAR(50),
	@Status VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if Bill already exists for this visit to avoid duplicates
        IF EXISTS (SELECT 1 FROM Bills WHERE VisitID = @VisitID)
        BEGIN
            ;THROW 50008, 'A bill has already been generated for this visit.', 1;
        END

        -- Fetch Consultation Fee
        DECLARE @ConsultFee DECIMAL(10,2);
        SELECT @ConsultFee = d.ConsultationFee 
        FROM Doctors d
        JOIN Appointments a ON d.DoctorID = a.DoctorID
        JOIN Visits v ON a.AppointmentID = v.AppointmentID
        WHERE v.VisitID = @VisitID;

        -- Calculate Total
        DECLARE @Total DECIMAL(10,2) = @ConsultFee + @AdditionalCharges;

        -- Insert into Bills
        INSERT INTO Bills (VisitID, TotalAmount, PaymentStatus, PaymentMode, PaymentDate)
        VALUES (@VisitID, @Total, @Status, @PaymentMode, GETDATE());

        -- Log the Transaction (UC-5.2)
        INSERT INTO payment_transactions (BillID, AmountPaid, TransactionDate, PaymentMode)
        VALUES (SCOPE_IDENTITY(), @Total, GETDATE(), @PaymentMode);

        COMMIT TRANSACTION;

        -- Return the total for cmd.ExecuteScalar()
        SELECT @Total;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

