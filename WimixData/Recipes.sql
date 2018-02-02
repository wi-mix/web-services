CREATE TABLE [dbo].[Recipes] (
	[RecipeID] INT IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	[Ordered] BIT,
	--Zobrist Key is achieved by XORing the associated ingredients of the recipe
	[ZobristKey] BIGINT NOT NULL,
	PRIMARY KEY CLUSTERED ([RecipeID] ASC)
);