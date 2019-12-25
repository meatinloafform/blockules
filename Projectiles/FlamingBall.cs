using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Blockules.Projectiles
{
    class FlamingBall : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 2;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
        }
    }
}
