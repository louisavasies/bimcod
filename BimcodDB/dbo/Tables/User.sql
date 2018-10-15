CREATE TABLE [dbo].[User] (
    [Id]       INT        NOT NULL IDENTITY(0,1),
    [Username] NVARCHAR(100) NULL,
    [Password] NVARCHAR(100) NULL,
    [Token] VARCHAR(200) NULL, 
    [IsConfirmed] BIT NOT NULL, 
    [Email] NVARCHAR(100) NULL Unique, 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

