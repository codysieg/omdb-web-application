CREATE PROCEDURE [dbo].[GetFavouriteStatusById]
	@Email_Address nvarchar(50),
	@ImdbID nchar (10)
AS
	SELECT *
	FROM [dbo].[UserList]
	WHERE
	(
		@Email_Address = [Email_Address] AND
		@ImdbID = [ImdbID]
	)