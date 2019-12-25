using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.NPCs
{
    public class RedAppelMinion : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Apple Servant");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 50;
            npc.defense = 6;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 14;
        }

        public static void SetPos(Vector2 pos, NPC npc)
        {
            npc.position = pos;
            npc.velocity = new Vector2(Main.rand.NextFloat(-10f,10f), Main.rand.NextFloat(-10f, 10f));
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedAppel"), 1);
        }
    }
}
