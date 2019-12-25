﻿using Blockules.Projectiles;
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
    class Eclipse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eclipse");

            ItemID.Sets.Yoyo[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;
            item.knockBack = 2.5f;
            item.damage = 30;
            item.rare = 0;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 1);
            item.shoot = mod.ProjectileType<EclipseProjectile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ObliviumBar"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
