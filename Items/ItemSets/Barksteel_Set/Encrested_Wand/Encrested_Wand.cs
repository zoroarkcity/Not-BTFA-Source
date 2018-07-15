using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
 
namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Encrested_Wand    
{
    public class Encrested_Wand : ModItem
    {
		public override void SetDefaults()
		{
			item.damage = 12;
			item.noMelee = true;
			item.magic = true;
			item.melee = false;
			item.width = 30;
			item.height = 30;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.shootSpeed = 0f;
			item.knockBack = 0f;
			Item.staff[item.type] = true;
			item.autoReuse = true;
			item.rare = 2;
			item.shoot = mod.ProjectileType("Encrested_Wand_Projectile_Alt");
			item.value = 12000;
			item.UseSound = SoundID.Item66;
			item.useTurn = true;
			item.mana = 10;
		}
		public override void HoldItem (Player player)	
		{
			if (player == Main.player[Main.myPlayer])
            {
                for (int index2 = 0; index2 < 1; ++index2)
				{
                    if (player.active && (double) Vector2.Distance(player.Center, player.Center) <= (double) 300f)
                    {
                        player.statDefense += 4;
                    }
                }
				
            }
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Encrested Wand");
			Tooltip.SetDefault("Holding the weapon will increase you and nearby allies defense by 4\nAllows player to create 2 magical barriers that can hold any enemy\nBarriers change shape depending on closest enemy near the barrier and deal more damage\nBarries won't land on platforms\nRight Click to remove all barriers");
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.GetModPlayer<WhirlingWorldsPlayer>().EncrestedWandProjectileCount > 2)
            { 
                return false;
            }
            return true;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			for (int k = 0; k < Main.projectile.Length; k++)
            { 
		        Projectile proj = Main.projectile[k];
				if (proj.active && proj.type == mod.ProjectileType("Encrested_Wand_Projectile") && proj.owner == player.whoAmI)
                { 
                    proj.Kill();
					player.GetModPlayer<WhirlingWorldsPlayer>().EncrestedWandProjectileCount = 1;
                }
            }
            return false;
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)	
        {
			player.GetModPlayer<WhirlingWorldsPlayer>().EncrestedWandProjectileCount += 1;
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            position = SPos;
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;			
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
