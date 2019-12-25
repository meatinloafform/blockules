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
    class WhiteTriangleProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Triangle");
            
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.timeLeft = 600;
            projectile.height = 16;
            projectile.aiStyle = 14;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.scale = 1f;
        }
    }
}
