CREATE TABLE [dbo].[Users] (
    [Email_Address] NVARCHAR (50) NOT NULL,
    [Password]      NVARCHAR (50) NULL,
    [First_Name]    NVARCHAR (50) NULL,
    [Last_Name]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_EmailAddress] PRIMARY KEY CLUSTERED ([Email_Address] ASC),
    UNIQUE NONCLUSTERED ([Email_Address] ASC)
);