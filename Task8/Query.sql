--1.1	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� 
--(������� ShippedDate) ������������ � ������� ���������� � ShipVia >= 2. 
--������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������, 
--�������� ����������� ������ �Writing International Transact-SQL Statements� � 
--Books Online ������ �Accessing and Changing Relational Data Overview�. 
--���� ����� ������������ ����� ��� ���� �������. ������ ������ ����������� ������ 
--������� OrderID, ShippedDate � ShipVia. 
--�������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate. 
--�����: ������ ��� ������� DATEPART ���������� ������ �������� ���� int

SELECT OrderID, ShippedDate, ShipVia 
FROM [Northwind].[dbo].[Orders]
WHERE DATEPART(yyyy, ShippedDate) >= N'1998' AND 
DATEPART(mm,ShippedDate) >= N'05' AND DATEPART(dd,ShippedDate) >= N'06' 
AND ShipVia >= '2';

--1.2	�������� ������, ������� ������� ������ �������������� ������ �� ������� Orders.
-- � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ 
-- �Not Shipped� � ������������ ��������� ������� CAS�. ������ ������ ����������� ������
--  ������� OrderID � ShippedDate.
SELECT OrderID, ShippedDate =
CASE  
WHEN ShippedDate IS NULL THEN 'Not Shipped'
END 
FROM [Northwind].[dbo].[Orders]
WHERE ShippedDate IS NULL;

--1.3	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ����
-- (ShippedDate) �� ������� ��� ���� ��� ������� ��� �� ����������. � ������� ������
--  ������������� ������ ������� OrderID (������������� � Order Number) � ShippedDate 
--  (������������� � Shipped Date). � ����������� ������� ����������� ��� �������
--   ShippedDate ������ �������� NULL ������ �Not Shipped�, ��� ��������� �������� 
--   ����������� ���� � ������� �� ���������.

DECLARE 
    @date DATETIME = CONVERT(DATETIME, '1998-05-06'),
	@DEFAULT_DATETIME_FORMAT INT = 0;

SELECT [OrderID] AS 'Order Number',
	CASE 
        WHEN [ShippedDate] IS NULL 
        THEN 'Not shipped'
        ELSE CONVERT(VARCHAR(30), [ShippedDate], @DEFAULT_DATETIME_FORMAT)
     END AS 'Shipped Date'
FROM [Northwind].[dbo].[Orders] 
WHERE [ShippedDate] > @date OR [ShippedDate] IS NULL;

--2.1	������� �� ������� Customers ���� ����������, ����������� � USA � Canada.
--������ ������� � ������ ������� ��������� IN. ����������� ������� � ������ ������������ 
--� ��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ���������� 
--� �� ����� ����������.

SELECT ContactName, Country
FROM [Northwind].[dbo].[Customers] 
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country ASC;

--2.2	������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. 
--������ ������� � ������� ��������� IN. ����������� ������� � ������ ������������ � 
--��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ����������.
SELECT ContactName, Country
FROM [Northwind].[dbo].[Customers] 
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName ASC;

--2.3	������� �� ������� Customers ��� ������, � ������� ��������� ���������. 
--������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������. 
--�� ������������ ����������� GROUP BY. ����������� ������ ���� ������� � ����������� �������.
SELECT DISTINCT Country
FROM [Northwind].[dbo].[Customers] 
ORDER BY Country DESC; 

--3.1	������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������), 
--��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity 
--� ������� Order Details. ������������ �������� BETWEEN. ������ ������ ����������� ������ 
--������� OrderID.
SELECT DISTINCT OrderID
FROM [Northwind].[dbo].[Order Details]
WHERE Quantity BETWEEN 3 AND 10;

--3.2	������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� 
--�� ����� �� ��������� b � g. ������������ �������� BETWEEN. ���������, ��� � ���������� 
--������� �������� Germany. ������ ������ ����������� ������ ������� CustomerID � Country 
--� ������������ �� Country.
SELECT CustomerID, Country
FROM [Northwind].[dbo].[Customers]
WHERE Country BETWEEN 'b' AND 'h'
ORDER BY Country ASC;

--3.3	������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� 
--����� �� ��������� b � g, �� ��������� �������� BETWEEN. � ������� ����� �Execution Plan� 
--���������� ����� ������ ���������������� 3.2 ��� 3.3 � ��� ����� ���� ������ � ������ ���������� 
--���������� Execution Plan-a ��� ���� ���� ��������, ���������� ���������� Execution Plan ���� 
--������ � ������ � ���� ����������� � �� �� ����������� ���� ����� �� ������ � �� ������ 
--��������� ���� ��������� ���������. ������ ������ ����������� ������ ������� CustomerID � 
--Country � ������������ �� Country.
--�����: �� ������, ��� ������ ����� � ��������� ������, �� ��������� ���������� Execution Plan
--�������, ��� ������� 3.2 � 3.3 ������������
SELECT CustomerID, Country
FROM [Northwind].[dbo].[Customers]
WHERE Country > 'b' AND Country < 'h'
ORDER BY Country ASC;

--4.1	� ������� Products ����� ��� �������� (������� ProductName), ��� ����������� 
--��������� 'chocolade'. ��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� 
--����� 'c' � �������� - ����� ��� ��������, ������� ������������� ����� �������. 
--���������: ���������� ������� ������ ����������� 2 ������.
SELECT ProductName
FROM [Northwind].[dbo].[Products]
WHERE ProductName LIKE '%cho_olade%';

--5.1	����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� 
--����������� ������� � ������ �� ���. ��������� ��������� �� ����� � ��������� � ����� 1 
--��� ���� ������ money.  ������ (������� Discount) ���������� ������� �� ��������� ��� 
--������� ������. ��� ����������� �������������� ���� �� ��������� ������� ���� ������� 
--������ �� ��������� � ������� UnitPrice ����. ����������� ������� ������ ���� ���� ������ 
--� ����� �������� � ��������� ������� 'Totals'.
SELECT CONVERT(MONEY, ROUND(SUM(UnitPrice * Discount), 2), 1) AS 'Totals'
FROM [Northwind].[dbo].[Order Details];

--5.2	�� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� 
--(�.�. � ������� ShippedDate ��� �������� ���� ��������). ������������ ��� ���� ������� 
--������ �������� COUNT. �� ������������ ����������� WHERE � GROUP.
SELECT COUNT(CASE
			WHEN ShippedDate IS NULL THEN 1
			END) AS 'Date is null'
FROM [Northwind].[dbo].[Orders];

--5.3	�� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������. 
--������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.
SELECT COUNT(DISTINCT CustomerID) AS 'CustomerID'
FROM [Northwind].[dbo].[Orders];

--6.1	�� ������� Orders ����� ���������� ������� � ������������ �� �����. � ����������� ������� 
--���� ����������� ��� ������� c ���������� Year � Total. �������� ����������� ������, ������� 
--��������� ���������� ���� �������.
SELECT ShippedDate AS 'Year', 
COUNT(ShippedDate) AS 'Total'
FROM [Northwind].[dbo].[Orders]
GROUP BY ShippedDate;

SELECT COUNT(ShippedDate) AS 'Total'
FROM [Northwind].[dbo].[Orders];

--6.2	�� ������� Orders ����� ���������� �������, c�������� ������ ���������. ����� ��� ���������� 
--�������� � ��� ����� ������ � ������� Orders, ��� � ������� EmployeeID ������ �������� ��� ������� 
--��������. � ����������� ������� ���� ����������� ������� � ������ �������� (������ ������������� 
--��� ���������� ������������� LastName & FirstName. ��� ������ LastName & FirstName ������ ���� 
--�������� ��������� �������� � ������� ��������� �������. ����� �������� ������ ������ ������������ 
--����������� �� EmployeeID.) � ��������� ������� �Seller� � ������� c ����������� ������� 
--����������� � ��������� 'Amount'. ���������� ������� ������ ���� ����������� �� �������� 
--���������� �������. 

SELECT 
    (SELECT CONCAT(E.[LastName],' ', E.[FirstName]) 
        FROM [Northwind].[dbo].[Employees] E
        WHERE E.[EmployeeID] = O.[EmployeeID]) 
     AS 'Seller',
	 COUNT(O.[OrderId]) AS 'Amount'
FROM [Northwind].[dbo].[Orders] O 
GROUP BY O.[EmployeeID]
ORDER BY 'Amount' DESC;

--6.3	�� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� 
--����������. ���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. � ����������� 
--������� ���� ����������� ������� � ������ �������� (�������� ������� �Seller�), ������� � ������ 
--���������� (�������� ������� �Customer�)  � ������� c ����������� ������� ����������� � ��������� 
--'Amount'. � ������� ���������� ������������ ����������� �������� ����� T-SQL ��� ������ � 
--���������� GROUP (���� �� �������� ������� �������� ������ �ALL� � ����������� �������). 
--����������� ������ ���� ������� �� ID �������� � ����������. ���������� ������� ������ ���� 
--����������� �� ��������, ���������� � �� �������� ���������� ������. � ����������� ������ ���� 
--������� ���������� �� ��������. �.�. � ������������� ������ ������ �������������� ������������� 
--� ���������� � �������� �������� ��� ������� ���������� ��������� �������:
--Seller	Customer	Amount
--ALL 		ALL		    <����� ����� ������>
--<���>		ALL			<����� ������ ��� ������� ��������>
--ALL		<���>		<����� ������ ��� ������� ����������>
--<���>		<���>		<����� ������ ������� �������� ��� �������� ����������>

DECLARE 
    @year INT = 1998;
SELECT 
CASE
	WHEN E.[LastName] IS NULL THEN 'ALL'
	ELSE E.[LastName]
END AS 'Seller',
CASE
	WHEN C.[ContactName] IS NULL THEN 'ALL'
	ELSE C.[ContactName]
END AS 'Customer',
	COUNT(O.[OrderID]) AS 'Amount'
FROM [Northwind].[dbo].[Orders] O
JOIN [Northwind].[dbo].[Employees] E
	ON O.[EmployeeID] = E.[EmployeeID]
JOIN [Northwind].[dbo].[Customers] C
	ON O.[CustomerID] = C.[CustomerID]
WHERE YEAR(O.[OrderDate]) = @year
GROUP BY CUBE(E.[LastName], C.[ContactName])
ORDER BY 'Amount' DESC;

--6.4	����� ����������� � ���������, ������� ����� � ����� ������. ���� � ������ ����� ������ ���� 
--��� ��������� ��������� ��� ������ ���� ��� ��������� �����������, �� ���������� � ����� 
--���������� � ��������� �� ������ �������� � �������������� �����. �� ������������ ����������� JOIN.
--� ����������� ������� ���������� ������� ��������� ��������� ��� ����������� �������: �Person�, 
--�Type� (����� ���� �������� ������ �Customer� ���  �Seller� � ��������� �� ���� ������), �City�. 
--������������� ���������� ������� �� ������� �City� � �� �Person�.

SELECT 
	C.[ContactName] AS 'Person',
	C.[City] AS 'City',
	'Customer' AS 'Type'
FROM [Northwind].[dbo].[Customers] C
WHERE C.[City] IN (SELECT DISTINCT E.[City]
				FROM [Northwind].[dbo].[Employees] E)
UNION
SELECT 
	E.[LastName] AS 'Person',
	E.[City]	     AS 'City',
	'Seller' AS 'Type'
FROM [Northwind].[dbo].[Employees] E
WHERE E.[City] IN (SELECT DISTINCT C.[City]
				FROM [Northwind].[dbo].[Customers] C)
ORDER BY 'City', 'Person';

--6.5	����� ���� �����������, ������� ����� � ����� ������. � ������� ������������ ���������� 
--������� Customers c ����� - ��������������. ��������� ������� CustomerID � City. ������ �� ������ 
--����������� ����������� ������. ��� �������� �������� ������, ������� ����������� ������, ������� 
--����������� ����� ������ ���� � ������� Customers. ��� �������� ��������� ������������ �������

SELECT DISTINCT
    CL.[CustomerID] AS 'CustomerID',
	CL.[City] AS 'City'
FROM [Northwind].[dbo].[Customers] CL
    JOIN [Northwind].[dbo].[Customers] CR 
        ON CL.[CustomerID] <> CR.[CustomerID] AND CL.[City] = CR.[City]
ORDER BY CL.[CustomerID];

SELECT City
FROM [Northwind].[dbo].[Customers]
GROUP BY City 
HAVING COUNT(City) > 1;

--6.6	�� ������� Employees ����� ��� ������� �������� ��� ������������, �.�. ���� �� ������ �������. 
--��������� ������� � ������� 'User Name' (LastName) � 'Boss'. � �������� ������ ���� ��������� 
--����� �� ������� LastName. ��������� �� ��� �������� � ���� �������?
--�����: ���, �.�. ��� �������� � ������ Fuller ��� �����

SELECT 
    E.[LastName] AS 'User name',
	(SELECT M.[LastName] 
        FROM [Northwind].[dbo].[Employees] M 
        WHERE M.[EmployeeID] = E.[ReportsTo]) 
    AS 'Boss'
FROM [Northwind].[dbo].[Employees] E;

--7.1	���������� ���������, ������� ����������� ������ 'Western' (������� Region). ���������� 
--������� ������ ����������� ��� ����: 'LastName' �������� � �������� ������������� ���������� 
--('TerritoryDescription' �� ������� Territories). ������ ������ ������������ JOIN � ����������� 
--FROM. ��� ����������� ������ ����� ��������� Employees � Territories ���� ������������ ����������� 
--��������� ��� ���� Northwind.

SELECT DISTINCT 
    EmployeesT.[LastName] AS 'Last Name',
	T.[TerritoryDescription] AS 'Territories'
FROM [Northwind].[dbo].[Employees] EmployeesT
        INNER JOIN [Northwind].[dbo].[EmployeeTerritories] ET 
            ON EmployeesT.[EmployeeID] = ET.[EmployeeID]
        INNER JOIN [Northwind].[dbo].[Territories] T 
            ON ET.[TerritoryID] = T.[TerritoryID]
        INNER JOIN [Northwind].[dbo].[Region] R 
            ON R.[RegionID] = T.[RegionID]
WHERE R.[RegionDescription] = 'Western';

--8.1	��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� 
--���������� �� ������� �� ������� Orders. ������� �� ��������, ��� � ��������� ���������� ��� 
--�������, �� ��� ����� ������ ���� �������� � ����������� �������. ����������� ���������� ������� 
--�� ����������� ���������� �������.

SELECT C.[ContactName] AS 'ContactName',
		COUNT(O.[OrderID]) AS 'OrdersCount'
FROM [Northwind].[dbo].[Customers] C 
    LEFT JOIN [Northwind].[dbo].[Orders] O 
        ON C.[CustomerID] = O.[CustomerID]
GROUP BY C.[CustomerID], C.[ContactName]
ORDER BY 'OrdersCount';

--9.1	��������� ���� ����������� ������� CompanyName � ������� Suppliers, � ������� ��� ���� �� 
--������ �������� �� ������ (UnitsInStock � ������� Products ����� 0). ������������ ��������� 
--SELECT ��� ����� ������� � �������������� ��������� IN. ����� �� ������������ ������ ��������� 
--IN �������� '=' ?
--�����: ���, �.�. �������� '=' ���������� ������ ���� ��������, ����� ��� �������� IN ���������� ������ 
--��������. ��� ��� ��� ��������� ������ ���� �����������, � ������� ��� ���� �� ������ �������� �� ������

SELECT CompanyName
FROM [Northwind].[dbo].[Suppliers]
WHERE SupplierID IN
	(SELECT SupplierID 
	FROM [Northwind].[dbo].[Products]
	WHERE UnitsInStock = 0);

--10.1	��������� ���� ���������, ������� ����� ����� 150 �������. ������������ ��������� 
--��������������� SELECT.

SELECT EmployeeID  
FROM [Northwind].[dbo].[Employees]
WHERE (SELECT COUNT(OrderID) 
        FROM [Northwind].[dbo].[Orders] 
        WHERE EmployeeID = EmployeeID) > 150;

--11.1	��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ 
--(��������� �� ������� Orders). ������������ ��������������� SELECT � �������� EXISTS.

SELECT ContactName 
FROM [Northwind].[dbo].[Customers]
WHERE EXISTS 
	(SELECT EmployeeID 
	FROM [Northwind].[dbo].[Orders]
	WHERE ShippedDate IS NULL);
		
--12.1 ��� ������������ ����������� ��������� Employees ��������� �� ������� Employees ������ 
--������ ��� ���� ��������, � ������� ���������� ������� Employees (������� LastName ) �� ���� 
--�������. ���������� ������ ������ ���� ������������ �� �����������.
	
SELECT DISTINCT LEFT(LastName, 1) AS 'Name'
FROM [Northwind].[dbo].[Employees]
ORDER BY 'Name';	

--13.1
DECLARE
@value INT = 1998;

EXEC GreatestOrders @YEAR = @value, @COUNT = 7

SELECT 
	CONCAT(E.[FirstName], ' ', E.[LastName]) AS 'Name',
	OD.[OrderID] AS 'Order ID',
	OD.[UnitPrice] * OD.Quantity * (1 - OD.[Discount]) AS 'Price'
FROM [Northwind].[dbo].[Employees] AS E
JOIN [Northwind].[dbo].[Orders] AS O
	ON E.[EmployeeID] = O.[EmployeeID]
JOIN [Northwind].[dbo].[Order Details] AS OD
	ON O.[OrderID] = OD.[OrderID]
WHERE YEAR(O.[OrderDate]) = @value
ORDER BY [Price] DESC;

--13.2

EXEC ShippedOrdersDiff @DAY = 7

--13.3
EXEC SubordinationInfo @empID = 2

--13.4
--�������� �������, ������� ����������, ���� �� � �������� �����������. 
--���������� ��� ������ BIT. 
--� �������� �������� ��������� ������� ������������ EmployeeID. 
--�������� ������� IsBoss. 
--������������������ ������������� ������� ��� ���� ��������� �� ������� Employees.

DECLARE
@EmployeeID INT = 2;

SELECT CONCAT(E.[FirstName], ' ', E.[LastName]) AS 'EmployeeName',
CASE WHEN dbo.IsBoss(@EmployeeID) = 1
THEN 'True'
ELSE 'False'
END as [IsBoss]
FROM [Northwind].[dbo].[Employees] AS E;