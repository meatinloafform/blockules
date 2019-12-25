
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    class FlamingSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Sword");
            Tooltip.SetDefault("Shoots a flaming projectile on use");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 2;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useStyle = 1;
            item.useAnimation = 25;
            item.useTime = 20;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("FlamingBall");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
