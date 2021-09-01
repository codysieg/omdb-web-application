CREATE PROCEDURE [dbo].[GetFavouritesByUser]
	@Email_Address nvarchar(50)
AS
	SELECT ImdbID
	FROM [dbo].[UserList]
	WHERE 
	(
		@Email_address = Email_Address
	)