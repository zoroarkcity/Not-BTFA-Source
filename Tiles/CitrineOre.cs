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
	public class CitrineOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSpelunker[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileMerge[Type][367] = true;
            Main.tileMerge[367][Type] = true;
			dustType = 236;
			drop = mod.ItemType("Citrine");
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Citrine");
			AddMapEntry(new Color(238, 170, 55), name);
			soundType = 21;
			minPick = 35;
			Main.tileSpelunker[mod.TileType("CitrineOre")] = true;
			mineResist = 2f;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
