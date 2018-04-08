CREATE TABLE `EmployeeGroup` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Name`	TEXT NOT NULL UNIQUE
);

INSERT INTO EmployeeGroup(Id, Name)
VALUES 
(1,'Employee'),
(2,'Manager'),
(3,'Salesman');

CREATE TRIGGER EmployeeGroup_Delete BEFORE DELETE ON EmployeeGroup
BEGIN
    SELECT RAISE(ABORT, 'deletion disabled');
END;

CREATE TABLE `Staff` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Name`	TEXT NOT NULL,
	`DateWork`	INTEGER NOT NULL,
	`EmployeeGroupId`	INTEGER NOT NULL,
	`BasicSalary`	REAL,
	FOREIGN KEY(EmployeeGroupId) REFERENCES EmployeeGroup(Id)
);
CREATE TABLE `SubmissionRelations` (
	`ChiefId`	INTEGER NOT NULL CHECK(ChiefId != 1),
	`SubordinateId`	INTEGER NOT NULL CHECK(SubordinateId != ChiefId),
	PRIMARY KEY (ChiefId, SubordinateId),
	FOREIGN KEY(ChiefId) REFERENCES Staff(Id),
	FOREIGN KEY(SubordinateId) REFERENCES Staff(Id)
);