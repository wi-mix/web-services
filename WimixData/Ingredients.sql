CREATE TABLE [dbo].[Ingredients] (
	[IngredientID] INT IDENTITY NOT NULL,
	--Random 64 bit long generated on insert
	[ZobristKey] BIGINT NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Description] NVARCHAR (200) NULL,
	PRIMARY KEY CLUSTERED ([IngredientID] ASC)
);