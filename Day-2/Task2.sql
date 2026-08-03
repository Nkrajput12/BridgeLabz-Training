use HealthClinic;
Go

-- Query searching (No index)
SELECT * FROM Appointment WHERE Status = 'Scheduled';



-- Create single-column index on PatientID
CREATE INDEX IX_Appointment_PatientID ON Appointment(PatientID);

		-- Query using single-column index
SELECT * FROM Appointment WHERE PatientID = 5;



-- Create composite index on (DoctorID, AppointmentDate)
CREATE INDEX IX_Appointment_DoctorDate ON Appointment(DoctorID, AppointmentDate);

		-- Query using both columns in index order
SELECT * FROM Appointment 
WHERE DoctorID = 2 AND AppointmentDate = '2026-03-01';