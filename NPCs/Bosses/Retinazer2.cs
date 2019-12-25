using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Blockules.NPCs.Bosses
{
    [AutoloadBossHead]
    public class Retinazer2 : ModNPC
    {
        private Player player;
        private float speed;
        private int side = 1;
        private bool chargeDir = false;
        private int charges;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Madness");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 60000; // The Max HP the boss has on Normal
            npc.damage = 30; // The base damage value the boss has on Normal
            npc.defense = 20; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 172;
            npc.height = 110;
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
        const int AI_Stage_Slot = 2;

        const int State_Chase = 0;
        const int State_Spam = 1;
        const int State_Chase2 = 2;
        const int State_Fly = 3;
        const int State_Charge = 4;
        const int State_Transform = 5;

        const int Stage_Retinazer = 0;
        const int Stage_Spasmatism = 1;

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

        public float AI_Stage
        {
            get { return npc.ai[AI_Stage_Slot]; }
            set { npc.ai[AI_Stage_Slot] = value; }
        }



        public override void AI()
        {
            if (npc.life < 30000 && AI_State == Stage_Retinazer)
            {
                AI_Stage = Stage_Spasmatism;
                AI_State = State_Transform;
                AI_Timer = 0;
            }
            npc.TargetClosest();
            if (AI_State == State_Chase)
            {
                Move(Main.player[npc.target].position, 5f);
                npc.rotation = npc.AngleTo(Main.player[npc.target].position);
                AI_Timer++;
                if (AI_Timer == 500)
                {
                    npc.velocity = new Vector2(0f, 0f);
                    AI_State = State_Spam;
                    AI_Timer = 0;
                }
            }
            if (AI_State == State_Spam)
            {
                Vector2 vel;
                npc.rotation += 0.5f;
                if (side == 9)
                {
                    side = 1;
                }
                switch(side)
                {
                    case 1:
                        vel = new Vector2(10f, 0f);
                        break;
                    case 2:
                        vel = new Vector2(5f, -5f);
                        break;
                    case 3:
                        vel = new Vector2(0f, -10f);
                        break;
                    case 4:
                        vel = new Vector2(-5f,-5f);
                        break;
                    case 5:
                        vel = new Vector2(-10f, 0f);
                        break;
                    case 6:
                        vel = new Vector2(-5f,5f);
                        break;
                    case 7:
                        vel = new Vector2(0f,10f);
                        break;
                    case 8:
                        vel = new Vector2(5f, 5f);
                        break;
                    default:
                        vel = new Vector2(10f, 0f);
                        break;
                }
                Projectile.NewProjectile(npc.Center, vel, ProjectileID.DeathLaser, 30, 2);
                side++;
                AI_Timer++;
                if (AI_Timer == 100)
                {
                    AI_State = State_Chase;
                }
            }
            if (AI_State == State_Transform)
            {
                npc.velocity = new Vector2(0f, 0f);
                npc.rotation += 0.25f;
                npc.damage = 50;
                npc.defense = 10;
                if (AI_Timer > 100)
                {
                    AI_State = State_Chase2;
                    AI_Timer = 0;
                }
                AI_Timer++;
            }
            if (AI_State == State_Chase2)
            {
                Move(Main.player[npc.target].position, 7.5f);
                npc.rotation = npc.AngleTo(Main.player[npc.target].position);
                AI_Timer++;
                if (AI_Timer == 500)
                {
                    npc.velocity = new Vector2(0f, 0f);
                    AI_State = State_Fly;
                    AI_Timer = 0;
                }
            }
            if (AI_State == State_Fly)
            {
                Move(new Vector2(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - 500), 10f);
                npc.rotation = npc.AngleTo(Main.player[npc.target].position);
                AI_Timer++;
                if (AI_Timer == 30 || AI_Timer == 40 || AI_Timer == 50)
                {
                    Projectile.NewProjectile(npc.Center,new Vector2(0,10f),ProjectileID.CursedFlameHostile,60,3);
                }
                if (AI_Timer > 100)
                {
                    AI_State = State_Charge;
                    charges = 0;
                    chargeDir = false;
                    AI_Timer = 0;
                }
            }
            if (AI_State == State_Charge)
            {
                AI_Timer++;
                npc.rotation = npc.AngleTo(Main.player[npc.target].position);
                if (charges == 4)
                {
                    AI_State = State_Chase2;
                }
                if (AI_Timer == 50 || AI_Timer == 100 || AI_Timer == 150 || AI_Timer == 200)
                {
                    if (!chargeDir)
                    {
                        Move(new Vector2(Main.player[npc.target].position.X, Main.player[npc.target].position.Y + 300), 25f, 0f);
                        chargeDir = true;
                        charges++;
                    }
                    else if (chargeDir)
                    {
                        Move(new Vector2(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - 300), 25f, 0f);
                        chargeDir = false;
                        charges++;
                    }
                }
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
            // This makes the sprite flip horizontally in conjunction with the npc.direction.

            // For the most part, our animation matches up with our states.
            if (AI_State == State_Chase)
            {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
                npc.frame.Y = 0;
            }
            if (AI_State == State_Spam)
            {
                npc.frame.Y = frameHeight;
            }
            if (AI_State == State_Transform)
            {
                npc.frame.Y = 0;
            }
            if (AI_State == State_Chase2)
            {
                npc.frame.Y = frameHeight * 2;
            }
            if (AI_State == State_Fly)
            {
                npc.frame.Y = frameHeight * 2;
            }
            if (AI_State == State_Charge)
            {
                npc.frame.Y = frameHeight * 2;
            }
        }
    }
}
