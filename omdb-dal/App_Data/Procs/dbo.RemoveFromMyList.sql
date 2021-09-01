CREATE PROCEDURE [dbo].[RemoveFromMyList]
	@Email_Address nvarchar(50),
	@ImdbID nchar (10)
AS
	DELETE FROM [dbo].[UserList]
	WHERE 
	(
	@Email_Address = [Email_Address] AND
	@ImdbID = [ImdbID]
	)