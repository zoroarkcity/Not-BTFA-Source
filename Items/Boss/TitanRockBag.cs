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
	public class TitanRockBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.expert = true;
			item.rare = 4;
			bossBagNPC = mod.NPCType("TitanRock");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Treasure Bag");
      Tooltip.SetDefault("Right click to open");
    }
	    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/TitanRockBag"),
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
		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			int amountToDrop = Main.rand.Next(16,24);
			player.QuickSpawnItem(mod.ItemType("SpaceRockFragment"), amountToDrop);
			
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("TitanMask"), 1);
			}
			
			switch (Main.rand.Next (8))
			{
				case 0:
					player.QuickSpawnItem(mod.ItemType("LaserbladeKatana"), 1);
					break;
				case 1:
					player.QuickSpawnItem(mod.ItemType("LaserbeamStaff"), 1);
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("Needler"), 1);
					break;
				case 3:
					player.QuickSpawnItem(mod.ItemType("BeamSlicer"), Main.rand.Next(240, 300));
					break;
				case 4:
					player.QuickSpawnItem(mod.ItemType("EnergizedBlaster"), 1);
					break;
				case 5:
					player.QuickSpawnItem(mod.ItemType("TitanSpin"), 1);
					break;
				case 6:
					player.QuickSpawnItem(mod.ItemType("TitanicCrusher"), 1);
					break;
				case 7:
					player.QuickSpawnItem(mod.ItemType("AncientLauncher"), 1);
					player.QuickSpawnItem(771, Main.rand.Next(120, 160));
					break;
			}
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("TitanMask"), 1);
			}
			
			player.QuickSpawnItem(mod.ItemType("EnergyStone"), 1);
		}
	}
}
