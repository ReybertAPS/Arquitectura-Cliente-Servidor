CREATE DATABASE [ShoppingListDB]
GO

USE [ShoppingListDB]
GO

CREATE TABLE [ShoppingListHeader]
(
	Id INT NOT NULL Identity(1,1),
	Description VARCHAR(100) NOT NULL,
	CreatedDate DATETIME NOT NULL,
	ShoppingTotalValue NUMERIC(18,2) NOT NULL,
	CONSTRAINT PK_ShoppingListHeader PRIMARY KEY (Id)
)

CREATE TABLE [ShoppingListDetail]
(
	Id INT NOT NULL Identity(1,1),
	ShoppingListHeaderId INT NOT NULL,
	ItemName VARCHAR(100) NOT NULL,
	Quantity NUMERIC(18,2) NOT NULL,
	UnitValue NUMERIC(18,2) NOT NULL,
	TotalValue NUMERIC(18,2) NOT NULL,
	CONSTRAINT PK_ShoppingListDetail PRIMARY KEY (Id),
	CONSTRAINT FK_ShoppingListDetail_ShoppingListHeader FOREIGN KEY (ShoppingListHeaderId) REFERENCES ShoppingListHeader(Id)
)
