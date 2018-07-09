using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.ID;

namespace ForgottenMemories.Tiles
{
	public class TourmalineOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSpelunker[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][368] = true;
            Main.tileMerge[368][Type] = true;
			Main.tileLighted[Type] = true;
			dustType = 240;
			drop = mod.ItemType("Tourmaline");
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Tourmaline");
			AddMapEntry(new Color(78, 132, 236), name);
			soundType = 21;
			minPick = 35;
			Main.tileSpelunker[mod.TileType("TourmalineOre")] = true;
			mineResist = 2f;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
