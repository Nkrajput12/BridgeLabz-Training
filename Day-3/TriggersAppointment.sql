--Triggers for Appointments


--After Insert
CREATE TRIGGER trg_Appointment_Insert
ON Appointment
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Appointment',
        'INSERT',
        i.AppointmentID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT('Appointment booked for Patient ID: ', i.PatientID, ' with Doctor ID: ', i.DoctorID, ' on ', i.AppointmentDate, ' at ', i.TimeSlot)
    FROM inserted i;
END;
GO

--After Update
CREATE TRIGGER trg_Appointment_Update
ON Appointment
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Appointment',
        'UPDATE',
        i.AppointmentID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT(
            'Updated Appointment ID ', i.AppointmentID, ': ',
            'Status (', d.Status, ' -> ', i.Status, '), ',
            'Date (', d.AppointmentDate, ' -> ', i.AppointmentDate, '), ',
            'Slot (', d.TimeSlot, ' -> ', i.TimeSlot, ')'
        )
    FROM inserted i
    INNER JOIN deleted d ON i.AppointmentID = d.AppointmentID;
END;
GO

--After Delete
CREATE TRIGGER trg_Appointment_Delete
ON Appointment
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AuditLog (TableName, ActionType, RecordID, PerformedBy, PerformedAt, Details)
    SELECT 
        'Appointment',
        'DELETE',
        d.AppointmentID,
        SYSTEM_USER,
        GETDATE(),
        CONCAT('Deleted Appointment ID: ', d.AppointmentID, ' (Patient ID: ', d.PatientID, ', Doctor ID: ', d.DoctorID, ')')
    FROM deleted d;
END;
GO