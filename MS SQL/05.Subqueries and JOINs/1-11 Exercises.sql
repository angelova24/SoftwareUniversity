USE SoftUni
--1. Employee Address
SELECT TOP(5) EmployeeID, JobTitle, Employees.AddressID, AddressText
	FROM Employees
	JOIN Addresses ON Employees.AddressID = Addresses.AddressID
	ORDER BY AddressID

--2. Addresses with Towns
SELECT TOP(50) FirstName, LastName, Towns.Name AS Town, Addresses.AddressText
	FROM Employees
	JOIN Addresses ON Employees.AddressID = Addresses.AddressID
	JOIN Towns ON Addresses.TownID = Towns.TownID
	ORDER BY FirstName, LastName

--3. Sales Employee
SELECT EmployeeID, FirstName, LastName, Departments.Name
	FROM Employees
	JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
	WHERE Name = 'Sales'
	ORDER BY EmployeeID

--4. Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY d.DepartmentID

--5. Employees Without Project
SELECT TOP(3) Employees.EmployeeID, FirstName
	FROM Employees
	LEFT JOIN EmployeesProjects ON Employees.EmployeeID = EmployeesProjects.EmployeeID
	WHERE EmployeesProjects.EmployeeID IS NULL 
	AND EmployeesProjects.ProjectID IS NULL
	ORDER BY Employees.EmployeeID

--6. Employees Hired After
SELECT FirstName, LastName, HireDate, Name
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE
	(HireDate > '1999-01-01') 
	AND
	(Name = 'Sales' OR Name = 'Finance')
	ORDER BY HireDate

--7. Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name
	FROM Employees e
	JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-08-13'
	AND p.EndDate IS NULL
	ORDER BY EmployeeID

--8. Employee 24
SELECT e.EmployeeID, FirstName,
	   CASE
	   WHEN DATEPART(YEAR,p.StartDate) < 2005 THEN p.Name
	   ELSE NULL
	   END
	  AS ProjectName
	FROM EmployeesProjects ep
	JOIN Employees e ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--9. Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
	FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	WHERE e.ManagerID = 3 OR e.ManagerID = 7
	ORDER BY EmployeeID

--10. Employee Summary
SELECT TOP(50) e.EmployeeID,
	           e.FirstName + ' ' + e.LastName AS EmployeeName,
	           m.FirstName + ' ' + m.LastName AS ManagerName,
	           d.Name AS DepartmentName
	FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	ORDER BY EmployeeID

--11. Min Average Salary
SELECT TOP(1) AVG(Salary) AS MinAverageSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY MinAverageSalary