using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Blockules.NPCs.Bosses
{
    [AutoloadBossHead]
    public class Void : ModNPC
    {
        private Player player;
        private float speed;
        private bool charge;
        private int dev;
        private int chargeCount;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 40000; // The Max HP the boss has on Normal
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EssenceOfNull"), Main.rand.Next(20,30));
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
        const int AI_Sub_State_Slot = 1;
        const int AI_Timer_Slot = 2;

        const int State_Hover = 0;
        const int State_Charge = 1;

        const int SubState_FloatLeft = 0;
        const int SubState_FloatRight = 1;
        const int SubState_Charge = 2;
        const int SubState_Fly = 3;

        public float AI_State
        {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_SubState
        {
            get { return npc.ai[AI_Sub_State_Slot]; }
            set { npc.ai[AI_Sub_State_Slot] = value; }
        }

        public float AI_Timer
        {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }



        public override void AI()
        {
            if (Main.rand.Next(5) == 0)
            {
                Dust dust = Dust.NewDustDirect(npc.Center, npc.width, npc.height, mod.DustType("VoidDust"));
                dust.noGravity = true;
                dust.scale = 5.4f;
            }
            npc.TargetClosest(true);
            if (AI_State == State_Hover)
            {
                
                
                if (AI_Timer < 200)
                {
                    Move(new Vector2(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - 100), 10f);
                }
                
                else if (AI_Timer >= 200 && AI_Timer < 250)
                {
                    npc.velocity = new Vector2(0,-10);
                }
                else if (AI_Timer >= 250)
                {
                    AI_State = State_Charge;
                    AI_SubState = SubState_FloatLeft;
                    AI_Timer = 0;
                }
                npc.rotation = npc.AngleTo(Main.player[npc.target].position);
                AI_Timer++;
            }

            else if (AI_State == State_Charge)
            {
                if (AI_SubState == SubState_FloatLeft)
                {
                       
                    npc.rotation = npc.AngleTo(Main.player[npc.target].position);
                    Move(new Vector2(Main.player[npc.target].position.X - 250, Main.player[npc.target].position.Y - 250), 25f);
                    AI_Timer++;
                    if (AI_Timer == 75 || AI_Timer == 80 || AI_Timer == 90)
                    {
                        Random rnd = new Random();
                        dev = rnd.Next(-20,20);
                        Projectile.NewProjectile(npc.Center, new Vector2(dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                        dev = rnd.Next(-20, 20);
                        Projectile.NewProjectile(npc.Center, new Vector2(dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                        dev = rnd.Next(-20, 20);
                        Projectile.NewProjectile(npc.Center, new Vector2(dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                        dev = rnd.Next(-20, 20);
                        Projectile.NewProjectile(npc.Center, new Vector2(dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                    }
                    if (AI_Timer > 100)
                    {
                        chargeCount++;
                        AI_SubState = SubState_Charge;
                        charge = true;
                    }
                }

                if (AI_SubState == SubState_Charge)
                {
                    if (chargeCount == 4)
                    {
                        AI_SubState = SubState_Fly;
                        AI_Timer = 0;
                    }
                    else if (AI_Timer < 105)
                    {
                        npc.velocity = new Vector2((Main.player[npc.target].position.X - npc.position.X) / 20, (Main.player[npc.target].position.Y - npc.position.Y) / 20);
                    }
                    else if (AI_Timer >= 150 && charge == true)
                    {
                        AI_SubState = SubState_FloatRight;
                    }
                    else if (AI_Timer >= 150 && charge == false)
                    {
                        AI_State = State_Hover;
                        AI_Timer = 0;
                    }
                    AI_Timer++;
                }

                else if (AI_SubState == SubState_FloatRight)
                {
                    npc.rotation = npc.AngleTo(Main.player[npc.target].position);
                    Move(new Vector2(Main.player[npc.target].position.X + 250, Main.player[npc.target].position.Y - 250), 25f);
                    AI_Timer++;
                    if (AI_Timer == 220 || AI_Timer == 225 || AI_Timer == 240)
                    {
                        Random rnd = new Random();
                        dev = rnd.Next(-20, 20);
                        Projectile.NewProjectile(npc.Center, new Vector2(-dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                        dev = rnd.Next(-20, 20);
                        Projectile.NewProjectile(npc.Center, new Vector2(-dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                        dev = rnd.Next(-20, 20);
                        Projectile.NewProjectile(npc.Center, new Vector2(-dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                        dev = rnd.Next(-20, 20);
                        Projectile.NewProjectile(npc.Center, new Vector2(-dev, dev), mod.ProjectileType("VoidShot"), 10, 3);
                    }
                    if (AI_Timer > 250)
                    {
                        chargeCount++;
                        AI_SubState = SubState_Charge;
                        AI_Timer = 100;
                        charge = false;
                    }                   
                }

                else if (AI_SubState == SubState_Fly)
                {
                    if (AI_Timer < 100)
                    {
                        Move(new Vector2(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - 500), 10f);
                    }
                    else if (AI_Timer <= 150)
                    {
                        npc.velocity = new Vector2(0,0);
                        npc.rotation = npc.rotation + 5f;
                    }
                    else if (AI_Timer <= 200)
                    {
                        npc.rotation = npc.rotation + 5f;
                        Random rnd = new Random();
                        Projectile.NewProjectile(npc.Center, new Vector2(rnd.Next(-3, 3), 10), mod.ProjectileType("VoidShot"), 15, 3, Main.myPlayer);
                    }
                    else if (AI_Timer <= 300)
                    {
                        AI_State = State_Hover;
                        AI_Timer = 0;
                        chargeCount = 0;
                    }
                    AI_Timer++;
                }
            }
        }

        private void Move(Vector2 pos, float speeds)
        {
            speed = speeds;
            Vector2 moveTo = pos;
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 10f;
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }
    }
}
