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
    class HotGoop : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hot Goop");
            Tooltip.SetDefault("Hot to the touch... so much that it's burning your hands!");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.rare = 1;
            item.value = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(BuffID.OnFire, 100);
        }
    }
}
