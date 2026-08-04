--Get visit history of patient

CREATE PROCEDURE sp_GetPatientAppointmentHistory
    @PatientID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        a.AppointmentID,
        p.PatientID,
        CONCAT(p.FirstName, ' ', p.LastName) AS PatientName,
        CONCAT('Dr. ', d.FirstName, ' ', d.LastName) AS DoctorName,
        d.Specialization,
        a.AppointmentDate,
        a.TimeSlot,
        a.Status
    FROM Appointment a
    INNER JOIN Patient p ON a.PatientID = p.PatientID
    INNER JOIN Doctor d ON a.DoctorID = d.DoctorID
    WHERE a.PatientID = @PatientID
    ORDER BY a.AppointmentDate DESC, a.TimeSlot DESC;
END;
GO