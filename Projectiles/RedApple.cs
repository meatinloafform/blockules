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
    class RedApple : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Appel");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
            projectile.light = 0.5f;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
    }
}
