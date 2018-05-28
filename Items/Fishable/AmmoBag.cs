using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace ForgottenMemories.Items.Fishable
{
	public class AmmoBag : ModItem
	{
		public override void SetStaticDefaults()
		
		{
			DisplayName.SetDefault("Ammo Pouch");
			Tooltip.SetDefault("Right Click To Open");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;  
			item.consumable = true; 
			item.width = 34;  
			item.height = 34;   
			item.rare = 4;
			item.createTile = mod.TileType("AmmoPouchTile"); 
			item.placeStyle = 0;
			item.useAnimation = 10; 
			item.useTime = 10;  
			item.useStyle = 1;


		}
		public override bool CanRightClick() 
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			List<int> Ammo = new List<int>();
			Ammo.Add(234); //Meteor Shot
			Ammo.Add(988); //Frostburn Arrow

			if (NPC.downedBoss1)
			{
				Ammo.Add(mod.ItemType("LightningArrow"));
			}				
			if (NPC.downedBoss2)
			{
				Ammo.Add(mod.ItemType("CryotineBullet")); 
			}	
			if (Main.hardMode)
			{
				Ammo.Add(1302); //High Velocity Bullet
				Ammo.Add(mod.ItemType("Geloline")); 
			}	
			if (NPC.downedPlantBoss)
			{
				Ammo.Add(1342); //Venom Bullet
				Ammo.Add(516); //Holy Arrow
				Ammo.Remove(234); //Remove Meteor Shot
				Ammo.Remove(988); //Remove Frostburn Arrow
			}
			if (NPC.downedAncientCultist)
			{
				Ammo.Add(mod.ItemType("VengeanceBullet"));
				Ammo.Remove(1302); //Remove High Velocity Bullet
			}
			
			Ammo.ToArray();
			player.QuickSpawnItem(Ammo[Main.rand.Next(0, Ammo.Count)], Main.rand.Next(400, 600));
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 3));  

		}

	}
}