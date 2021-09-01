CREATE TABLE [dbo].[UserList]
( 
	[Email_Address] NVARCHAR(50) NOT NULL,
	[ImdbID] NCHAR(10) NOT NULL, 
	CONSTRAINT PK_List_Email_ImbdID PRIMARY KEY (Email_Address, ImdbID),
	CONSTRAINT FK_User_Email_Address FOREIGN KEY (Email_Address) REFERENCES [dbo].[Users] (Email_Address)
)