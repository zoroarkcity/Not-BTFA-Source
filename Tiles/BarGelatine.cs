using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles
{
	public class BarGelatine : ModTile
	{
        public override void SetDefaults()
        {
			Main.tileSolidTop[Type] = true;
			Main.tileTable[Type] = true; 
			Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.addTile(Type);
            drop = mod.ItemType("GelatineBar");
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("GelatineBar"));
		}
	}

	
}
