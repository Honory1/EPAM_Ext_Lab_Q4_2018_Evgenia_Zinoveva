--1.1	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года 
--(колонка ShippedDate) включительно и которые доставлены с ShipVia >= 2. 
--Формат указания даты должен быть верным при любых региональных настройках, 
--согласно требованиям статьи “Writing International Transact-SQL Statements” в 
--Books Online раздел “Accessing and Changing Relational Data Overview”. 
--Этот метод использовать далее для всех заданий. Запрос должен высвечивать только 
--колонки OrderID, ShippedDate и ShipVia. 
--Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate. 
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

SELECT OrderID AS 'Order Number', ShippedDate AS 'Shipped Date'
FROM [Northwind].[dbo].[Orders]
WHERE ShippedDate > '1998-05-06' OR ShippedDate IS NULL;

--2.1	Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada.
--Запрос сделать с только помощью оператора IN. Высвечивать колонки с именем пользователя 
--и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков 
--и по месту проживания.
SELECT ContactName, Country
FROM Northwind.dbo.Customers 
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country ASC;

--2.2	Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. 
--Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя и 
--названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков.
SELECT ContactName, Country
FROM Northwind.dbo.Customers 
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
WHERE ProductName LIKE '%chocolade' OR ProductName LIKE '%choсolade';

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
SELECT COUNT(distinct CustomerID) AS 'CustomerID'
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

SELECT EmployeeID AS 'Seller'
FROM [Northwind].[dbo].[Orders]
GROUP BY EmployeeID
HAVING EmployeeID IS NOT NULL;