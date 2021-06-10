--SoftUni Database
USE SoftUni

--1.Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName
FROM Employees
WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000

--2.Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@NUMBER DECIMAL(18,4))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @NUMBER

--3.Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith (@Parameter NVARCHAR(MAX))
AS
	SELECT Name
	FROM Towns
	WHERE Name LIKE @Parameter + '%'

--4.Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName NVARCHAR(MAX))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees e 
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON t.TownID = a.TownID
	WHERE t.Name = @TownName

--5.Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @result VARCHAR(10)

	IF (@salary < 30000) SET @result = 'Low'

	ELSE IF (@salary >= 30000 AND @salary <=50000) 
		SET @result = 'Average'

	ELSE
		SET @result = 'High'
RETURN @result
END

--6.Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@level VARCHAR(20))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @level

--7.Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
DECLARE @count INT = 1

	WHILE (@count <= LEN(@word))
	BEGIN
		DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @count, 1)
		IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
		 RETURN 0
		SET @count +=1
	END
RETURN 1
END

