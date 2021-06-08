USE Geography
--12. Highest Peaks in Bulgaria
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks p
	JOIN MountainsCountries mc ON p.MountainId=mc.MountainId
	JOIN Mountains m ON mc.MountainId=m.Id
	WHERE p.Elevation > 2835
	AND mc.CountryCode = 'BG'
	ORDER BY Elevation DESC

--13. Count Mountain Ranges
SELECT mc.CountryCode, COUNT(CountryCode) AS MountainRanges
	FROM MountainsCountries mc
	JOIN Mountains m ON mc.MountainId = m.Id
	WHERE mc.CountryCode IN ('US','RU','BG')
	GROUP BY CountryCode

--14. Countries with Rivers
SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries c
	LEFT JOIN CountriesRivers cs ON c.CountryCode=cs.CountryCode
	LEFT JOIN Rivers r ON cs.RiverId = r.Id
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName

--15. *Continents and Currencies
SELECT ContinentCode, CurrencyCode, Count
FROM (
		SELECT ContinentCode, CurrencyCode, [Count],
				DENSE_RANK() OVER
				(PARTITION BY ContinentCode ORDER BY [Count] DESC) AS Rank
		FROM (
			SELECT Continents.ContinentCode, CurrencyCode,
					COUNT(CurrencyCode) AS [Count]
			FROM Continents 
			JOIN Countries ON Continents.ContinentCode = Countries.ContinentCode
			GROUP BY Continents.ContinentCode, CurrencyCode
			HAVING Count(CurrencyCode) > 1) AS c
		) AS Ordered
WHERE Rank = 1
ORDER BY ContinentCode 

-- 15. second solution
	SELECT ContinentCode, CurrencyCode, Count
		FROM(
			SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS [Count],
				   DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
						FROM Countries
					GROUP BY ContinentCode, CurrencyCode) AS k
		WHERE Ranked = 1 AND Count > 1
	ORDER BY ContinentCode

--16. Countries Without Any Mountains
SELECT COUNT(c.CountryName) AS [Count]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	WHERE mc.CountryCode IS NULL
	GROUP BY MountainId

--17. Highest Peak and Longest River by Country
SELECT TOP(5) c.CountryName,
	   MAX(p.Elevation) AS HighestPeakElevation,
	   MAX(r.Length) AS LongestRiverLenght
	FROM Countries c
	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r ON cr.RiverId = r.Id
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks p ON mc.MountainId = p.MountainId
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLenght DESC, c.CountryName

--18. *Highest Peak Name and Elevation by Country
SELECT c.CountryName,
		CASE
		WHEN MAX(p.PeakName) IS NULL THEN '(no highest peak)'
		ELSE MAX(p.PeakName)
		END
		AS [Highest Peak Name],
		CASE
		WHEN MAX(p.Elevation) IS NULL THEN '0'
		ELSE MAX(p.Elevation)
		END
	    AS HighestPeakElevation,
		CASE
		WHEN MAX(m.MountainRange) IS NULL THEN '(no mountain)'
		ELSE MAX(m.MountainRange)
		END
	    AS Mountain
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks p ON mc.MountainId = p.MountainId
	LEFT JOIN Mountains m ON mc.MountainId=m.Id
	GROUP BY c.CountryName
	ORDER BY c.CountryName
