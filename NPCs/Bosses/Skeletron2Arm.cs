using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.NPCs.Bosses
{
    public class Skeletron2Arm : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Madness");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 50;
            npc.height = 50;
            npc.damage = 20;
            npc.defense = 20;
            npc.lifeMax = 7500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = -1;
        }

        public static void SetPos(Vector2 pos, NPC npc)
        {
            npc.position = pos;
            npc.velocity = new Vector2(Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f));
        }

        public static float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public static void Move(Vector2 pos, float speeds, NPC npc, float turnRes = 10f)
        {
            float speed = speeds;
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
    }
}
