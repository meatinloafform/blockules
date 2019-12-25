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
    class ObliviumBar : ModItem
    {
        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 99;
            item.width = 16;
            item.height = 16;
            item.rare = 1;
            item.value = 0;
        }
    }
}
