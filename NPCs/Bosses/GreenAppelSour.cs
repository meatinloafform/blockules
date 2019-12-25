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
using Microsoft.Xna.Framework.Audio;

namespace Blockules.NPCs.Bosses
{
    [AutoloadBossHead]
    public class GreenAppelSour : ModNPC
    {
        private Player player;
        private float speed;
        private bool side;
        private float timer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("grean apel sour");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 20000; // The Max HP the boss has on Normal
            npc.damage = 50; // The base damage value the boss has on Normal
            npc.defense = 15; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 300;
            npc.height = 300;
            npc.value = 1000000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = true; // Not affected by gravity
            npc.noTileCollide = true; // Will not collide with the tiles. 
            npc.HitSound = SoundID.NPCHit18;
            npc.DeathSound = SoundID.NPCDeath18;
            music = MusicID.Boss3;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
            npc.defense = (int)(npc.defense + numPlayers);
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FusionCrystal"), 1);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Timer2_Slot = 2;

        const int State_Hover = 0;
        const int State_Swoop = 1;
        const int State_Swarm = 2;

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
            npc.rotation = 1.57f;
            if (AI_State == State_Hover)
            {
                if (AI_Timer <= 50)
                {
                    Move(new Vector2(Main.player[npc.target].position.X - 200, Main.player[npc.target].position.Y - 300), 10f);
                }
                else if (AI_Timer > 50)
                {
                    Move(new Vector2(Main.player[npc.target].position.X + 200, Main.player[npc.target].position.Y - 300), 10f);
                }
                if (AI_Timer == 100)
                {
                    AI_Timer = 0;
                    AI_Timer2++;
                }
                if (AI_Timer2 == 5)
                {
                    AI_Timer = 0;
                    AI_Timer2 = 0;
                    side = true;
                    AI_State = State_Swoop;
                }
                AI_Timer++;
            }
            else if (AI_State == State_Swoop)
            {
                AI_Timer++;
                
                if (AI_Timer < 10)
                {
                    Move(Main.player[npc.target].position, 25f);
                }
                else if (AI_Timer > 50)
                {
                    if (side == true)
                    {
                        Move(new Vector2(Main.player[npc.target].position.X - 200, Main.player[npc.target].position.Y - 300), 10f);
                    }
                    else if (side == false)
                    {
                        Move(new Vector2(Main.player[npc.target].position.X + 200, Main.player[npc.target].position.Y - 300), 10f);
                    }
                }
                if (AI_Timer > 150)
                {
                    side = (side == true) ? false : true;
                    AI_Timer2++;
                    AI_Timer = 0;
                }
                if (AI_Timer2 == 5)
                {
                    AI_State = State_Swarm;
                }
            }
            if (AI_State == State_Swarm)
            {
                AI_Timer++;
                Move(new Vector2(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - 300), 10f);
                if (AI_Timer == 10)
                {
                    AI_Timer = 0;
                    AI_Timer2++;
                    int rand = Main.rand.Next(0,3);
                    if (rand == 0)
                    {
                        int servant = NPC.NewNPC((int)Math.Ceiling(npc.position.X) * 16, (int)Math.Ceiling(npc.position.X) * 16, mod.NPCType("GreenAppelMinion"));
                        GreenAppelMinion.SetPos(npc.position, Main.npc[servant]);
                    }
                    else if (rand == 1)
                    {
                        int servant = NPC.NewNPC((int)Math.Ceiling(npc.position.X) * 16, (int)Math.Ceiling(npc.position.X) * 16, mod.NPCType("RedAppelMinion"));
                        RedAppelMinion.SetPos(npc.position, Main.npc[servant]);
                    }
                    else if (rand == 2)
                    {
                        int servant = NPC.NewNPC((int)Math.Ceiling(npc.position.X) * 16, (int)Math.Ceiling(npc.position.X) * 16, mod.NPCType("YellowAppelMinion"));
                        YellowAppelMinion.SetPos(npc.position, Main.npc[servant]);
                    }
                    else
                    {
                        Main.NewText("How could this happen?", new Color(255, 0, 0));
                    }
                }
                if (AI_Timer2 > 20)
                {
                    AI_State = State_Hover;
                    AI_Timer = 0;
                    AI_Timer2 = 0;
                }
            }
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
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
