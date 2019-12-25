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
    class FusionAppel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fusion Apple");
            Tooltip.SetDefault("the three combine to create the ultimate appetizer");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.rare = 3;
            item.value = 0;
            item.maxStack = 99;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FusionCrystal"), 1);
            recipe.AddIngredient(mod.ItemType("GreenAppel"), 1);
            recipe.AddIngredient(mod.ItemType("RedAppel"), 1);
            recipe.AddIngredient(mod.ItemType("YellowAppel"), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
