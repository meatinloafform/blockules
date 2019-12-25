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
    class AppleSword : ModItem
    {
        private int shootTimer;

        public override void SetDefaults()
        {
            item.damage = 75;
            item.knockBack = 10;
            item.value = 10000;
            item.rare = 3;
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
            recipe.AddIngredient(null, "FusionAppel", 1);
            recipe.AddIngredient(ItemID.Excalibur);
            recipe.AddIngredient(mod.ItemType("FusionCrystal"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (shootTimer == 10)
            {
                int proj;
                proj = Main.rand.Next(0, 3);
                if (proj == 0)
                {
                    proj = mod.ProjectileType("GreenApple");
                }
                else if (proj == 1)
                {
                    proj = mod.ProjectileType("RedApple");
                }
                else if (proj == 2)
                {
                    proj = mod.ProjectileType("YellowApple");
                }
                else
                {
                    proj = ProjectileID.Bullet;
                }
                Vector2 move = (Main.MouseWorld - player.Center) / 100;
                Projectile.NewProjectile(player.position, move, proj, 60, 3, Main.myPlayer);
                shootTimer = 0;
            }
            shootTimer++;
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
    }
}
