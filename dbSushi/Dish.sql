CREATE TABLE [dbo].[Dish]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[CategoryId] INT REFERENCES Category,
	[Price] DECIMAL(6,2) NOT NULL,
	[Discount] INT NULL,
	[Picture] VARCHAR(50) null,
	[Active] BIT NOT NULL DEFAULT 1,
	[Deleted] BIT NOT NULL DEFAULT 0
)
