INSERT INTO Staff (Id, Name, DateWork, EmployeeGroupId, BasicSalary)
VALUES
 (1,'Sparks Daniel',1210000000,1,49000),
 (2,'Flowers John',1220000000,1,81000),
 (3,'Powell Steven',1230000000,1,67000),
 (4,'West Claude',1240000000,2,16000),
 (5,'Rose Kenneth',1250000000,3,62000),
 (6,'Adams Michael',1260000000,1,82000),
 (7,'Nicholson Beverly',1270000000,1,28000),
 (8,'Holt Christopher',1280000000,1,44000),
 (9,'Morton Earl',1290000000,2,37000),
 (10,'Stevenson Donald',1300000000,3,33000),
 (11,'Baker Mary',1310000000,1,40000),
 (12,'Watkins Lily',1320000000,1,72000),
 (13,'McCoy Paulina',1330000000,1,13000),
 (14,'Hardy Stephany',1340000000,2,13000),
 (15,'Anderson Josephine',1350000000,3,91000),
 (16,'Merritt Colleen',1360000000,1,60000),
 (17,'Moody Gladys',1370000000,1,61000),
 (18,'McCarthy Bernice',1380000000,1,68000),
 (19,'Willis Roxanne',1390000000,2,98000),
 (20,'Rose Jodie',1400000000,3,38000);
 
INSERT INTO SubmissionRelations (ChiefId,SubordinateId)
VALUES
(19,16),
(15,5),
(4,1),
(4,17),
(19,2),
(15,10),
(9,8),
(5,20),
(9,11),
(14,3),
(10,4),
(14,15),
(20,19),
(13,7),
(15,12),
(14,13),
(10,18),
(19,20),
(20,6),
(4,14);
