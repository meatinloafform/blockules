using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class JakePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunstone Pickaxe");
            Tooltip.SetDefault("The pickaxe of the sun.");
        }
        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 7;
            item.useAnimation = 7;
            item.pick = 200;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ObliviumBar"), 42);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
