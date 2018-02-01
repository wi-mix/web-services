CREATE TABLE [dbo].[Ingredients] (
	[IngredientID] INT IDENTITY NOT NULL,
	--Random 64 bit long generated on insert
	[ZobristKey] BIGINT NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Description] NVARCHAR (200) NULL
);

CREATE TABLE [dbo].[Recipes] (
	[RecipeID] INT IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	[Ordered] BIT,
	--Zobrist Key is achieved by XORing the associated ingredients of the recipe
	[ZobristKey] BIGINT NOT NULL
);

CREATE TABLE [dbo].[RecipeIngredients] (
	[RecipeID] INT NOT NULL,
	[IngredientID] INT NOT NULL,
	[Amount] SMALLINT NOT NULL,
	[Order] TINYINT NULL,
	CONSTRAINT fk_recipe
		FOREIGN KEY (RecipeID) REFERENCES dbo.Recipes (RecipeID),
	CONSTRAINT fk_ingredient
		FOREIGN KEY (IngredientID) REFERENCES dbo.Ingredients (IngredientID),
	CONSTRAINT pk_recipe_ingredients 
		PRIMARY KEY (RecipeID, IngredientID)
);

CREATE CLUSTERED INDEX ix_ingredients ON dbo.Ingredients (IngredientID);
CREATE CLUSTERED INDEX ix_recipes ON dbo.Recipes (RecipeID);

-- Clustered recipe id speeds up recipe fetching
CREATE CLUSTERED INDEX ix_recipe_id ON dbo.RecipeIngredients (RecipeID);
-- Non clustered index on ingredient ids will speed up recipe suggestions
CREATE INDEX ix_ingredient_id ON dbo.RecipeIngredients (IngredientID);