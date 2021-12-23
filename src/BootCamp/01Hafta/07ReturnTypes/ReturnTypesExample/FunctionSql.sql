
--String Functions

SELECT  ASCII('D')

SELECT CONCAT('W3Schools', '.com');

SELECT DATALENGTH('W3Schools.com');

SELECT REPLACE('SQL Tutorial', 'T', 'M');

SELECT RTRIM(LTRIM('   SQL Tutorial    '));

SELECT UPPER('   SQL Tutorial    ');

SELECT Lower('   SQL Tutorial    ');

--Numeric Functions

SELECT AVG(Price) AS AveragePrice FROM Products

SELECT COUNT(Id) AS NumberOfProducts FROM Products;

SELECT MAX(Price) AS LargestPrice FROM Products;

SELECT MIN(Price) AS LargestPrice FROM Products;

SELECT ROUND(235.415, 2) AS RoundValue;

SELECT SQUARE(64);

--Date Functions

SELECT CURRENT_TIMESTAMP;

SELECT DATEADD(year, 1, '2017/08/25') AS DateAdd;

SELECT DATEDIFF(year, '2017/08/25', '2011/08/25') AS DateDiff;

SELECT DATEPART(year, '2017/08/25') AS DatePartInt;

SELECT GETDATE();

SELECT YEAR(GETDATE());
SELECT MONTH(GETDATE());
SELECT DAY(GETDATE());

-- Advanced Functions

SELECT CAST(25.65 AS int);

SELECT ISNULL(NULL, 'W3Schools.com');

SELECT CONVERT(int, 25.65);

--Return the first non-null value in a list:
SELECT COALESCE(NULL, NULL, NULL, 'W3Schools.com', NULL, 'Example.com');