CREATE PROCEDURE [dbo].[AddToMyList]
	@Email_Address nvarchar(50),
	@ImdbID nchar (10)
AS
	INSERT INTO [dbo].[UserList] 
	(
	[Email_Address],
	[ImdbID]
	)
	VALUES 
	(
	@Email_Address,
	@ImdbID
	)