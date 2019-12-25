using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Blockules.Projectiles;

namespace Blockules.NPCs.Bosses
{
    //[AutoloadBossHead]
    public class Arthur : ModNPC
    {
        private Player player;
        private float speed;
        private bool shakeFrame = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("arthur");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 60000; // The Max HP the boss has on Normal
            npc.damage = 30; // The base damage value the boss has on Normal
            npc.defense = 20; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 56;
            npc.height = 155;
            npc.value = 10000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = false; // Not affected by gravity
            npc.noTileCollide = false; 
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EssenceOfNull"), Main.rand.Next(20, 30));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShopKey1"), Main.rand.Next(20, 30));
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Timer2_Slot = 2;

        const int State_Jump = 0;
        const int State_Shake = 1;
        const int State_Laser = 2;

        public float AI_State
        {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer
        {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public float AI_Timer2
        {
            get { return npc.ai[AI_Timer2_Slot]; }
            set { npc.ai[AI_Timer2_Slot] = value; }
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            if (AI_State == State_Shake)
            {
                AI_Timer++;
                if (AI_Timer > 250)
                {
                    shakeFrame = true;
                    AI_State = State_Jump;
                    AI_Timer = 0;
                }
                else if (AI_Timer > 200 && AI_Timer % 5 == 0)
                {
                    shakeFrame = (shakeFrame == true) ? false : true;
                }
            }
            else if (AI_State == State_Jump)
            {
                if (AI_Timer < 1)
                {
                    Move((Main.player[npc.target].position + new Vector2(0, -1000)), 10f, 0);
                    AI_Timer2++;
                    Main.NewText("s");
                }
                else if (AI_Timer2 > 2 && AI_Timer > 100)
                {
                    AI_State = State_Laser;
                    AI_Timer2 = 0;
                    AI_Timer = 0;
                }
                else if (AI_Timer > 100)
                {
                    AI_State = State_Shake;
                }
                AI_Timer++;
            }  
            else if (AI_State == State_Laser)
            {
                AI_Timer++;
                if (AI_Timer % 10 == 0)
                {
                    int laser = Projectile.NewProjectile(npc.Top + new Vector2(0, 25),new Vector2(0,0), mod.ProjectileType("ArthurLaser"), 30, 3);
                    ArthurLaser.Redirect(Main.player[npc.target].Center, 10f, laser, 0f, true, npc.target);
                }
                if (AI_Timer == 200)
                {
                    AI_Timer = 0;
                    AI_State = State_Shake;
                }
            }
            if (npc.velocity.Y == 0)
            {
                npc.velocity = new Vector2(npc.velocity.X / 2, npc.velocity.Y); // slows down if on ground
            }
        }

        private void Move(Vector2 pos, float speeds, float turnRes = 10f)
        {
            speed = speeds;
            Vector2 moveTo = pos;
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = turnRes;
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if (AI_State == State_Shake)
            {
                if (shakeFrame == true)
                {
                    npc.frame.Y = 0;
                }
                else
                {
                    npc.frame.Y = frameHeight;
                }
            }
            if (AI_State == State_Laser)
            {
                npc.frame.Y = frameHeight * 2;
            }
        }
    }
}
