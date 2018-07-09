using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ForgottenMemories.Tiles
{
	public class WaterShard : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileShine[mod.TileType("WaterShard")] = 300;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileNoFail[Type] = true;
			Main.tileLavaDeath[Type] = false;
			Main.tileObsidianKill[mod.TileType("WaterShard")] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Height, 0);
			TileObjectData.addAlternate(3);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Height, 0);
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addAlternate(1);
			TileObjectData.addTile(Type);
			minPick = 65;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Water Shard");
			AddMapEntry(new Color(53, 201, 255), name);
			dustType = 253;
			disableSmartCursor = true;
			drop = mod.ItemType("WaterShard");
		}
		
		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Texture2D texture;
			
			
			int offset = (Main.tile[i, j].frameY <= 18) ? 
			(short)(18 * (i % 18)) :
			(short)(18 * (j % 18));
			
			if (Main.canDrawColorTile(i, j))
			{
				texture = Main.tileAltTexture[Type, (int)tile.color()];
			}
			else
			{
				texture = Main.tileTexture[Type];
			}
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(offset, tile.frameY, 16, 16), Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			return false;
		}

	/*public class WaterShardSpawn : ModWorld
	{
		public override void PostUpdate()
		{
			if (!NPC.downedBoss3)
				return;
			float num3 = (float) (Main.maxTilesX * Main.maxTilesY) * (3E-05f * (float) Main.worldRate);
			for (int index1 = 0; (double) index1 < (double) num3; ++index1)
			{
				int index2 = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
				int index3 = WorldGen.genRand.Next(10, (int) Main.worldSurface - 1);
			}
		}
	}*/
}
}
