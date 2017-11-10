using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Tiles
{
	public class GelatineOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			dustType = 252;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Gelatine Ore");
			drop = mod.ItemType("GelatineOreItem");
			AddMapEntry(new Color(0, 0, 255), name);
			soundType = 21;
			Main.tileSpelunker[mod.TileType("GelatineOre")] = true;
			mineResist = 2f;

		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}