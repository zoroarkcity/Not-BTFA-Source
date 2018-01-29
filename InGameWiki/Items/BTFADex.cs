using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Chat;

namespace ForgottenMemories.InGameWiki.Items
{
	public class BTFADex : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forgottendex");
			Tooltip.SetDefault("Left click on Beyond the Forgotten Ages Mod's NPCs to learn information about them\nRight-click to clear the chat");
        }
		public override void SetDefaults()
		{
			item.consumable = false;
			item.useStyle = 5;
			item.useAnimation = 1;
			item.useTime = 1;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.shoot = mod.ProjectileType("InGameWikiMechanism");
			item.noMelee = true;
			item.noUseGraphic = false;
			item.autoReuse = false;
		}
		public override void HoldItem (Player player)	
		{
			player.AddBuff(mod.BuffType("Educating"), 2);
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "", "");
			line.overrideColor = new Color(100, 100, 255);
			tooltips.Add(line);
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
				}
			}
		}
    public override bool CanUseItem(Player player)
	{
	    if (player.altFunctionUse == 2)	
		{
			item.consumable = false;
			item.useStyle = 5;
			item.useAnimation = 10;
			item.useTime = 10;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.expert = true;
			Item.staff[item.type] = true; 
			item.shoot = mod.ProjectileType("placeholder");
			item.noMelee = true;
			item.noUseGraphic = false;
			item.autoReuse = false;
	    }
		else
		{
			item.consumable = false;
			item.useStyle = 5;
			item.useAnimation = 10;
			item.useTime = 10;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.expert = true;
			Item.staff[item.type] = true;
			item.shoot = mod.ProjectileType("InGameWikiMechanism");
			item.noMelee = true;
			item.noUseGraphic = false;
			item.autoReuse = false; 
		}		
		return base.CanUseItem(player);
	}
		public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
			{
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
				Main.NewText("", 0, 0, 0);
            }
            return true;
        }
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)	
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);   //this make so the projectile will spawn at the mouse cursor position
            position = SPos;
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  //this make so you can only spawn one of this projectile at the time,
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
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.anyWood = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
