using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Items.Consumable
{
	public class CosmiCrystal : ModItem
	{
		public override void SetDefaults()
		{	


            item.width = 24;
            item.height = 28;
            item.value = 0;
            item.rare = 4;
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
			DisplayName.SetDefault("Cosmic Crystal");
			Tooltip.SetDefault("'Contains a large amount of astral energy' \nSpawns Cosmorock in your world \nCheat Item, breaks in multiplayer");
		}

        public override bool UseItem(Player player)
        {
			
			if (player.whoAmI == Main.myPlayer)
			{
				Main.NewText("Your world is blessed with extraterrestrial clumps!", 175, 167, 75);
				TGEMWorld.Cosmirock = true;
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 14E-05); k++)
				{
					int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
					int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
					if (j > Main.worldSurface)
					{
						WorldGen.OreRunner(i, j, (double)WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(4, 5), (ushort)mod.TileType("CosmirockTile"));
					}
				}
			}
            return true;
        }
    }
}
