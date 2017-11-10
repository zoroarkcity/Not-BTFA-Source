using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles
{
    public class CosmirockTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            minPick = 180;
            soundType = 21;
            drop = mod.ItemType("SpaceRockFragment");
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cosmirock");
            AddMapEntry(new Color(175, 167, 75), name);
			dustType = 15;
			Main.tileSpelunker[mod.TileType("CosmirockTile")] = true;
			mineResist = 5f;

        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.1f;
            b = 0.1f;
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