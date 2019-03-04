USE Northwind
GO

--13.1	�������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� 
--������������ ���. � ����������� �� ����� ���� ��������� ������� ������ ��������, ������ ���� 
--������ ���� � ����� �������. � ����������� ������� ������ ���� �������� ��������� �������: 
--������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), ����� 
--������ � ��� ���������. � ������� ���� ��������� Discount ��� ������� �������. ��������� 
--���������� ���, �� ������� ���� ������� �����, � ���������� ������������ �������. ���������� 
--������� ������ ���� ����������� �� �������� ����� ������. ��������� ������ ���� ����������� 
--� �������������� ��������� SELECT � ��� ������������� ��������. �������� ������� �������������� 
--GreatestOrders. 

CREATE OR ALTER PROCEDURE [dbo].[GreatestOrders](@YEAR INT, @COUNT INT)
AS BEGIN
SELECT 
	DISTINCT TOP(@COUNT) PAM.[Name],
	PAM.[Order ID],
	MAX(PAM.[Price]) AS 'Price'
	 FROM
(SELECT 
	CONCAT(E.[FirstName], ' ', E.[LastName]) AS 'Name',
	OD.[OrderID] AS 'Order ID',
	OD.[UnitPrice] * OD.Quantity * (1 - OD.[Discount]) AS 'Price'
FROM [Northwind].[dbo].[Employees] AS E
JOIN [Northwind].[dbo].[Orders] AS O
	ON E.[EmployeeID] = O.[EmployeeID]
JOIN [Northwind].[dbo].[Order Details] AS OD
	ON O.[OrderID] = OD.[OrderID]
WHERE YEAR(O.[OrderDate]) = @YEAR)
AS PAM
GROUP BY PAM.[Name]
--ORDER BY PAM.[Price]
END;
GO

--13.2	�������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� 
--����� �������� � ���� (������� ����� OrderDate � ShippedDate).  � ����������� ������ ���� 
--���������� ������, ���� ������� ��������� ���������� �������� ��� ��� �������������� ������. 
--�������� �� ��������� ��� ������������� ����� 35 ����. �������� ��������� ShippedOrdersDiff. 
--��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate, ShippedDelay 
--(�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay (���������� � ��������� ��������).
--���������� ������������������ ������������� ���� ���������.

CREATE OR ALTER PROCEDURE [dbo].[ShippedOrdersDiff](@DAY INT = 35)
AS BEGIN
SELECT 
	O.[OrderID],
	O.[OrderDate],
	O.[ShippedDate],
	DAY(O.[ShippedDate] - O.[OrderDate]) AS 'ShippedDelay',
	@DAY AS 'SpecifiedDelay'
FROM [Northwind].[dbo].[Orders] AS O
WHERE DAY(O.[ShippedDate] - O.[OrderDate]) > @DAY OR O.[ShippedDate] IS NULL
END;
GO

--/*13.3
--�������� ���������, ������� ����������� ���� ����������� ��������� ��������, 
--��� ����������������, ��� � ����������� ��� �����������. 
--� �������� �������� ��������� ������� ������������ EmployeeID. 
--���������� ����������� ����� ����������� 
--� ��������� �� � ������ (������������ �������� PRINT) �������� �������� ����������. 
--��������, ��� �������� ���� ����� ����������� ����� ������ ���� ��������. 
--�������� ��������� SubordinationInfo. 
--� �������� ��������� ��� ������� ���� ������ ���� ������������ ������, 
--����������� � Books Online � ��������������� Microsoft ��� ������� ��������� ���� �����. 
--������������������ ������������� ���������.
--*/

GO
CREATE OR ALTER PROCEDURE SubordinationInfo (@empID int)
AS
BEGIN
SELECT CONCAT(Emp.FirstName, ' ', Emp.LastName) AS 'Employees name'
FROM [Northwind].[dbo].[Employees] as Emp
WHERE Emp.ReportsTo IN
	(SELECT E.EmployeeID
	FROM [Northwind].[dbo].[Employees] as E
	WHERE E.ReportsTo = @empID) OR
	Emp.ReportsTo = @empID
END;
GO

--/*13.4
--�������� �������, ������� ����������, ���� �� � �������� �����������. 
--���������� ��� ������ BIT. 
--� �������� �������� ��������� ������� ������������ EmployeeID. 
--�������� ������� IsBoss. 
--������������������ ������������� ������� ��� ���� ��������� �� ������� Employees.
--*/
CREATE OR ALTER FUNCTION dbo.IsBoss(@empID AS int)
RETURNS BIT
AS
BEGIN
RETURN
(SELECT CASE WHEN EXISTS
	(SELECT *
	FROM [Northwind].[dbo].[Employees] as E
	WHERE E.ReportsTo = @empID)
	THEN 1
	ELSE 0
	END)
END;
GO
