using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Projectiles
{
    class FusedArrow : ModProjectile
    {
        private int counter = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fused Arrow");

        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.scale = 1f;
        }

        public override void PostAI()
        {
            counter++;
            if (counter == 20)
            {
                Projectile.NewProjectile(projectile.position,new Vector2(projectile.velocity.X + Main.rand.Next(-10, 10), projectile.velocity.Y+Main.rand.Next(-10,10)),mod.ProjectileType("FusedArrow"),20000,3,Main.myPlayer);
                counter = 0;
            }
        }
    }
}
