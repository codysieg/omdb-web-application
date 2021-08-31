CREATE PROCEDURE [dbo].[LoginUser]
	@Email_Address nvarchar(50),
	@Password nvarchar(50)
AS
	SELECT * 
	FROM [dbo].[Users]
	WHERE 
	(
		@Email_address = Email_Address AND 
		@Password = Password
	)