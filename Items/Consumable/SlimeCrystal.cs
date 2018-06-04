using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;
namespace ForgottenMemories.Items.Consumable
{
	public class SlimeCrystal : ModItem
	{
		public override void SetDefaults()
		{	


            item.width = 24;
            item.height = 28;
            item.value = 0;
            item.rare = 1;
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
			DisplayName.SetDefault("Slimy Crystal");
			Tooltip.SetDefault("'Formed from the remains of a powerful slimy beast' \nSpawns Gelatine ore in your world \nMay not work in multiplayer");
		}

        public override bool UseItem(Player player)
        {
			if (player.whoAmI == Main.myPlayer)
			{
				Main.NewText("Gelatine seeps into the subterranean caverns!", 0, 29, 255);
				TGEMWorld.Gelatine = true;
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 18E-05); k++)
				{
					int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
					int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
					Tile tile = Main.tile[i, j];
					if ((tile.type == 0 || tile.type == 1) && j > Main.worldSurface)
					{
						WorldGen.OreRunner(i, j, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), (ushort)mod.TileType("GelatineOre"));
					}
				}
			}
            return true;
        }
    }
}
