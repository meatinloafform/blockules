using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Blockules.NPCs.Bosses;

namespace Blockules.NPCs.Bosses
{
    //[AutoloadBossHead]
    public class Skeletron2 : ModNPC
    {
        private Player player;
        private int ArmOffset = 100;
        private int LaserOffset = 25;
        private float speed;
        private int side = 1;
        private bool chargeDir = false;
        private int charges;
        private int arm1;
        private int arm2;
        private int arm3;
        private int arm4;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Madness");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 60000;
            npc.damage = 30;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 100;
            npc.value = 10000;
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
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
        const int AI_Timer2_Slot = 1;

        const int State_SpawnArms = 0;
        const int State_Follow = 1;

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
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public override void AI()
        {
            npc.TargetClosest(false);
            if (AI_State == State_SpawnArms)
            {
                arm1 = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Skeletron2Arm"));
                Skeletron2Arm.SetPos(npc.position,Main.npc[arm1]);
                arm2 = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Skeletron2Arm"));
                Skeletron2Arm.SetPos(npc.position, Main.npc[arm2]);
                arm3 = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Skeletron2Arm"));
                Skeletron2Arm.SetPos(npc.position, Main.npc[arm3]);
                arm4 = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Skeletron2Arm"));
                Skeletron2Arm.SetPos(npc.position, Main.npc[arm4]);
                AI_State = State_Follow;
            }
            if (AI_State == State_Follow)
            {
                Move(new Vector2(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - 300), 10f);
                Skeletron2Arm.Move(new Vector2(npc.Center.X - ArmOffset, npc.Center.Y - ArmOffset), 10f, Main.npc[arm1]);
                Skeletron2Arm.Move(new Vector2(npc.Center.X + ArmOffset, npc.Center.Y - ArmOffset), 10f, Main.npc[arm2]);
                Skeletron2Arm.Move(new Vector2(npc.Center.X - ArmOffset, npc.Center.Y + ArmOffset), 10f, Main.npc[arm3]);
                Skeletron2Arm.Move(new Vector2(npc.Center.X + ArmOffset, npc.Center.Y + ArmOffset), 10f, Main.npc[arm4]);
                if (AI_Timer == 50)
                {
                    Projectile.NewProjectile(Main.npc[arm1].Center, RetMove(Main.player[npc.target].Center + new Vector2(Main.rand.Next(-LaserOffset, LaserOffset), Main.rand.Next(-10, 10)), 10f, 0f), 100, 40, 2, Main.myPlayer);
                    Projectile.NewProjectile(Main.npc[arm2].Center, RetMove(Main.player[npc.target].Center + new Vector2(Main.rand.Next(-LaserOffset, LaserOffset), Main.rand.Next(-10, 10)), 10f, 0f), 100, 40, 2, Main.myPlayer);
                    Projectile.NewProjectile(Main.npc[arm3].Center, RetMove(Main.player[npc.target].Center + new Vector2(Main.rand.Next(-LaserOffset, LaserOffset), Main.rand.Next(-10, 10)), 10f, 0f), 100, 40, 2, Main.myPlayer);
                    Projectile.NewProjectile(Main.npc[arm4].Center, RetMove(Main.player[npc.target].Center + new Vector2(Main.rand.Next(-LaserOffset, LaserOffset), Main.rand.Next(-10, 10)), 10f, 0f), 100, 40, 2, Main.myPlayer);
                    AI_Timer = 0;
                    Main.NewText(Main.player[npc.target].Center);
                    Main.NewText(Main.npc[arm1].Center);
                }
                AI_Timer++;
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

        private Vector2 RetMove(Vector2 pos, float speeds, float turnRes = 10f)
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
            return move;
        }
    }
}
