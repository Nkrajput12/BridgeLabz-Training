
--CREATE NONCLUSTERED INDEX IX_Appointment_Doctor_Date_Status

CREATE NONCLUSTERED INDEX IX_Appointment_Doctor_Date_Status
ON Appointment (DoctorID, AppointmentDate)
INCLUDE (Status);


--verify

SELECT DoctorID, AppointmentDate, Status 
FROM Appointment 
WHERE DoctorID = 1;