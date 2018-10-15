CREATE TABLE [dbo].[Car] (
    [Id]     INT        NOT NULL IDENTITY(0,1),
    [Model]  NVARCHAR(10) NULL,
    [Type]   NVARCHAR(10) NULL,
    [UserId] INT        NOT NULL,
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Car_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

