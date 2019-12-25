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
    public class DarkEye : ModNPC
    {
        private Player player;
        private float speed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Eye");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 5; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 5000; // The Max HP the boss has on Normal
            npc.damage = 20; // The base damage value the boss has on Normal
            npc.defense = 10; // The base defense on Normal
            npc.knockBackResist = 0f; // No knockback
            npc.width = 110;
            npc.height = 152;
            npc.value = 10000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = true; // Not affected by gravity
            npc.noTileCollide = true; // Will not collide with the tiles. 
            npc.HitSound = SoundID.NPCHit18;
            npc.DeathSound = SoundID.NPCDeath18;
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObliviumBar"), 20);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShopKey1"), 1);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}
