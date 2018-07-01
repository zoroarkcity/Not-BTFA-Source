using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles.Banner
{
	public class Banners : ModTile //Hi, please don't use this method if you're adding banners, this isnt helpful for organisation and is just a result of ww hand me downs
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(Type);
			dustType = -1;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Banner");
			AddMapEntry(new Color(13, 88, 130), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int style = frameX / 18;
			string item;
			switch (style)
			{
				case 0:
					item = "Night_Resident_Banner";
					break;
				case 1:
					item = "Galaxy_Flier_Banner";
					break;
				case 2:
					item = "Planewalker_Banner";
					break;
/*				case 3:
					item = "Arachnergy_Banner";
					break;
				case 4:
					item = "Energy_Humanoid_Banner";
					break;
				case 5:
					item = "Energy_Dweller_Banner";
					break;
				case 6:
					item = "Timber_Raider_Banner";
					break;
				case 7:
					item = "Husk_Spearman_Banner";
					break;
				case 8:
					item = "Branchwood_Thief_Banner";
					break; */
				default:
					return;
			}
			Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item));
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].frameX / 18;
				string type;
				switch (style)
				{
					case 0:
						type = "Night_Resident";
						break;
					case 1:
						type = "Galaxy_Flier";
						break;
					case 2:
						type = "Planewalker";
						break;
	/*				case 3:
						type = "Arachnergy";
						break;
					case 4:
						type = "Energy_Humanoid";
						break;
					case 5:
						type = "Energy_Dweller";
						break;
					case 6:
						type = "Timber_Raider";
						break;
					case 7:
						type = "Husk_Spearman";
						break;
					case 8:
						type = "Branchwood_Thief";
						break; */
					default:
						return;
				}
				player.NPCBannerBuff[mod.NPCType(type)] = true;
				player.hasBanner = true;
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}