CREATE TABLE [dbo].[CarOption] (
    [CarId]    INT NOT NULL,
    [OptionId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC, [OptionId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Car] ([Id]),
    FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Option] ([Id])
);

