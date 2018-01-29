using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Items.ItemSets.Acheron
{
	public class Styx : ModItem
	{
		public static int switcher = 1;
		public const int maxValue = 5;
		public override void SetDefaults()
		{	
            item.width = 24;
			item.height = 28;
            item.useStyle = 5;
            item.useTime = 10;
			Item.staff[item.type] = true;
			item.summon = true;
			item.damage = 100;
			item.noMelee = true;
			item.mana = 10;
			item.rare = 4;
			item.UseSound = SoundID.NPCDeath6;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.useAnimation = 10;
            item.useTurn = true;
			item.shoot = mod.ProjectileType("PlaceHolder");
            item.autoReuse = true;
            item.consumable = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Styx");
			Tooltip.SetDefault("[c/FFFF00:(Adjustable Weapon)]\n"
	            + "Summons a soul fountain from parallel realities that steals life away from enemies\n"
	            + "Left-click to summon the fountain on yourself\n"
	            + "Right-click to adjust fountain speed\n"
				+ "Deletes the fountain after 4th speed value\n"
				+ "Faster the fountain bobs, faster it shoots\n"
				+ "Armor penetration, range, spawning speed, damage and many other stats vary on speed of the fountain");
		}
		
		public override bool AltFunctionUse(Player player)
		{
			MyPlayer.rubixCubeSwitcher+=1;	
			switcher+= 1;
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 5;
				Item.staff[item.type] = true;
				item.summon = true;
				item.damage = 100;
				item.noMelee = true;
				item.mana = 10;
				item.UseSound = SoundID.Item30;
				item.value = Item.buyPrice(0, 10, 0, 0);
				item.autoReuse = true;
				item.shoot = mod.ProjectileType("eastistheonlygodoutthere");          			
			}
			else
			{
				item.width = 24;
                item.height = 28;
                item.useStyle = 5;
                item.useTime = 10;
				item.summon = true;
				item.damage = 100;
				item.mana = 10;
				item.UseSound = SoundID.NPCDeath6;
				item.value = Item.buyPrice(0, 10, 0, 0);
                item.useAnimation = 10;
				item.shoot = mod.ProjectileType("SoulFountain");
				Item.staff[item.type] = true;
                item.useTurn = true;
                item.autoReuse = true;
				item.noMelee = true;
                item.consumable = false;
			}
			return base.CanUseItem(player);
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (player.altFunctionUse != 2)
			{
				Vector2 SPos = new Vector2((float)player.position.X, (float)player.position.Y);
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
            return true;
        }
        public override bool UseItem(Player player)
        {
			Projectiles.Acheron.SoulFountain.projectileSpawnerTimer = 0;
			if (switcher == maxValue)
			{
				player.AddBuff(mod.BuffType("styxPlaceHolderBuff"), 10);
				switcher = 1;
				MyPlayer.rubixCubeSwitcher = 1;
				Projectiles.Acheron.SoulFountain.projectileSpawnerTimer = 0;
			}			
			return true;
        }
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "Styx", "Current Speed Value: " + switcher);
			line.overrideColor = new Color(255, 255, 255);
			tooltips.Add(line);
		}
    }
}
