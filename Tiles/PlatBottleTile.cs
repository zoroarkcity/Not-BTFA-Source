using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles
{
	public class PlatBottleTile : ModTile
	{
		public override void SetDefaults()
		{
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileLavaDeath[Type] = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.addTile(Type);
            drop = mod.ItemType("PlatInABottle");
            //Can't use this since texture is virtical.
            //animationFrameHeight = 56;
        }

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.0f;
			g = 1f;
			b = 1f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("PlatInABottle"));
		}
	}

	
}
