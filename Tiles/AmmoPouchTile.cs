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
using Terraria.ObjectData;
 
namespace ForgottenMemories.Tiles      
{
    public class AmmoPouchTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            //TileObjectData.addTile(Type);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            Main.tileFrameImportant[Type] = true; 
            Main.tileSolid[Type] = false;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Ammo Pouch");
			AddMapEntry(new Color(73, 60, 47), name);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16
            };

            TileObjectData.addTile(Type);
        }
 
 
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("AmmoBag"));
        }
    }
}
