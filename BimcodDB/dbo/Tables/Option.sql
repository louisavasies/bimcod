CREATE TABLE [dbo].[Option] (
    [Id]          INT         NOT NULL,
    [Description] NVARCHAR(100) NULL,
    [Duration]    INT         NULL,
    [ModuleName]  NVARCHAR(10)  NULL,
    [Price]       INT         NULL,
    CONSTRAINT [PK_Option] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Option_Module] FOREIGN KEY ([ModuleName]) REFERENCES [dbo].[Module] ([ModuleName])
);

