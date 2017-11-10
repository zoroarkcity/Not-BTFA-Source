using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;
namespace ForgottenMemories.Items.Consumable
{
	public class CryoCrystal : ModItem
	{
		public override void SetDefaults()
		{	


            item.width = 24;
            item.height = 28;
            item.value = 0;
            item.rare = 2;
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
		  DisplayName.SetDefault("Cryo Crystal");
		  Tooltip.SetDefault("'Cold enough to even freeze magma' \nSpawns Cryotine ore in the Underground Snow");
		}

        public override bool UseItem(Player player)
        {
			if (player.whoAmI == Main.myPlayer)
			{
				Main.NewText("Ice crystallizes beneath the tundra!", 36, 242, 242);
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 22E-05); k++)
				{
					int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
					int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
					Tile tile = Main.tile[i, j];
					if ((tile.type == 147 || tile.type == 161) && j > Main.worldSurface)
					{
						WorldGen.OreRunner(i, j, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), (ushort)mod.TileType("CryotineOre"));
					}
				}
			}
            return true;
        }
    }
}
