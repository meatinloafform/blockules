using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandStuffs.NPCs.Bosses
{
    class TutorialBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tutorial Boss");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 60000; // The Max HP the boss has on Normal
            npc.damage = 30; // The base damage value the boss has on Normal
            npc.defense = 10; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 128;
            npc.height = 128;
            npc.value = 10000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = true; // Not affected by gravity
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;
            music = MusicID.Boss4;
        }

        public override void BossLoot(ref string name, ref int potionType) // use bossloot instead of npcloot for bosses
        {
            Item.NewItem(npc.position, npc.Size, ItemID.DirtBlock, 23); // to access mod items, use mod.ItemType("");
        }

        /* public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.6f);
            npc.defense = (int)(npc.defense + numPlayers);
        } */

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) // makes health bar bigger
        {
            scale = 1.5f;
            return null;
        }

        // useful methods

        private float Magnitude(Vector2 mag) // used for the move functions
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        private float speed;

        private void Move(Vector2 pos, float speeds) // easy method for moving the npc, i have no idea how this works mathematically but it works
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

        private Vector2 RetMove(Vector2 pos, float speeds) // same as move but returns a value instead of moving the npc
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
            return move;
        }

        const int AI_State_Slot = 0; // the ai values are represented by npc.ai[n] and these are n
        const int AI_Timer_Slot = 1;
        // const int AI_Timer2_Slot = 2;

        const int State_Something = 0; // the ai states, just used to aid readability
        const int State_Example = 1;
        const int State_CoolKid = 2;

        public float AI_State // these are properties, it lets you set the value of npc.ai[n] to a variable
        {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer
        {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        // if you need a second timer for more advanced ais
        /* public float AI_Timer2 
        {
            get { return npc.ai[AI_Timer2_Slot]; }
            set { npc.ai[AI_Timer2_Slot] = value; }
        } */

        public override void AI() // runs for every game tick, essentially a loop
        {
            npc.TargetClosest(false);
            if (AI_State == State_Something) // the boss just goes towards you
            {
                AI_Timer++;
                Move(Main.player[npc.target].position, 7f); // moves towards the player
                if (AI_Timer >= 500)
                {
                    AI_State = State_Example;
                    AI_Timer = 0;
                }
            }

            if (AI_State == State_Example) // the boss floats above you then shoots lasers at you
            {
                AI_Timer++; // by incrementing the timer every frame, you can keep track of time
                if (AI_Timer <= 100)
                {
                    Move(Main.player[npc.target].Center + new Vector2(0, -100), 10f); // moves to the npc's target's center minus 100 on the y axis (coordintes are measured from the top left)
                }
                else if (AI_Timer >= 100 && AI_Timer <= 600)
                {
                    npc.velocity = Vector2.Zero;
                    if (Main.rand.NextBool()) // returns a random boolean
                    {
                        Projectile.NewProjectile(npc.Center, RetMove(Main.player[npc.target].Center, 40f), ProjectileID.DeathLaser, 50, 2f); // the retmove function just return the velocity needed to get the the target
                    }
                }
                else if (AI_Timer >= 600)
                {
                    AI_State = State_CoolKid; // switches ai state
                    AI_Timer = 0; // make sure to do this
                }
            }

            if (AI_State == State_CoolKid) // the boss floats above, drops down, and then shoots skulls in random directions
            {
                AI_Timer++;
                if (AI_Timer <= 200)
                {
                    Move(Main.player[npc.target].Center + new Vector2(0, -100), 10f);
                }
                if (AI_Timer >= 200 && AI_Timer <= 203)
                {
                    npc.velocity = Vector2.Zero; // freezes npc once
                }
                else if (AI_Timer >= 200 && AI_Timer <= 500)
                {
                    npc.noGravity = false; // you can also change npc values in the ai
                    npc.noTileCollide = false; // makes the boss fall to the ground
                    int skull = Projectile.NewProjectile(npc.Center, Main.rand.NextVector2Square(-10f, 10f), ProjectileID.Skull, 30, 3f); // shoots a skull in a random direction
                    Main.projectile[skull].hostile = true; // these projectiles are normally friendly
                }
                else if (AI_Timer >= 500)
                {
                    AI_State = State_Example;
                    AI_Timer = 0;
                }
            }
        }
    }
}
