using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    public class RecipeHandler : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Unobtainable, used for coding magic.");
        }
        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 999;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores);
            recipe.AddIngredient(ItemID.Rope);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.Vine);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 10);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddIngredient(ItemID.Wire);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ClockworkAssaultRifle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddIngredient(ItemID.Wire);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ClockworkAssaultRifle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Chain, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ChainGun);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Radar);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.LifeformAnalyzer);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.Wire, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Compass);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.Wire, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Compass);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Radar);
            recipe.AddIngredient(ItemID.IronOre, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.anyIronBar = true;
            recipe.SetResult(ItemID.DepthMeter);
            recipe.AddRecipe();
        }
    }
}
