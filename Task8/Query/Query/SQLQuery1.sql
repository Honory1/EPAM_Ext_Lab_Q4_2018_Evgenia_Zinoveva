--1.1	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� 
--(������� ShippedDate) ������������ � ������� ���������� � ShipVia >= 2. 
--������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������, 
--�������� ����������� ������ �Writing International Transact-SQL Statements� � 
--Books Online ������ �Accessing and Changing Relational Data Overview�. 
--���� ����� ������������ ����� ��� ���� �������. ������ ������ ����������� ������ 
--������� OrderID, ShippedDate � ShipVia. 
--�������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate. 
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

SELECT OrderID AS 'Order Number', ShippedDate AS 'Shipped Date'
FROM [Northwind].[dbo].[Orders]
WHERE ShippedDate > '1998-05-06' OR ShippedDate IS NULL;

--2.1	������� �� ������� Customers ���� ����������, ����������� � USA � Canada.
--������ ������� � ������ ������� ��������� IN. ����������� ������� � ������ ������������ 
--� ��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ���������� 
--� �� ����� ����������.
SELECT ContactName, Country
FROM Northwind.dbo.Customers 
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country ASC;

--2.2	������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. 
--������ ������� � ������� ��������� IN. ����������� ������� � ������ ������������ � 
--��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ����������.
SELECT ContactName, Country
FROM Northwind.dbo.Customers 
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
WHERE ProductName LIKE '%chocolade' OR ProductName LIKE '%cho�olade';

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
SELECT COUNT(distinct CustomerID) AS 'CustomerID'
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

SELECT EmployeeID AS 'Seller'
FROM [Northwind].[dbo].[Orders]
GROUP BY EmployeeID
HAVING EmployeeID IS NOT NULL;