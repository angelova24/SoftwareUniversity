--Problem 12. Countries Holding ‘A’ 3 or More Times--
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code]
	FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode
	
--Problem 13. Mix of Peak and River Names--
SELECT PeakName, RiverName,
	LOWER(PeakName + RIGHT(RiverName, LEN(RiverName)-1)) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
	ORDER BY Mix
