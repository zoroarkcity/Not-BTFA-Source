using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
 
namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Barksteel_Smash  
{
    public class Barksteel_Smash : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 14;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 18;
            item.useAnimation = 36;
            item.hammer = 55; 
            item.useStyle = 1;
			item.scale = 1.2f;
            item.knockBack = 8f;
            item.value = 12000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barksteel Smash");
			Tooltip.SetDefault("Hitting an enemy has a chance to bludgeon enemy into confusion, tagging them\nTagged enemies will take triple the damage\nEnemies near a tagged enemy have a chance to be confused");
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            if (target.type != NPCID.TargetDummy && Main.rand.Next(3) == 0)
            {    
				target.AddBuff(mod.BuffType("TribesmanTag"),4 * 60);
				target.AddBuff(31, 4 * 60, false);
            }	
        }

		public override void ModifyHitNPC (Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if (target.FindBuffIndex(mod.BuffType("TribesmanTag")) > -1)
			{
				damage = 28+14;
			}
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Barksteel", 7);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
