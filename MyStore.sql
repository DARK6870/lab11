create database VladPractica
go

use VladPractica
go

create table Category(
CategoryId tinyint primary key Identity(1,1),
CategoryName nvarchar(30) not null
)
go

create table Users(
UserId int primary key Identity(1,1),
RoleId tinyint not null,
UserName nvarchar(30) not null,
Email nvarchar(50) not null,
PasswordHash nvarchar(250) not null,
FullName nvarchar(60) not null,
Adress nvarchar(70) not null,
PhoneNumber nvarchar(20) not null
)
go

create table Status(
StatusId tinyint primary key Identity(1,1),
StatusName nvarchar(15) not null)
go

create table Product(
ProductId int primary key Identity(1,1),
ProductName nvarchar(50) not null,
ProductDescription nvarchar(500) not null,
Price int not null,
ImageUrl nvarchar(500) not null,
CategoryId tinyint foreign key references Category(CategoryId),
Available bit
)
go

create table Orders(
OrderId int primary key Identity(1,1),
UserId int foreign key references Users(UserId) not null,
ProductId int foreign key references Product(ProductId) not null,
Quantity smallint not null,
TotalPrice int not null,
StatusId tinyint foreign key references Status(StatusId) not null)
go



-- Inserting into Category table
INSERT INTO Category (CategoryName) VALUES
('Electronics'),
('Clothing'),
('Books'),
('Home & Kitchen'),
('Toys');

-- Inserting into Users table
INSERT INTO Users (RoleId, UserName, Email, PasswordHash, FullName, Adress, PhoneNumber) VALUES
(1, 'john_doe', 'admin@example.com', '15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225', 'John Doe', '123 Main St, City, Country', '+1234567890'),
(2, 'jane_smith', 'delivery@example.com', '15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225', 'Jane Smith', '456 Elm St, City, Country', '+0987654321'),
(2, 'mike_jones', 'mike@example.com', '15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225', 'Mike Jones', '789 Oak St, City, Country', '+1357924680'),
(2, 'alice_wonderland', 'alice@example.com', '15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225', 'Alice Wonderland', '321 Pine St, City, Country', '+2468135790'),
(2, 'bob_marley', 'bob@example.com', '15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225', 'Bob Marley', '654 Cedar St, City, Country', '+9876543210');

-- Inserting into Status table
INSERT INTO Status (StatusName) VALUES
('Pending'),
('Processing'),
('Delivered'),
('Cancelled'),
('Refunded');

-- Inserting into Product table
INSERT INTO Product (ProductName, ProductDescription, Price, ImageUrl, CategoryId, Available) VALUES
('Laptop', 'High-performance laptop for all your computing needs', 1000, 'laptop_image_url.jpg', 1, 1),
('T-shirt', 'Comfortable cotton T-shirt for everyday wear', 20, 'tshirt_image_url.jpg', 2, 1),
('Programming Book', 'Comprehensive guide to programming languages', 50, 'book_image_url.jpg', 3, 1),
('Kitchen Blender', 'Powerful blender for smoothies and shakes', 80, 'blender_image_url.jpg', 4, 1),
('Toy Car', 'Remote-controlled toy car for kids', 30, 'car_image_url.jpg', 5, 1);

-- Inserting into Orders table
INSERT INTO Orders (UserId, ProductId, Quantity, TotalPrice, StatusId) VALUES
(1, 1, 1, 1000, 1),
(2, 2, 2, 40, 2),
(3, 3, 1, 50, 3),
(4, 4, 1, 80, 1),
(5, 5, 3, 90, 2);



CREATE PROCEDURE GetCategoryByCategoryNameProcedure
    @CategoryName NVARCHAR(30)
AS
BEGIN
    SELECT *
    FROM Category
    WHERE CategoryName = @CategoryName;
END;