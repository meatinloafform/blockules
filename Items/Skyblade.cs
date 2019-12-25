using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class Skyblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The blade of the clouds.");
        }

        public override void SetDefaults()
        {
            item.damage = 135;
            item.useStyle = 1;
            item.value = 100000;
            item.width = 80;
            item.height = 80;
            item.knockBack = 10;
            item.useTime = 7;
            item.useAnimation = 7;
            item.rare = 5;
            item.melee = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddIngredient(ItemID.CobaltBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
