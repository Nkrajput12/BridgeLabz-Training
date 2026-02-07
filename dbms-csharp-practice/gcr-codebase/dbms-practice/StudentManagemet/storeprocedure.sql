USE StudentManagement;
GO

-- Add Student Procedure

CREATE OR ALTER PROCEDURE sp_AddStudent
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100)
AS
BEGIN
    INSERT INTO Students (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);
    
    
END;
GO 

--Enroll Student Procedure
CREATE OR ALTER PROCEDURE sp_EnrollStudent
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Students WHERE StudentID = @StudentID) AND 
       EXISTS (SELECT 1 FROM Courses WHERE CourseID = @CourseID)
    BEGIN
        INSERT INTO Enrollments (StudentID, CourseID)
        VALUES (@StudentID, @CourseID);
        SELECT 'Enrollment Successful' AS Status;
    END
    ELSE
    BEGIN
        SELECT 'Error: Student or Course does not exist' AS Status;
    END
END;
GO

-- Get Student Grades Procedure
CREATE OR ALTER PROCEDURE sp_GetStudentGrades
    @StudentID INT
AS
BEGIN
    SELECT 
        s.FirstName, 
        s.LastName, 
        c.CourseName, 
        e.Grade
    FROM Students s
    JOIN Enrollments e ON s.StudentID = e.StudentID
    JOIN Courses c ON e.CourseID = c.CourseID
    WHERE s.StudentID = @StudentID;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteStudent
 @StudentID INT
 AS
 BEGIN
  DELETE FROM Students WHERE StudentID = @StudentID;
END
GO