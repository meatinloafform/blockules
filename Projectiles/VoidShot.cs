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
    class VoidShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.timeLeft = 600;
            projectile.height = 16;
            projectile.aiStyle = 0;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.scale = 1f;
        }

        public override void PostAI()
        {
            if (Main.rand.Next(5) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("VoidDust"));
                dust.noGravity = true;
                dust.scale = 1.6f;
            }
        }
    }
}
