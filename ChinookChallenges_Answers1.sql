-- On the Chinook DB, practice writing queries with the following exercises

-- List all customers (full name, customer id, and country) who are not in the USA

SELECT firstName, lastName, CustomerId, Country
FROM Customer
WHERE Country != 'USA';


-- List all customers from Brazil

SELECT * 
FROM Customer
WHERE Country = 'Brazil';


-- List all sales agents

SELECT Title, lastName, FirstName
from Employee
WHERE Title LIKE '%agent%'

-- Retrieve a list of all countries in billing addresses on invoices
SELECT DISTINCT BillingCountry
FROM Invoice;

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
    -- (challenge: find the invoice count sales total for every year using one query)

SELECT COUNT(InvoiceDate)
FROM Invoice
WHERE InvoiceDate LIKE '%2009%';

-- how many line items were there for invoice #37



-- how many invoices per country?

SELECT COUNT(InvoiceId), BillingCountry
From Invoice
GROUP BY BillingCountry;


-- Retrieve the total sales per country, ordered by the highest total sales first.

SELECT SUM(Total) as Sales, BillingCountry
FROM Invoice
GROUP BY BillingCountry 
ORDER BY Sales DESC;


-- JOINS CHALLENGES
-- Show all invoices of customers from brazil (mailing address not billing)

SELECT InvoiceID
FROM Invoice
JOIN Customer
ON Customer.CustomerId = Invoice.CustomerId
WHERE Customer.Country = 'Brazil';

-- Show all invoices together with the name of the sales agent for each one
SELECT InvoiceID, Employee.FirstName, Employee.LastName
FROM Invoice
JOIN Customer
ON Customer.CustomerID = Invoice.CustomerId
JOIN Employee
ON Employee.EmployeeID = Customer.SupportRepId
WHERE Title LIKE '%agent%'


-- Show all playlists ordered by the total number of tracks they have

SELECT Playlist.PlaylistId, 
FROM
JOIN
ON
GROUP BY
ORDER BY

-- Which sales agent made the most sales in 2009?

-- How many customers are assigned to each sales agent?

-- Which track was purchased the most ing 20010?

-- Show the top three best selling artists.

-- Which customers have the same initials as at least one other customer?



-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?

-- Artist has ArtistID and NAME
-- Track has AlbumID, GenreID
-- Album has ArtistID and AlbumID
-- Genre has GenreID and Name (Latin = 7)

SELECT COUNT(DISTINCT Artist.Name + Genre.Name)
FROM Track 
INNER JOIN Album on Track.AlbumId = Album.AlbumID
INNER JOIN Artist on Album.ArtistID = Artist.ArtistId
INNER JOIN Genre on Track.GenreID = Genre.GenreId
WHERE Genre.Name != 'Latin';

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.


-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.
