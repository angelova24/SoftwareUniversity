CREATE DATABASE Bakery2 

USE Bakery2
--Section 1
--1.DDL
CREATE TABLE Countries
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
  Id INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(25),
  LastName NVARCHAR(25),
  Gender CHAR(1) CHECK (Gender='M' OR Gender='F'),
  Age INT,
  PhoneNumber CHAR(10) CHECK (LEN(PhoneNumber)=10),
  CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(25) UNIQUE,
  [Description] NVARCHAR(250),
  Recipe NVARCHAR(MAX),
  Price DECIMAL(18,2) CHECK (Price>=0)
)

CREATE TABLE Feedbacks
(
  Id INT PRIMARY KEY IDENTITY,
  [Description] NVARCHAR(255),
  Rate DECIMAL(4,2) CHECK (Rate>=0 AND Rate <=10),
  ProductId INT FOREIGN KEY REFERENCES Products (Id),
  CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(25) UNIQUE,
  AddressText NVARCHAR(30),
  Summary NVARCHAR(200),
  CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(30),
  [Description] NVARCHAR(200),
  OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
  DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
  ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
  IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id) NOT NULL
  
  CONSTRAINT PK_Products_Ingredients PRIMARY KEY (ProductId, IngredientId)
)

--Section 2 DML
--2.Insert
INSERT INTO Distributors (Name, CountryId, AddressText, Summary)
  VALUES
  ('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
  ('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
  ('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
  ('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
  ('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
  VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--3.Update
UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--4.Delete
DELETE 
FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--Section 3 Quering
--5.Product by Price
SELECT Name, Price, Description
FROM Products
ORDER BY Price DESC, Name

--6.Negative Feedback
SELECT ProductId, Rate, Description, CustomerId, Age, Gender
FROM Feedbacks f
JOIN Customers c ON c.Id = f.CustomerId
WHERE f.Rate < 5.00
ORDER BY ProductId DESC, Rate

--7.Customers without Feedback
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, PhoneNumber, Gender
FROM Customers c
LEFT JOIN Feedbacks f ON c.Id = f.CustomerId
WHERE f.Id IS NULL
ORDER BY c.Id

--8.Customers by Criteria
SELECT FirstName, Age, PhoneNumber
FROM Customers cus
JOIN Countries cou ON cus.CountryId=cou.Id
WHERE (Age>=21 AND FirstName LIKE '%an%') OR
	  (PhoneNumber LIKE '%38' AND cou.Name NOT LIKE 'Greece')
ORDER BY FirstName, Age DESC

--9.Middle Range Distributors
SELECT *
	FROM
	(SELECT d.Name AS DistributorName, i.Name AS IngredientName, p.Name AS ProductName, AVG(Rate) AS AverageRate
		FROM Distributors d
		JOIN Ingredients i ON d.Id = i.DistributorId
		JOIN ProductsIngredients [pi] ON i.Id=[pi].IngredientId
		JOIN Products p ON [pi].ProductId = p.Id
		JOIN Feedbacks f ON f.ProductId = p.Id
	GROUP BY i.Name, d.Name, p.Name) AS t
	WHERE AverageRate BETWEEN 5 AND 8
ORDER BY DistributorName, IngredientName, ProductName

--10.Country Representative
SELECT CountryName, DistributorName
FROM (
		SELECT CountryName, DistributorName, [Count],
			   DENSE_RANK () OVER (PARTITION BY CountryName ORDER BY [Count] DESC) AS [Rank]
		FROM
			(SELECT c.Name AS CountryName, d.Name AS DistributorName, COUNT(i.Name) AS [Count]
			FROM Countries c
			LEFT JOIN Distributors d ON d.CountryId = c.Id
			LEFT JOIN Ingredients i ON i.DistributorId = d.Id
			GROUP BY c.Name, d.Name ) AS Grouped
	) AS Rankiert
WHERE [Rank] = 1 AND DistributorName IS NOT NULL
ORDER BY CountryName, DistributorName

--Section 4 Programmybility
--11.Customers with Countries
CREATE VIEW
v_UserWithCountries AS
(SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName, Age, Gender, Name AS CountryName
FROM Customers
JOIN Countries ON Countries.Id = Customers.CountryId)