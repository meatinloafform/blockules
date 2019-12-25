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
    class FusedArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Duplicates, backup saves before using.");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 2;
            item.shoot = mod.ProjectileType("FusedArrow");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 10f;                  //The speed of the projectile
            item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FusionAppel"), 1);
            recipe.AddIngredient(mod.ItemType("FusionCrystal"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 999);
            recipe.AddRecipe();
        }
    }
}
