using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class ShardOfDead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("one time use. Gives free Robux");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.melee = false;
            item.width = 32;
            item.height = 32;
            item.value = 100;
        }

        public override bool UseItem(Player player)
        {
            player.position = new Microsoft.Xna.Framework.Vector2 Main.worldSurface * 0.35;
        }
    }
}
