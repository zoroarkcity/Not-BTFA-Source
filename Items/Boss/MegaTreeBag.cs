using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Boss
{
	public class MegaTreeBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.expert = true;
			item.rare = 3;
			bossBagNPC = mod.NPCType("Ghastly_Ent");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Treasure Bag");
      Tooltip.SetDefault("Right click to open");
    }


		public override bool CanRightClick()
		{
			return true;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/MegaTreeBag"),
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
            player.QuickSpawnItem(mod.ItemType("AmberCrystal"), 1); 
			player.QuickSpawnItem(mod.ItemType("ForestEnergy"), Main.rand.Next(22, 35));
			player.QuickSpawnItem(mod.ItemType("BlossomBranch"), Main.rand.Next(5, 10));
			
			switch (Main.rand.Next(6))
			{
				case 0: 
					player.QuickSpawnItem(mod.ItemType("Fist_of_the_Hallow_Ent"), 1);
					break;
				case 1: 
					player.QuickSpawnItem(mod.ItemType("ForestBlast"), 1);
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("LeafScythe"), 1);
					break;
				case 3:
					player.QuickSpawnItem(mod.ItemType("LivingTreeSword"), 1);
					break;
				case 4:
					player.QuickSpawnItem(mod.ItemType("WoodChipper"), 1);
					break;
				case 5:
					player.QuickSpawnItem(mod.ItemType("TreeStaff"), 1);
					break;
				default:
					break;
			}
			
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("GhastlyMask"), 1);
			}			
		}
	}
}