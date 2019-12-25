using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Blockules.Items
{
    public class picel : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 10;          
            item.thrown = true;           
            item.noMelee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 1;       
            item.useAnimation = 30;  
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 1;
            item.reuseDelay = 20;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = mod.ProjectileType("picel");  
            item.shootSpeed = 8f;     
            item.useTurn = true;
            item.maxStack = 999;      
            item.consumable = true;  
            item.noUseGraphic = true;

        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}