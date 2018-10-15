CREATE TABLE [dbo].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR (100) NULL,
    [Email]       NVARCHAR (100) NULL,
    [Password]        NVARCHAR (100) NULL,
    [Token]       VARCHAR (100)  NULL,
    [IsConfirmed] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

