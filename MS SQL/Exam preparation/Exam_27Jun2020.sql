
--SECTION 1 DDL
--1.Database design
USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone)=12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status VARCHAR(11) DEFAULT 'Pending' CHECK(Status IN ('Pending','In Progress','Finished')),
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description VARCHAR(255),
	Price DECIMAL(6,2) CHECK(Price>0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 CHECK(StockQty>=0)
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity >0)

	CONSTRAINT PK_Orders_Parts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity >0)

	CONSTRAINT PK_Parts_Jobs PRIMARY KEY (JobId, PartId)
)

--SECTION 2 DML
--2.Insert
INSERT INTO Clients (FirstName, LastName, Phone)
VALUES
('Teri',	'Ennaco', '570-889-5187'),
('Merlyn',	'Lawler', '201-588-7810'),
('Georgene',	'Montezuma', '925-615-5185'),
('Jettie',	'Mconnell', '908-802-3564'),
('Lemuel',	'Latzke', '631-748-6479'),
('Melodie',	'Knipp', '805-690-1682'),
('Candida',	'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, Description, Price, VendorId)
VALUES
('WP8182119', 'Door Boot Seal', 117.86,	2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--3.Update
UPDATE Jobs
SET MechanicId = 3, Status = 'In Progress'
WHERE Status='Pending'

--4.Delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--SECTION 3 Querying
--5.Mechanic Assignments
SELECT CONCAT(FirstName, ' ', LastName) AS Mechanic,
	   Status,
	   IssueDate
FROM Mechanics m
JOIN Jobs j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, IssueDate, JobId

--6.Current Clients
SELECT CONCAT(FirstName, ' ', LastName) AS Client,
	   DATEDIFF(DAY, IssueDate, '2017-04-24') AS [Days going],
	   Status
FROM Clients c
JOIN Jobs j ON j.ClientId = c.ClientId
WHERE j.Status != 'Finished'
ORDER BY [Days going] DESC, c.ClientId

--7.Mechanic Performance
SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
       AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics m
JOIN Jobs j ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName)
ORDER BY m.MechanicId

--8.Available Mechanics WRONG
SELECT FirstName+' ' +LastName AS Available
FROM
	(SELECT m.MechanicId, m.FirstName, m.LastName, j.Status,
		   DENSE_RANK() OVER (PARTITION BY m.FirstName +' '+m.LastName ORDER BY Status) AS [Rank]
	FROM Mechanics m
	LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
	GROUP BY m.MechanicId, m.FirstName, m.LastName, j.Status) AS Ranked
GROUP BY MechanicId, (FirstName +' '+LastName)
HAVING SUM([Rank]) = 1
ORDER BY MechanicId

--8.Available Mechanics RIGHT
SELECT (FirstName + ' ' + LastName)
	FROM Mechanics m
	LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL OR (SELECT COUNT(j.Status)
								FROM Jobs j
								WHERE j.Status != 'Finished' AND j.MechanicId = m.MechanicId) =0
GROUP BY m.MechanicId, (FirstName + ' ' + LastName)
ORDER BY m.MechanicId

--9.Past Expenses
SELECT j.JobId, 
	   ISNULL(SUM(op.Quantity * p.Price),0) AS Total
FROM Jobs j
LEFT JOIN Orders o ON o.JobId = j.JobId
LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
LEFT JOIN Parts p ON p.PartId = op.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--10.Missing Parts
SELECT p.PartId,
	   p.Description,
	   pn.Quantity AS Required,
	   p.StockQty AS [In Stock],
	   IIF(o.Delivered = 0, op.Quantity, 0) AS Ordered
FROM Jobs j
JOIN PartsNeeded pn ON pn.JobId = j.JobId
JOIN Parts p ON pn.PartId = p.PartId
LEFT JOIN Orders o ON o.JobId = j.JobId
LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
WHERE j.Status != 'Finished' 
	  AND pn.Quantity  > p.StockQty
	  AND o.OrderId IS NULL
ORDER BY p.PartId

--11.	Place Order
CREATE PROC usp_PlaceOrder
	(@jobId INT,
	@serialNumber VARCHAR(50),
	@qty INT)
AS

DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)
DECLARE @isJobFinished VARCHAR(10) = (SELECT Status FROM Jobs WHERE JobId = @jobId)

IF (@isJobFinished = 'Finished')
 THROW 50011, 'This job is not active!', 1
ELSE IF (@qty <= 0)
 THROW 50012, 'Part quantity must be more than zero!', 1
ELSE IF (@isJobFinished IS NULL)
 THROW 50013, 'Job not found!', 1
ELSE IF (@partId IS NULL)
 THROW 50014, 'Part not found!', 1

DECLARE @orderId INT = (SELECT OrderId 
						FROM Orders
						WHERE JobId = @jobId AND IssueDate IS NULL)

IF(@orderId IS NULL)
BEGIN
	INSERT INTO Orders (JobId, IssueDate) VALUES
	(@jobId, NULL)
END

SET @orderId = (SELECT OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL)

DECLARE @orderPArtExists INT = (SELECT OrderId FROM OrderParts WHERE OrderId = @orderId
								AND PartId = @partId)

IF (@orderPArtExists IS NULL)
BEGIN
	INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
	(@orderId, @partId, @qty)
END
ELSE
BEGIN
	UPDATE OrderParts
	SET Quantity += @qty
	WHERE OrderId = @orderId
	AND PartId = @partId
END


--12.	Cost Of Order
CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
DECLARE @result DECIMAL(15,2)
SET @result = (SELECT SUM(p.Price * op.Quantity) AS totalSum
			FROM Jobs j
			JOIN Orders o ON o.JobId = j.JobId
			JOIN OrderParts op ON op.OrderId = o.OrderId
			JOIN Parts p ON op.PartId = p.PartId
			WHERE j.JobId = @jobId
			GROUP BY j.JobId)
IF (@result IS NULL)
	SET @result = 0

RETURN @result

END