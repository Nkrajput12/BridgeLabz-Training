USE StudentManagement;
GO



--------------DML QUERY
--INSERT
INSERT INTO Students (FirstName, LastName, Email) 
VALUES ('Nk', 'Raj', 'Raj@gmail.com');

INSERT INTO Courses (CourseName, Credits) 
VALUES ('Database Systems', 4);

--UPDATE
UPDATE Enrollments 
SET Grade = 'A' 
WHERE StudentID = 1 AND CourseID = 1;

 --DELETE
 DELETE FROM Enrollments WHERE EnrollmentID = 5;

 ---------------DQL QUERY

 SELECT * FROM Students;

 SELECT Students.FirstName, Courses.CourseName, Enrollments.Grade
FROM Students
JOIN Enrollments ON Students.StudentID = Enrollments.StudentID
JOIN Courses ON Enrollments.CourseID = Courses.CourseID;


-----------------DCL QUERY
GRANT SELECT ON Students TO [UserName];

REVOKE DELETE ON Students FROM [UserName]