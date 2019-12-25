using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class test : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geometrical Anomaly");
            Tooltip.SetDefault("Summons the triangle guardians");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 100;
            item.rare = 1;
            item.useAnimation = 40;
            item.useTime = 45;
            item.consumable = true;

            item.useStyle = 4; // Holds up like a summon item.
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ObliviumBar"), 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("WhiteTriangle")); // Spawn the boss within a range of the player. 
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BlackTriangle"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}
