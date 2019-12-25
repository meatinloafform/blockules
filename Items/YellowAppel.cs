﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class YellowAppel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Apple");
            Tooltip.SetDefault("hmm good taste but smal");
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
