CREATE TABLE [dbo].[OptionPart] (
    [OptionId] INT NOT NULL,
    [PartId]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([OptionId] ASC, [PartId] ASC),
    FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Option] ([Id]),
    FOREIGN KEY ([PartId]) REFERENCES [dbo].[Part] ([Id])
);

