use HealthClinic;
Go

Create table Room(
	RoomId Int Identity(1,1) primary key,
	RoomNumber Varchar(10) not null unique,
);

Alter table Doctor
Add RoomId int null,
Constraint Fk_Doctor_Room Foreign key (RoomId)
	references Room(RoomId)
	On Delete Set null;

