CREATE PROCEDURE [dbo].[SP_Login]
	@email NVARCHAR(255),
	@password NVARCHAR(255)
AS
BEGIN
	SELECT Id FROM [User] WHERE Email = @email AND [Password] = dbo.Udf_Hash_Password (@password, @email)
END
