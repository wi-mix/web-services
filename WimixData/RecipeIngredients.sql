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
		PRIMARY KEY NONCLUSTERED (RecipeID, IngredientID)
);
GO

-- Clustered recipe id speeds up recipe fetching
CREATE CLUSTERED INDEX ix_recipe_id ON dbo.RecipeIngredients (RecipeID);
GO
-- Non clustered index on ingredient ids will speed up recipe suggestions
CREATE INDEX ix_ingredient_id ON dbo.RecipeIngredients (IngredientID);