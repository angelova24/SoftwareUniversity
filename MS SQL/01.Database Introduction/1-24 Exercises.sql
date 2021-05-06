--Problem 1.Create Database
CREATE DATABASE Minions2

--Problem 2.Create Tables
CREATE TABLE Minions
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(MAX),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(MAX)
)

--Problem 3.Alter Minions Table
ALTER TABLE Minions
ADD TownsId INT  CONSTRAINT fk_Minions_Towns FOREIGN KEY REFERENCES Towns(Id)

--Problem 4.Insert Records in Both Tables
INSERT INTO Towns
VALUES (1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions
VALUES (1, 'Kevin', 22,1),
(2, 'Bob', 15,3),
(3, 'Steward', NULL,2)

--Problem 5.Truncate Table Minions
TRUNCATE Table Minions

--Problem 6.Drop All Tables
DROP DATABASE Minions2

--Problem 7.Create Table People
CREATE TABLE People
(
[Id] int PRIMARY KEY IDENTITY,
[Name] nvarchar(200) NOT NULL,
[Picture] varchar(max),
[Height] float(2),
[Weight] float(2),
[Gender] char NOT NULL,
Birthdate datetime NOT NULL,
Biography nvarchar(max)
)

INSERT INTO People ([Name], [Picture],[Height], [Weight],[Gender],Birthdate,Biography)
VALUES ('Kole', 'https://avatars3.githubusercontent.com/u/15928587?s=32&v=4', 25.25, 52.36, 'f', '2/3/2020', 'kuhwiughouhgow'),
('sfsfdsfs', 'https://avatars3.githubusercontent.com/u/15928587?s=32&v=4', 25.25, 52.36, 'f', '2/3/2020', 'rghtrjfh'),
('Koutzle', 'https://avatars3.githubusercontent.com/u/15928587?s=32&v=4', 25.25, 52.36, 'f', '2/3/2020', 'ergrgsrhd'),
('zjtjzj', 'https://avatars3.githubusercontent.com/u/15928587?s=32&v=4', 25.25, 52.36, 'f', '2/3/2020', 'rdgwrfffffgt'),
('Ko5t3tele', 'https://avatars3.githubusercontent.com/u/15928587?s=32&v=4', 25.25, 52.36, 'f', '2/3/2020', 'gggggggggggg')

--Problem 8.Create Table Users
CREATE TABLE Users
(
[Id] bigint PRIMARY KEY IDENTITY,
[Username] varchar(30) NOT NULL,
[Password] varchar(26) NOT NULL,
[ProfilPicture] nvarchar(max),
LastLoginTime datetime,
IsDeleted bit
)

INSERT INTO Users (Username, [Password], ProfilPicture, LastLoginTime, IsDeleted)
VALUES ('hjabak', 'skfksjfk', 'sdiahd', '4/5/2020', 0),
('hjabak', 'skfksjfk', 'sdiahd', '4/5/2020', 0),
('hjabak', 'skfksjfk', 'sdiahd', '4/5/2020', 0),
('hjabak', 'skfksjfk', 'sdiahd', '4/5/2020', 0),
('hjabak', 'skfksjfk', 'sdiahd', '4/5/2020', 0)

--Problem 9.Change Primary Key
--
--


--Problem 13.Movies Database
CREATE DATABASE Movies
USE Movies

--Problem 19.Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20.Basic Select All Fields and Order Them
SELECT * 
	FROM Towns
	ORDER BY Name
SELECT * 
	FROM Departments
	ORDER BY Name
SELECT * 
	FROM Employees
	ORDER BY Salary DESC

--Problem 21.Basic Select Some Fields
SELECT Name 
	FROM Towns
	ORDER BY Name
SELECT Name
	FROM Departments
	ORDER BY Name
SELECT FirstName, LastName, JobTitle, Salary
	FROM Employees
	ORDER BY Salary DESC

--Problem 22.Increase Employees Salary
UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary
	FROM Employees

--Problem 23.Decrease Tax Rate
UPDATE Payments
SET TaxRate = TaxRate * 0.97

SELECT TaxRate
FROM Payments

--Problem 24.Delete All Records
SELECT * 
FROM Occupancies 

DROP TABLE Occupancies

