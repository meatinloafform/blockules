using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class FusionCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fusion Crystal");
            Tooltip.SetDefault("Allows extreme pressure to occur");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.rare = 3;
            item.value = 0;
            item.maxStack = 99;
        }

    }
}
