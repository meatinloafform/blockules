using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Blockules.Items
{
    class ReinforcedIronBroadsword : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 20;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 2;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ReinforcedIron", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
