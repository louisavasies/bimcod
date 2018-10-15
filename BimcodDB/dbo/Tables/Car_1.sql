CREATE TABLE [dbo].[Car] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Model]  NVARCHAR (10) NULL,
    [Type]   NVARCHAR (10) NULL,
    [UserId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

