using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.NPCs
{
    class BlockulesGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (!BlockulesWorld.spawnOre)
                {
                    Main.NewText("The world has been blessed with Reginite Ore", 200, 0, 0);
                    for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.00005); k++)
                    {
                        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
                        WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 4), mod.TileType("ReginiteOreTile"), false, 0f, 0f, false, true);
                    }
                    BlockulesWorld.spawnOre = true;
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Retina"));
                }
            }
        }
    }
}
