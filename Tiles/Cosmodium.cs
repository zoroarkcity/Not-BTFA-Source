using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles
{
    public class Cosmodium : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;

            Main.tileLighted[Type] = true;
            mineResist = 12f;
            minPick = 220;
            soundType = 27;
            soundStyle = 2;
            drop = mod.ItemType("CosmodiumOre");
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cosmodium Ore");
            AddMapEntry(new Color(19, 163, 189), name);
			Main.tileSpelunker[mod.TileType("Cosmodium")] = true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 0f;
            b = 0.7f;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override bool KillSound(int i, int j)
        {
            Main.PlaySound(2, i * 16, j * 16, 27);
            return false;
        }
    }


}