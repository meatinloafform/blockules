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
    public class TaptineOreTile : ModTile
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
            drop = mod.ItemType("TaptineOre");
            AddMapEntry(new Color(200, 200, 200));
            minPick = 100;
            mineResist = 4f;
        }
    }
}
