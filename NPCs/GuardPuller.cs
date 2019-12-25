using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Blockules.NPCs
{
    
    public class GuardPuller : ModNPC
    {

        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BallOfLight");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.width = 1280;
            npc.height = 720;
            npc.damage = 3;
            npc.defense = 0;
            npc.lifeMax = 2147483647;
            npc.noGravity = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            aiType = NPCID.Pinky;

        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 10.5f;
            return null;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HotGoop"), 100);
        }
    }
}
