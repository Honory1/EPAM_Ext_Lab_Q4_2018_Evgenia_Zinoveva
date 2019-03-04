--1.1	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года 
--(колонка ShippedDate) включительно и которые доставлены с ShipVia >= 2. 
--Формат указания даты должен быть верным при любых региональных настройках, 
--согласно требованиям статьи “Writing International Transact-SQL Statements” в 
--Books Online раздел “Accessing and Changing Relational Data Overview”. 
--Этот метод использовать далее для всех заданий. Запрос должен высвечивать только 
--колонки OrderID, ShippedDate и ShipVia. 
--Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate. 
--Ответ: Потому что функция DATEPART возвращает только значения типа int

SELECT OrderID, ShippedDate, ShipVia 
FROM [Northwind].[dbo].[Orders]
WHERE DATEPART(yyyy, ShippedDate) >= N'1998' AND 
DATEPART(mm,ShippedDate) >= N'05' AND DATEPART(dd,ShippedDate) >= N'06' 
AND ShipVia >= '2';

--1.2	Написать запрос, который выводит только недоставленные заказы из таблицы Orders.
-- В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку 
-- ‘Not Shipped’ – использовать системную функцию CASЕ. Запрос должен высвечивать только
--  колонки OrderID и ShippedDate.
SELECT OrderID, ShippedDate =
CASE  
WHEN ShippedDate IS NULL THEN 'Not Shipped'
END 
FROM [Northwind].[dbo].[Orders]
WHERE ShippedDate IS NULL;

--1.3	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года
-- (ShippedDate) не включая эту дату или которые еще не доставлены. В запросе должны
--  высвечиваться только колонки OrderID (переименовать в Order Number) и ShippedDate 
--  (переименовать в Shipped Date). В результатах запроса высвечивать для колонки
--   ShippedDate вместо значений NULL строку ‘Not Shipped’, для остальных значений 
--   высвечивать дату в формате по умолчанию.

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

--2.1	Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada.
--Запрос сделать с только помощью оператора IN. Высвечивать колонки с именем пользователя 
--и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков 
--и по месту проживания.

SELECT ContactName, Country
FROM [Northwind].[dbo].[Customers] 
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country ASC;

--2.2	Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. 
--Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя и 
--названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков.
SELECT ContactName, Country
FROM [Northwind].[dbo].[Customers] 
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName ASC;

--2.3	Выбрать из таблицы Customers все страны, в которых проживают заказчики. 
--Страна должна быть упомянута только один раз и список отсортирован по убыванию. 
--Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса.
SELECT DISTINCT Country
FROM [Northwind].[dbo].[Customers] 
ORDER BY Country DESC; 

--3.1	Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться), 
--где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity 
--в таблице Order Details. Использовать оператор BETWEEN. Запрос должен высвечивать только 
--колонку OrderID.
SELECT DISTINCT OrderID
FROM [Northwind].[dbo].[Order Details]
WHERE Quantity BETWEEN 3 AND 10;

--3.2	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается 
--на буквы из диапазона b и g. Использовать оператор BETWEEN. Проверить, что в результаты 
--запроса попадает Germany. Запрос должен высвечивать только колонки CustomerID и Country 
--и отсортирован по Country.
SELECT CustomerID, Country
FROM [Northwind].[dbo].[Customers]
WHERE Country BETWEEN 'b' AND 'h'
ORDER BY Country ASC;

--3.3	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на 
--буквы из диапазона b и g, не используя оператор BETWEEN. С помощью опции “Execution Plan” 
--определить какой запрос предпочтительнее 3.2 или 3.3 – для этого надо ввести в скрипт выполнение 
--текстового Execution Plan-a для двух этих запросов, результаты выполнения Execution Plan надо 
--ввести в скрипт в виде комментария и по их результатам дать ответ на вопрос – по какому 
--параметру было проведено сравнение. Запрос должен высвечивать только колонки CustomerID и 
--Country и отсортирован по Country.
--Ответ: Не поняла, как ввести скрип в текстовой формат, но результат выполнения Execution Plan
--показал, что запросы 3.2 и 3.3 эквивалентны
SELECT CustomerID, Country
FROM [Northwind].[dbo].[Customers]
WHERE Country > 'b' AND Country < 'h'
ORDER BY Country ASC;

--4.1	В таблице Products найти все продукты (колонка ProductName), где встречается 
--подстрока 'chocolade'. Известно, что в подстроке 'chocolade' может быть изменена одна 
--буква 'c' в середине - найти все продукты, которые удовлетворяют этому условию. 
--Подсказка: результаты запроса должны высвечивать 2 строки.
SELECT ProductName
FROM [Northwind].[dbo].[Products]
WHERE ProductName LIKE '%cho_olade%';

--5.1	Найти общую сумму всех заказов из таблицы Order Details с учетом количества 
--закупленных товаров и скидок по ним. Результат округлить до сотых и высветить в стиле 1 
--для типа данных money.  Скидка (колонка Discount) составляет процент из стоимости для 
--данного товара. Для определения действительной цены на проданный продукт надо вычесть 
--скидку из указанной в колонке UnitPrice цены. Результатом запроса должна быть одна запись 
--с одной колонкой с названием колонки 'Totals'.
SELECT CONVERT(MONEY, ROUND(SUM(UnitPrice * Discount), 2), 1) AS 'Totals'
FROM [Northwind].[dbo].[Order Details];

--5.2	По таблице Orders найти количество заказов, которые еще не были доставлены 
--(т.е. в колонке ShippedDate нет значения даты доставки). Использовать при этом запросе 
--только оператор COUNT. Не использовать предложения WHERE и GROUP.
SELECT COUNT(CASE
			WHEN ShippedDate IS NULL THEN 1
			END) AS 'Date is null'
FROM [Northwind].[dbo].[Orders];

--5.3	По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы. 
--Использовать функцию COUNT и не использовать предложения WHERE и GROUP.
SELECT COUNT(DISTINCT CustomerID) AS 'CustomerID'
FROM [Northwind].[dbo].[Orders];

--6.1	По таблице Orders найти количество заказов с группировкой по годам. В результатах запроса 
--надо высвечивать две колонки c названиями Year и Total. Написать проверочный запрос, который 
--вычисляет количество всех заказов.
SELECT ShippedDate AS 'Year', 
COUNT(ShippedDate) AS 'Total'
FROM [Northwind].[dbo].[Orders]
GROUP BY ShippedDate;

SELECT COUNT(ShippedDate) AS 'Total'
FROM [Northwind].[dbo].[Orders];

--6.2	По таблице Orders найти количество заказов, cделанных каждым продавцом. Заказ для указанного 
--продавца – это любая запись в таблице Orders, где в колонке EmployeeID задано значение для данного 
--продавца. В результатах запроса надо высвечивать колонку с именем продавца (Должно высвечиваться 
--имя полученное конкатенацией LastName & FirstName. Эта строка LastName & FirstName должна быть 
--получена отдельным запросом в колонке основного запроса. Также основной запрос должен использовать 
--группировку по EmployeeID.) с названием колонки ‘Seller’ и колонку c количеством заказов 
--высвечивать с названием 'Amount'. Результаты запроса должны быть упорядочены по убыванию 
--количества заказов. 

SELECT 
    (SELECT CONCAT(E.[LastName],' ', E.[FirstName]) 
        FROM [Northwind].[dbo].[Employees] E
        WHERE E.[EmployeeID] = O.[EmployeeID]) 
     AS 'Seller',
	 COUNT(O.[OrderId]) AS 'Amount'
FROM [Northwind].[dbo].[Orders] O 
GROUP BY O.[EmployeeID]
ORDER BY 'Amount' DESC;

--6.3	По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого 
--покупателя. Необходимо определить это только для заказов сделанных в 1998 году. В результатах 
--запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’), колонку с именем 
--покупателя (название колонки ‘Customer’)  и колонку c количеством заказов высвечивать с названием 
--'Amount'. В запросе необходимо использовать специальный оператор языка T-SQL для работы с 
--выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах запроса). 
--Группировки должны быть сделаны по ID продавца и покупателя. Результаты запроса должны быть 
--упорядочены по продавцу, покупателю и по убыванию количества продаж. В результатах должна быть 
--сводная информация по продажам. Т.е. в резульирующем наборе должны присутствовать дополнительно 
--к информации о продажах продавца для каждого покупателя следующие строчки:
--Seller	Customer	Amount
--ALL 		ALL		    <общее число продаж>
--<имя>		ALL			<число продаж для данного продавца>
--ALL		<имя>		<число продаж для данного покупателя>
--<имя>		<имя>		<число продаж данного продавца для даннного покупателя>

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

--6.4	Найти покупателей и продавцов, которые живут в одном городе. Если в городе живут только один 
--или несколько продавцов или только один или несколько покупателей, то информация о таких 
--покупателя и продавцах не должна попадать в результирующий набор. Не использовать конструкцию JOIN.
--В результатах запроса необходимо вывести следующие заголовки для результатов запроса: ‘Person’, 
--‘Type’ (здесь надо выводить строку ‘Customer’ или  ‘Seller’ в завимости от типа записи), ‘City’. 
--Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.

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

--6.5	Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение 
--таблицы Customers c собой - самосоединение. Высветить колонки CustomerID и City. Запрос не должен 
--высвечивать дублируемые записи. Для проверки написать запрос, который высвечивает города, которые 
--встречаются более одного раза в таблице Customers. Это позволит проверить правильность запроса

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

--6.6	По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. 
--Высветить колонки с именами 'User Name' (LastName) и 'Boss'. В колонках должны быть высвечены 
--имена из колонки LastName. Высвечены ли все продавцы в этом запросе?
--Ответ: Нет, т.к. для продавца с именем Fuller нет босса

SELECT 
    E.[LastName] AS 'User name',
	(SELECT M.[LastName] 
        FROM [Northwind].[dbo].[Employees] M 
        WHERE M.[EmployeeID] = E.[ReportsTo]) 
    AS 'Boss'
FROM [Northwind].[dbo].[Employees] E;

--7.1	Определить продавцов, которые обслуживают регион 'Western' (таблица Region). Результаты 
--запроса должны высвечивать два поля: 'LastName' продавца и название обслуживаемой территории 
--('TerritoryDescription' из таблицы Territories). Запрос должен использовать JOIN в предложении 
--FROM. Для определения связей между таблицами Employees и Territories надо использовать графические 
--диаграммы для базы Northwind.

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

--8.1	Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное 
--количество их заказов из таблицы Orders. Принять во внимание, что у некоторых заказчиков нет 
--заказов, но они также должны быть выведены в результатах запроса. Упорядочить результаты запроса 
--по возрастанию количества заказов.

SELECT C.[ContactName] AS 'ContactName',
		COUNT(O.[OrderID]) AS 'OrdersCount'
FROM [Northwind].[dbo].[Customers] C 
    LEFT JOIN [Northwind].[dbo].[Orders] O 
        ON C.[CustomerID] = O.[CustomerID]
GROUP BY C.[CustomerID], C.[ContactName]
ORDER BY 'OrdersCount';

--9.1	Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя бы 
--одного продукта на складе (UnitsInStock в таблице Products равно 0). Использовать вложенный 
--SELECT для этого запроса с использованием оператора IN. Можно ли использовать вместо оператора 
--IN оператор '=' ?
--Ответ: Нет, т.к. оператор '=' возвращает только одно значение, тогда как оператор IN возвращает список 
--значений. Нам как раз необходим список всех поставщиков, у которых нет хотя бы одного продукта на складе

SELECT CompanyName
FROM [Northwind].[dbo].[Suppliers]
WHERE SupplierID IN
	(SELECT SupplierID 
	FROM [Northwind].[dbo].[Products]
	WHERE UnitsInStock = 0);

--10.1	Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный 
--коррелированный SELECT.

SELECT EmployeeID  
FROM [Northwind].[dbo].[Employees]
WHERE (SELECT COUNT(OrderID) 
        FROM [Northwind].[dbo].[Orders] 
        WHERE EmployeeID = EmployeeID) > 150;

--11.1	Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа 
--(подзапрос по таблице Orders). Использовать коррелированный SELECT и оператор EXISTS.

SELECT ContactName 
FROM [Northwind].[dbo].[Customers]
WHERE EXISTS 
	(SELECT EmployeeID 
	FROM [Northwind].[dbo].[Orders]
	WHERE ShippedDate IS NULL);
		
--12.1 Для формирования алфавитного указателя Employees высветить из таблицы Employees список 
--только тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName ) из этой 
--таблицы. Алфавитный список должен быть отсортирован по возрастанию.
	
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
--Написать функцию, которая определяет, есть ли у продавца подчиненные. 
--Возвращает тип данных BIT. 
--В качестве входного параметра функции используется EmployeeID. 
--Название функции IsBoss. 
--Продемонстрировать использование функции для всех продавцов из таблицы Employees.

DECLARE
@EmployeeID INT = 2;

SELECT CONCAT(E.[FirstName], ' ', E.[LastName]) AS 'EmployeeName',
CASE WHEN dbo.IsBoss(@EmployeeID) = 1
THEN 'True'
ELSE 'False'
END as [IsBoss]
FROM [Northwind].[dbo].[Employees] AS E;