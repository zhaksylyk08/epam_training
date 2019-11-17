use Northwind
go

-- 1
SELECT OrderID, ShippedDate FROM Orders WHERE ShippedDate >= '05-06-1998' AND ShipVia >= 2; 
GO

SELECT OrderID, ShippedDate = 
CASE
WHEN ShippedDate IS NULL THEN 'Not Shipped'
END
FROM Orders WHERE ShippedDate IS NULL
GO

select OrderID as 'Order Number' from Orders where ShippedDate > '05-06-1998' or ShippedDate is null
go

-- 2
select ContactName, Country from Customers where Country in ('USA', 'Canada')
order by ContactName, Country
go

select ContactName, Country from Customers where Country not in ('USA', 'Canada')
order by ContactName
go

select distinct Country from Customers
order by Country desc
go

-- 3
select distinct OrderID from [Order Details]
where Quantity between 3 and 10
go

select distinct CustomerID, Country
from Customers
where  Country between 'b' and 'g'
order by Country
go

-- 4
select ProductName
from Products
where  ProductName like '%cho_olade%'
go

-- 5
select sum((UnitPrice - UnitPrice * Discount) * Quantity) as 'Totals'
from [ORDER Details]
go

select Count(
		case
		when ShippedDate is null then 1 
		else null 
		end) as [Not Shiped]
from Orders

select count(distinct CustomerID) as [Customers Count]
from Customers

-- 6
select DATEPART(yyyy, OrderDate) as Year, COUNT(OrderId) as Total
from Orders
group by DATEPART(yyyy, OrderDate)

select ISNULL( cast(Seller as varchar(50)),
			case when GROUPING(Seller) = 1 then 'ALL' 
			end) as Seller,
	   ISNULL( cast(ContactName as varchar(50)),
			case when GROUPING(ContactName) = 1 then 'ALL' 
			end) as Customer,
	   COUNT(Orders.OrderID) as Amount
FROM Orders
INNER JOIN (select EmployeeID, FirstName + ' ' + LastName as Seller 
			FROM Employees) as S on S.EmployeeID = Orders.EmployeeID
INNER JOIN Customers on Orders.CustomerID = Customers.CustomerID
where YEAR(Orders.OrderDate) = 1998
group by cube(Seller, ContactName) 
order by Amount desc, S.Seller, Customer;

-- 7
select LastName, TerritoryDescription
from Employees
INNER JOIN EmployeeTerritories on EmployeeTerritories.EmployeeID = Employees.EmployeeID
INNER JOIN Territories on Territories.TerritoryID = EmployeeTerritories.TerritoryID
INNER JOIN Region on Region.RegionID = Territories.RegionID
where  RegionDescription = 'Western';

-- 8
select Customers.CustomerID, Count(OrderID) as Orders
from Customers
LEFT OUTER JOIN Orders on Orders.CustomerID = Customers.CustomerID
group by Customers.CustomerID
order by Orders

-- 9
select CompanyName
from suppliers
JOIN Products on Products.SupplierID = Suppliers.SupplierID
where  UnitsInStock in (
	select UnitsInStock = 0 
	FROM Products);

-- 10
select FirstName, LastName
from Employees
where  EmployeeID in (
	select EmployeeID
	from Orders
	group by EmployeeID
	having COUNT(OrderID) > 150);


