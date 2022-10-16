DROP DATABASE EFlessonDB
GO

CREATE DATABASE EFlessonDB
GO

USE EFlessonDB
GO
CREATE TABLE Customers
(
	Id INT IDENTITY PRIMARY KEY,
	CustomerName NVARCHAR(50) NOT NULL,
	Discount FLOAT DEFAULT 0
)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeName NVARCHAR(50) NOT NULL
)

CREATE TABLE Products
(
	Id INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR(100) NOT NULL,
	Price MONEY NOT NULL DEFAULT 0
)

CREATE TABLE Orders
(
	Id INT IDENTITY PRIMARY KEY,
	OrderData DATE NOT NULL,
	EmployeeId int FOREIGN KEY REFERENCES Employees(Id),
	CustomerId int FOREIGN KEY REFERENCES Customers(Id),

)

CREATE TABLE OrderProducts
(
	Id INT IDENTITY PRIMARY KEY,
	OrderId INT FOREIGN KEY REFERENCES Orders(Id),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	ProductCount INT NOT NULL DEFAULT 0
)

INSERT INTO Products (ProductName, Price)
VALUES ('bread', 18.70),
('eggs', 55.30),
('milk', 28.15),
('butter', 48.55),
('cheese', 245.70)

INSERT INTO Customers (CustomerName)
VALUES ('Bob'),
('John'),
('Ceed'),
('Jack'),
('Norm')

INSERT INTO Employees (EmployeeName)
VALUES ('Cris'),
('Jeeny'),
('Carra'),
('Lisa'),
('Anna')

INSERT INTO Orders (OrderData, EmployeeId, CustomerId)
VALUES (GETDATE(), 1, 1),
(GETDATE(), 2, 2),
(GETDATE(), 3, 3)

INSERT INTO OrderProducts (OrderId, ProductId, ProductCount)
VALUES (1, 1, 2),
(1, 2, 1),
(2, 3, 2),
(2, 4, 3),
(3, 5, 2),
(3, 1, 3)


SELECT c.CustomerName, p.ProductName, p.Price, op.ProductCount, p.Price*op.ProductCount as TotalPrice FROM Orders o
LEFT JOIN OrderProducts op ON o.Id = op.OrderId
LEFT JOIN Products p ON op.ProductId = p.Id
LEFT JOIN Customers c ON o.CustomerId = c.Id

SELECT c.CustomerName as Customer, o.OrderData, SUM( p.Price*op.ProductCount) as TotalPrice FROM Orders o
LEFT JOIN OrderProducts op ON o.Id = op.OrderId
LEFT JOIN Products p ON op.ProductId = p.Id
LEFT JOIN Customers c ON o.CustomerId = c.Id
GROUP BY CustomerName, OrderData