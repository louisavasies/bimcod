CREATE TABLE [dbo].[CarOption] (
    [CarId]    INT NOT NULL,
    [OptionId] INT NOT NULL,
    CONSTRAINT [PK_CarOption] PRIMARY KEY CLUSTERED ([CarId] ASC, [OptionId] ASC),
    CONSTRAINT [FK_CarOption_Car] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Car] ([Id]),
    CONSTRAINT [FK_CarOption_Option] FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Option] ([Id])
);

