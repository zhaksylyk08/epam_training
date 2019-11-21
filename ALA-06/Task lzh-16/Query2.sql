-- Working with Northwind database
USE Northwind;
GO

--1

--1.1
SELECT OrderID, ShippedDate, ShipVia FROM Orders
WHERE ShippedDate >= {d'1998-05-06'} AND ShipVia >= 2;

--1.2
SELECT OrderID, ShippedDate = 
CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END
FROM Orders WHERE ShippedDate IS NULL;

--1.3
SELECT OrderID AS "Order Number",
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped'
		ELSE CONVERT(nvarchar, ShippedDate, 23)
		END AS "Shipped Date" 
FROM Orders WHERE ShippedDate > {d'1998-05-06'} OR ShippedDate IS NULL;

--2

--2.1
SELECT ContactName, Country
FROM Customers WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country;

--2.2
SELECT ContactName, Country
FROM Customers WHERE Country NOT IN('USA', 'Canada')
ORDER BY ContactName;

--2.3
SELECT DISTINCT Country
FROM Customers
ORDER BY Country DESC;

--3

--3.1
SELECT DISTINCT OrderID
FROM [Order Details] WHERE Quantity BETWEEN 3 AND 10;

--3.2 
SELECT CustomerID, Country
FROM Customers WHERE SUBSTRING(Country, 1, 1) BETWEEN 'B' AND 'G'
ORDER BY Country;

--3.3
SELECT CustomerID, Country
FROM Customers WHERE SUBSTRING(Country, 1, 1) >= 'B' AND SUBSTRING(Country, 1, 1) <= 'G'
ORDER BY Country;

--4

--4.1
SELECT ProductName
FROM Products WHERE ProductName LIKE '%cho_olade%';

--5

--5.1  
SELECT ROUND(SUM((UnitPrice - Discount*UnitPrice)*Quantity), 2) AS 'Totals'
FROM [Order Details];

--5.2 
SELECT COUNT(CASE WHEN ShippedDate IS NULL THEN 1 END)
FROM Orders;

--5.3
SELECT COUNT(DISTINCT CustomerID)
FROM Orders;

--6

--6.1 
SELECT YEAR(ShippedDate) AS Year, COUNT(OrderID) AS Total
FROM Orders GROUP BY YEAR(ShippedDate);

--6.2 Ï
SELECT CONCAT(LastName, ' ', FirstName) AS 'Seller', Amount
FROM Employees emp
INNER JOIN(SELECT EmployeeID, COUNT(OrderID) AS Amount FROM Orders GROUP BY(EmployeeID)) ord
ON ord.EmployeeID = emp.EmployeeID
ORDER BY Amount DESC; 

--6.3 
SELECT EmployeeID, CustomerID, COUNT(OrderID) AS 'Amount'
FROM Orders 
GROUP BY CUBE(EmployeeID, CustomerID);

--6.4  
SELECT CONCAT(LastName, ' ', FirstName) AS Person, 'Seller' AS Type, City
FROM Employees AS emp
WHERE EXISTS(SELECT * FROM Customers AS c
				WHERE emp.City = c.City)
UNION
SELECT ContactName AS Person, 'Customer' AS Type, City
FROM Customers AS c
WHERE EXISTS(SELECT * FROM Employees AS emp
				WHERE emp.City = c.City)
ORDER BY City, Person;

--6.5 
SELECT CustomerID, City
FROM Customers AS c
WHERE EXISTS(SELECT * FROM Customers AS c2
				WHERE c.City = c2.City AND NOT(c.CustomerID = c2.CustomerID));

--6.6  
SELECT LastName AS 'User Name', Boss
FROM Employees AS emp
INNER JOIN (SELECT  EmployeeID, LastName AS Boss FROM Employees) AS emp2
ON emp2.EmployeeID = emp.ReportsTo;

--7

--7.1  
SELECT LastName, TerritoryDescription AS Territory
FROM Employees as emp
INNER JOIN EmployeeTerritories AS empter ON emp.EmployeeID = empter.EmployeeID
INNER JOIN Territories AS terr ON empter.TerritoryID = terr.TerritoryID
INNER JOIN Region AS reg ON terr.RegionID = reg.RegionID
WHERE reg.RegionDescription = 'Western';

--8

--8.1 
SELECT c.CustomerID, COUNT(OrderID) 
FROM Customers AS c
LEFT OUTER JOIN Orders AS ord
ON c.CustomerID = ord.CustomerID
GROUP BY c.CustomerID
ORDER BY COUNT(OrderID);

--9

--9.1 
SELECT CompanyName
FROM Suppliers AS s
JOIN Products AS p ON s.SupplierID = p.SupplierID
WHERE UnitsInStock IN(SELECT UnitsInStock = 0 FROM Products);

--10

--10.1 
SELECT CONCAT(LastName, ' ', FirstName)
FROM Employees
WHERE EmployeeID IN
				(SELECT EmployeeID FROM Orders 
					GROUP BY EmployeeID
					HAVING COUNT(OrderID) > 150);

--11

--11.1 
SELECT ContactName
FROM Customers AS c
WHERE NOT EXISTS(SELECT CustomerID FROM Orders AS ord WHERE c.CustomerID = ord.CustomerID  
				GROUP BY CustomerID
				HAVING COUNT(OrderID) > 0);

--12

--12.1 
SELECT SUBSTRING(LastName, 1, 1) AS 'First Letter'
FROM Employees
ORDER BY [First Letter];

