using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
	public class ReinforcedIron : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Iron Bar");
			Tooltip.SetDefault("Better than iron");
		}
		public override void SetDefaults()
		{
            item.material = true;
            item.maxStack = 999;
            item.rare = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
