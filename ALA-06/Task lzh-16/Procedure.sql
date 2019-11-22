--13

--13.1
CREATE OR ALTER PROC GreatestOrders @Year int
	AS
	BEGIN
		SELECT LastName + ' ' + FirstName AS 'Name', Price
		FROM Employees 
		INNER JOIN (SELECT EmployeeID, MAX(UnitPrice * Quantity - UnitPrice * Quantity * Discount) AS Price 
			FROM [Order Details] 
			INNER JOIN Orders ON [Order Details].OrderID = Orders.OrderID
			WHERE @Year = YEAR(OrderDate)
			GROUP BY EmployeeID) AS O ON Employees.EmployeeID = O.EmployeeID;
	END;

--13.2
CREATE OR ALTER PROC ShippedOrdersDiff
	@Time int=35
AS BEGIN
	SELECT *
	FROM (Select OrderID, OrderDate, ShippedDate, DATEDIFF(dd, OrderDate, ShippedDate) AS ShippedDelay, SpecifiedDelay = @Time
		FROM Orders) as SD
	WHERE ShippedDelay > @Time OR ShippedDate IS NULL;
END;
--13.3
CREATE OR ALTER PROC SubordinationInfo 
	@EmployeeID INT
AS
BEGIN
	WITH parent AS (
    SELECT EmployeeID
    FROM Employees
    WHERE EmployeeID = @EmployeeID
), tree AS (
    SELECT x.ReportsTo, x.EmployeeID
    FROM Employees x
    INNER JOIN parent ON x.ReportsTo = parent.EmployeeID
    UNION ALL
    SELECT y.ReportsTo, y.EmployeeID
    FROM Employees y
    INNER JOIN tree t ON y.ReportsTo = t.EmployeeID
)
SELECT ReportsTo, EmployeeID
FROM tree
END;
--13.4
CREATE OR ALTER FUNCTION IsBoss (@EmploeeID INT)
RETURNS BIT
AS
BEGIN
	Declare @ValueToReturn BIT
	if (@EmploeeID IN (SELECT DISTINCT emp2.EmployeeID
	FROM Employees AS emp
	INNER JOIN (SELECT EmployeeID
				FROM Employees) AS emp2 ON emp.ReportsTo = emp2.EmployeeID)) set @ValueToReturn = 1
	else  set @ValueToReturn = 0
	Return @ValueToReturn
END;