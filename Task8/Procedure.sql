USE Northwind
GO

--13.1	Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за 
--определенный год. В результатах не может быть несколько заказов одного продавца, должен быть 
--только один и самый крупный. В результатах запроса должны быть выведены следующие колонки: 
--колонка с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), номер 
--заказа и его стоимость. В запросе надо учитывать Discount при продаже товаров. Процедуре 
--передается год, за который надо сделать отчет, и количество возвращаемых записей. Результаты 
--запроса должны быть упорядочены по убыванию суммы заказа. Процедура должна быть реализована 
--с использованием оператора SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции соответственно 
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

--13.2	Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному 
--сроку доставки в днях (разница между OrderDate и ShippedDate).  В результатах должны быть 
--возвращены заказы, срок которых превышает переданное значение или еще недоставленные заказы. 
--Значению по умолчанию для передаваемого срока 35 дней. Название процедуры ShippedOrdersDiff. 
--Процедура должна высвечивать следующие колонки: OrderID, OrderDate, ShippedDate, ShippedDelay 
--(разность в днях между ShippedDate и OrderDate), SpecifiedDelay (переданное в процедуру значение).
--Необходимо продемонстрировать использование этой процедуры.

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
--Написать процедуру, которая высвечивает всех подчиненных заданного продавца, 
--как непосредственных, так и подчиненных его подчиненных. 
--В качестве входного параметра функции используется EmployeeID. 
--Необходимо распечатать имена подчиненных 
--и выровнять их в тексте (использовать оператор PRINT) согласно иерархии подчинения. 
--Продавец, для которого надо найти подчиненных также должен быть высвечен. 
--Название процедуры SubordinationInfo. 
--В качестве алгоритма для решения этой задачи надо использовать пример, 
--приведенный в Books Online и рекомендованный Microsoft для решения подобного типа задач. 
--Продемонстрировать использование процедуры.
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
--Написать функцию, которая определяет, есть ли у продавца подчиненные. 
--Возвращает тип данных BIT. 
--В качестве входного параметра функции используется EmployeeID. 
--Название функции IsBoss. 
--Продемонстрировать использование функции для всех продавцов из таблицы Employees.
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
