using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Blockules.NPCs.Bosses
{
    [AutoloadBossHead]
    public class BlackTriangle : ModNPC
    {
        private Player player;
        private float speed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Triangle");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 5000; // The Max HP the boss has on Normal
            npc.damage = 10; // The base damage value the boss has on Normal
            npc.defense = 5; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 110;
            npc.height = 152;
            npc.value = 10000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = true; // Not affected by gravity
            npc.noTileCollide = true; // Will not collide with the tiles. 
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath5;
            music = MusicID.Boss1;

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
            npc.defense = (int)(npc.defense + numPlayers);
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WorkBench, 20);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        private int spinTimer = 0;
        private int floatTimer = 0;
        private int shootTimer = 0;
        private int shootVelX = 0;
        private int shootVelY = 10;

        public override void AI()
        {
            Target();
            if (floatTimer < 100)
            {
                npc.rotation = npc.AngleTo(player.position);
            }
            if (spinTimer < 500)
            {
                SetVelocity(new Vector2(GetDist(true), GetDist(false)));
            }
            else if (spinTimer >= 500)
            {
                Spin();
            }

        }

        private void Target()
        {
            player = Main.player[npc.target]; // This will get the player target.
        }

        private void FaceTarget()
        {

        }

        private float GetDist(bool axis)
        {
            if (axis == true)
            {
                return (player.position.X - npc.position.X) / 100;
            }
            else if (axis == false)
            {
                return (player.position.Y - npc.position.Y) / 100;
            }
            else
            {
                return 0.0f;
            }

        }

        private void SetVelocity(Vector2 velocity)
        {
            npc.velocity = velocity;
            spinTimer++;
        }



        private void Spin()
        {
            if (floatTimer < 100)
            {
                npc.velocity = new Vector2(0f, -5f);
                floatTimer++;
            }
            else if (floatTimer >= 100)
            {
                if (floatTimer < 150)
                {
                    npc.velocity = new Vector2(0f, 0f);
                    npc.rotation++;
                    floatTimer++;

                    Random rnd = new Random();
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, rnd.Next(-3, 3), 10, mod.ProjectileType("BlackTriangleProjectile"), 5, 3, Main.myPlayer);

                }
                else if (floatTimer >= 150)
                {
                    floatTimer = 0;
                    spinTimer = 0;
                    npc.rotation = 0;
                }
            }

        }
    }
}