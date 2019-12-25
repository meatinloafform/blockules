using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Blockules.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class BallOfLight : ModNPC
    {

        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BallOfLight");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 32;
            npc.height = 32;
            npc.damage = 3;
            npc.defense = 0;
            npc.lifeMax = 100;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WoodSquare"), 100);
        }
        public override void AI()
        {
            Target();
            npc.position = player.position;
        }

        public void Target()
        {
            player = Main.player[npc.target];
        }

        public void SetVel(float x, float y)
        {
            npc.velocity = new Vector2(x,y);
        }
    }
}
