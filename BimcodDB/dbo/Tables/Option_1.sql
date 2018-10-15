CREATE TABLE [dbo].[Option] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [Duration]    INT            NULL,
    [ModuleName]  NVARCHAR (10)  NULL,
    [Price]       INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ModuleName]) REFERENCES [dbo].[Module] ([ModuleName])
);

