using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles
{
    public class BlightOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            minPick = 180;
            soundType = 21;
            drop = mod.ItemType("BlightOreItem");
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Blighted Ore");
            AddMapEntry(new Color(98, 86, 104), name);
			dustType = 173;
			Main.tileSpelunker[mod.TileType("BlightOre")] = true;
			mineResist = 6f;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.3f;
            g = 0f;
            b = 0.3f;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
    }
}