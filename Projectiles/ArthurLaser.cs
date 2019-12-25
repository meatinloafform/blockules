using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Blockules.Projectiles
{
    class ArthurLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arthur");
        }

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

        public static void Redirect(Vector2 pos, float speeds, int proj, float turnRes = 10f, bool faceTarget = false, int target = 255)
        {
            if (faceTarget)
            {
                Main.projectile[proj].rotation = Main.projectile[proj].AngleTo(Main.player[target].Center);
            }
            float speed = speeds;
            Vector2 moveTo = pos;
            Vector2 move = moveTo - Main.projectile[proj].Center;
            float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = turnRes;
            move = (Main.projectile[proj].velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            Main.projectile[proj].velocity = move;
        }
    }
}
