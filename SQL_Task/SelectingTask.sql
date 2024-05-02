CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name VARCHAR(50)
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    Name VARCHAR(50)
);

CREATE TABLE ProductCategories (
    ProductID INT,
    CategoryID INT,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

INSERT INTO Products (ProductID, Name)
VALUES
    (1,'Cake'),
    (2,'Bread'),
    (3,'Cookies'),
    (4,'Water'),
    (5,'Beef'),
    (6,'Pork'),
    (7,'Pen'),
    (8,'Pencil'),
    (9,'Apple'),
    (10,'Orange');

INSERT INTO Categories (CategoryID, Name)
VALUES
    (1,'Food'),
    (2,'Drinks'),
    (3,'Stationery'),
    (4,'Meat'),
    (5,'Fruits'),
    (6,'Bakery');

INSERT INTO ProductCategories (ProductID, CategoryID)
VALUES
    (1, 1),
    (1, 6),
    (2, 1),
    (2, 6),
    (3, 1),
    (3, 6),
    (4, 2),
    (5, 1),
    (5, 4),
    (6, 1),
    (6, 4),
    (9, 1),
    (9, 5),
    (10, 1),
    (10, 5);

SELECT Products.Name AS product, Categories.Name AS category FROM Products
    LEFT JOIN ProductCategories PC on Products.ProductID = PC.ProductID
    LEFT JOIN Categories on PC.CategoryID = Categories.CategoryID