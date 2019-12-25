using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class IronSwordX5 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Sword x 5");
        }
        public override void SetDefaults()
        {
            item.melee = true;
            item.useAnimation = 100;
            item.useTime = 100;
            item.damage = 50;
            item.knockBack = 15;
            item.width = 152;
            item.height = 152;
            item.rare = 3;
            item.value = 50000;
            item.autoReuse = false;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBroadsword, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
