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
    class RetinaProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Retina");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 3.5f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
        }

        public override void PostAI()
        {
            base.PostAI();
        }
    }
}
