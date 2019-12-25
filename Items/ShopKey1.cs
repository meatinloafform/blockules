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
    class ShopKey1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shop Key");
            Tooltip.SetDefault("Allows you to buy the geometrical anomaly");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.rare = 1;
            item.value = 0;
            item.maxStack = 1;
        }
    }
}
