--Problem 1.One-To-One Relationship
CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(8)
)

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30),
	Salary DECIMAL(15,2),
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--Problem 2.One-To-Many Relationship
CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	EstablishedON DATETIME,
)

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY (101,1),
	[Name] VARCHAR(20),
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

--Problem 3.Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30)
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30)
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)

	CONSTRAINT PK_Students_Exams PRIMARY KEY (StudentID, ExamID)
)

--Problem 4.Self-Referencing
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY (101,1),
	[Name] VARCHAR(30),
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

--Problem 5.Online Store Database
CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID),
	[Name] VARCHAR(50)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID)

	CONSTRAINT PK_Order_Item PRIMARY KEY (OrderID, ItemID)
)

--Problem 6.University Database
CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT UNIQUE,
	StudentName VARCHAR(50),
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)

	CONSTRAINT PK_Students_Subjects PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME,
	PaymentAmount DECIMAL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

