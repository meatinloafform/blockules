using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Audio;

namespace Blockules.Tile
{
    class ReginiteOreTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileShine[Type] = 975;
            Main.tileSpelunker[Type] = true;
            soundType = 21;
            drop = mod.ItemType("ReginiteOre");
            AddMapEntry(new Color(200, 0, 0));
            minPick = 0;
            mineResist = 4f;
        }
    }
}
