using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;
namespace ForgottenMemories.Items.Consumable
{
	public class BlightCrystal : ModItem
	{
		public override void SetDefaults()
		{	


            item.width = 24;
            item.height = 28;
            item.value = 0;
            item.rare = 5;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = false;
            item.consumable = true;
            item.maxStack = 999;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Blighted Crystal");
		  Tooltip.SetDefault("'Contains immense malevolent powers' \nSpawns Blighted ore in your world's evil biome");
		}

        public override bool UseItem(Player player)
        {
			if (player.whoAmI == Main.myPlayer)
			{
				Main.NewText("A malevolent force seeps into the most pestillent stone...", 150, 31, 242);
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 22E-05); k++)
				{
					int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
					int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
					Tile tile = Main.tile[i, j];
					if ((tile.type == 203 || tile.type == 204 || tile.type == 22 || tile.type == 25 || tile.type == 112 || tile.type == 398 || tile.type == 400 || tile.type == 399 || tile.type == 401 || tile.type == 234 || tile.type == 163 || tile.type == 200) && j > Main.worldSurface)
					{
						WorldGen.OreRunner(i, j, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), (ushort)mod.TileType("BlightOre"));
					}
				}
			}
            return true;
        }
    }
}
