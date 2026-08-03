--drop the phone in patient table 

ALTER TABLE Patient
DROP COLUMN Phone;

--make a saparete table for phone number

CREATE TABLE PatientPhone (
    PatientID INT NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    
    PRIMARY KEY (PatientID, PhoneNumber),
    CONSTRAINT FK_PatientPhone_Patient FOREIGN KEY (PatientID) 
        REFERENCES Patient(PatientID) 
        ON DELETE CASCADE
);

--1NF (First Normal Form): Satisfied. Eliminates multi-valued attributes
--2NF (Second Normal Form): Satisfied. Since there are no non-key attributes in this table, no partial dependencies can exist.
--3NF (Third Normal Form): Satisfied. There are no non-key attributes depending on other non-key attributes (no transitive dependencies).