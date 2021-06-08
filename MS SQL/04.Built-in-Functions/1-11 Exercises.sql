--Problem 1. Find Names of All Employees by First Name--
SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'SA%'

--Problem 2. Find Names of All employees by Last Name--
SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%EI%'
	
--Problem 3. Find First Names of All Employees--
SELECT FirstName
	FROM Employees
	WHERE DepartmentID=3 OR DepartmentID=10

--Problem 4. Find All Employees Except Engineers--
SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--Problem 5. Find Towns with Name Length--
SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) IN (5,6)
	ORDER BY [Name]

--Problem 6. Find Towns Starting With--
SELECT *
	FROM Towns
	WHERE Name LIKE 'M%'
	OR Name LIKE 'K%'
	OR Name LIKE 'B%'
	OR Name LIKE 'E%'
	ORDER BY Name

--Problem 7. Find Towns Not Starting With--
SELECT *
	FROM Towns
	WHERE Name NOT LIKE 'R%'
	AND Name NOT LIKE 'B%'
	AND Name NOT LIKE 'D%'
	ORDER BY Name

--Problem 8. Create View Employees Hired After 2000 Year--
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT FirstName, LastName
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) > 2000

--Problem 9. Length of Last Name--
SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

--Problem 10. Rank Employees by Salary--
Select EmployeeID, FirstName, LastName, Salary
	,DENSE_RANK () OVER 
	(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--Problem 11.	Find All Employees with Rank 2 *--
WITH ClassRanks AS
(
	SELECT EmployeeID, FirstName, LastName, Salary , RANK () OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
)
	SELECT *
	FROM ClassRanks
	WHERE (Salary BETWEEN 10000 AND 50000)
	AND Rank = 2
	ORDER BY Salary DESC