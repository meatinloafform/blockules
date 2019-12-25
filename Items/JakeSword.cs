using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;

namespace Blockules.Items
{
    class JakeSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("idk");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.knockBack = 8;
            item.value = 1000000;
            item.rare = 4;
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
            recipe.AddIngredient(mod.ItemType("ObliviumBar"), 32);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                //Emit dusts when swing the sword
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("EclipseSparkle"));
            }
        }

    }
}
