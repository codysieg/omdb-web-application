CREATE TABLE [dbo].[Users]
(
	[Id] INT PRIMARY KEY NOT NULL , 
    [Email_Address] NVARCHAR(50) UNIQUE NOT NULL, 
    [Password] NVARCHAR(50) NULL, 
    [First_Name] NVARCHAR(50) NULL, 
    [Last_Name] NVARCHAR(50) NULL, 
)
