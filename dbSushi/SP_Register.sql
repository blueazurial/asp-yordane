CREATE PROCEDURE [dbo].[SP_Register]
	@email NVARCHAR(255),
	@password NVARCHAR(255),
	@lastname NVARCHAR(100),
	@firstname NVARCHAR(100),
	@birthdate DATETIME2,
	@street NVARCHAR(255),
	@number NVARCHAR(10),
	@zipcode int,
	@city VARCHAR (100)
AS
BEGIN
	INSERT INTO [User] (Email, [Password], LastName, FirstName, BirthDate, Street, Number, ZipCode, City) 
						VALUES (@email, dbo.Udf_hash_Password(@password, @email), @lastname, @firstname, @birthdate, @street, @number, @zipcode, @city)

END
