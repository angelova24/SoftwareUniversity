USE Gringotts

--1. Records’ Count
SELECT Count(*)
FROM WizzardDeposits

--2. Longest Magic Wand
SELECT TOP(1) MagicWandSize AS LongestMagicWand
FROM WizzardDeposits
GROUP BY MagicWandSize
ORDER BY MagicWandSize DESC

--3. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--5. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount)
FROM WizzardDeposits
GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
HAVING MagicWandCreator = 'Ollivander family'

--7. Deposits Filter
SELECT *
FROM (SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
		FROM WizzardDeposits
		GROUP BY DepositGroup, MagicWandCreator
		HAVING MagicWandCreator = 'Ollivander family') AS Filtered
WHERE TotalSum < 150000
ORDER BY TotalSum DESC

--8. Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge)
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--9. Age Groups
SELECT Sorted, COUNT(*)  
FROM
	(SELECT CASE
				WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
				WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
				WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
				WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
				WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
				WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
				WHEN Age > 60 THEN '[61+]'
			END AS Sorted
		FROM WizzardDeposits) AS Result
GROUP BY Sorted

--10. First Letter
SELECT LEFT(FirstName,1)
	FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName,1)

--11. Average Interest
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--12. * Rich Wizard, Poor Wizard
SELECT SUM(Guest.DepositAmount - Host.DepositAmount) AS [Difference]
FROM WizzardDeposits AS Host
JOIN WizzardDeposits AS Guest ON Guest.Id + 1 = Host.Id

--SoftUni Database
USE SoftUni
--13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary)
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--15. Employees Average Salaries
SELECT * INTO MyNewTable
FROM Employees
WHERE Salary > 30000

DELETE FROM MyNewTable
WHERE ManagerID = 42

UPDATE MyNewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary)
FROM MyNewTable
GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary)
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

--17. Employees Count Salaries
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

--18. *3rd Highest Salary
SELECT DepartmentID, Salary
FROM (
		SELECT DepartmentID, Salary,
				DENSE_RANK () OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Ranked
		FROM Employees
		GROUP BY DepartmentID, Salary) AS Ranked
WHERE Ranked = 3

--19