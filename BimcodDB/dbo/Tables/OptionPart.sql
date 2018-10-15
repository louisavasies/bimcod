CREATE TABLE [dbo].[OptionPart] (
    [OptionId] INT NOT NULL,
    [PartId]   INT NOT NULL,
    CONSTRAINT [PK_OptionPart] PRIMARY KEY CLUSTERED ([OptionId] ASC, [PartId] ASC),
    CONSTRAINT [FK_OptionPart_Option] FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Option] ([Id]),
    CONSTRAINT [FK_OptionPart_Part] FOREIGN KEY ([PartId]) REFERENCES [dbo].[Part] ([Id])
);

