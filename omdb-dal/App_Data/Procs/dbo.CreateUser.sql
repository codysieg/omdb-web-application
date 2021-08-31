CREATE PROCEDURE [dbo].[CreateUser]
	@Email_Address nvarchar(50),
	@Password nvarchar(50),
	@First_Name nvarchar(50) = NULL,
	@Last_Name nvarchar(50) = NULL
AS
	INSERT INTO [dbo].[Users]
	(
	[Email_Address], 
	[Password], 
	[First_Name], 
	[Last_Name]
	) 
	VALUES 
	(
	@Email_Address, 
	@Password, 
	@First_Name, 
	@Last_Name
	)