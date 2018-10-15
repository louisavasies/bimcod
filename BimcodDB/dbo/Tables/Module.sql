CREATE TABLE [dbo].[Module] (
    [ModuleName] NVARCHAR(10) NOT NULL,
    [For]        NVARCHAR(10) NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([ModuleName] ASC)
);

