CREATE DATABASE Bitbucket
USE Bitbucket

--Section 1. DDL (30 pts)
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL

	CONSTRAINT PK_Repositories_Users PRIMARY KEY (RepositoryId,ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(34,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

--2.	Insert
INSERT INTO Files ([Name], Size, ParentId, CommitId) VALUES
('Trade.idk',2598.0,1,1),
('menu.net',9238.31,2,2),
('Administrate.soshy',1246.93,3,3),
('Controller.php',7353.15,4,4),
('Find.java',9957.86,5,5),
('Controller.json',14034.87,3,6),
('Operate.xix',7662.92,7,7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file','open',1,4),
('Typo fix in Judge.html','open',4,3),
('Implement documentation for UsersService.cs','closed',8,2),
('Unreachable code in Index.cs','open',9,8)

--3.	Update
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--4.	Delete
--SELECT *
--FROM Repositories
--WHERE Name = 'Softuni-Teamwork'

DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId = 3

--SELECT Id
--FROM Commits
--WHERE RepositoryId = 3

DELETE FROM Files
WHERE CommitId = 36

DELETE FROM Commits 
WHERE RepositoryId = 3

DELETE FROM Repositories
WHERE Id = 3

--Section 3. Querying (40 pts)
--5.	Commits
SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

--6.	Front-end
SELECT Id, [Name], Size
FROM Files
WHERE Size > 1000
	AND Name LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

--7.	Issue Assignment
SELECT i.Id, Username + ' : ' + Title AS IssueAssignee
FROM Issues i
JOIN Users u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId

--8.	Single Files
SELECT f.Id, f.Name, CONVERT(VARCHAR,f.Size) + 'KB' AS Size
FROM Files f
LEFT JOIN Files p ON p.ParentId = f.Id
WHERE p.Id IS NULL

--9.	Commits in Repositories
SELECT TOP(5) r.Id, r.Name, COUNT(*) AS Commits
FROM RepositoriesContributors rc
JOIN Repositories r ON r.Id = rc.RepositoryId
JOIN Commits c ON c.RepositoryId =r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name

--10.	Average Size
SELECT  u.Username, AVG(Size) AS Size
FROM Commits c
JOIN Users u ON c.ContributorId = u.Id
JOIN Files f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username

--11.	All User Commits
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
DECLARE @result INT
SET @result = (SELECT COUNT(*)
			FROM Users u
			JOIN Commits c ON u.Id = c.ContributorId
			WHERE Username = @username
			GROUP BY Username)
	IF(@result IS NULL)
	RETURN 0
	 
	RETURN @result
END

--12.	 Search for Files
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(MAX))
AS
	SELECT Id, Name, CONVERT(VARCHAR,Size) + 'KB' AS Size
	FROM Files
	WHERE Name LIKE '%' + @fileExtension
	ORDER BY Id, Name, Size DESC