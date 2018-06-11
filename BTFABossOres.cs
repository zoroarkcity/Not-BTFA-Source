using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories
{
    public class BTFABossOres : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == 50)
            {
                if (!TGEMWorld.Gelatine)
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
            }
			if (npc.type == 13 || npc.type == 266)
            {
                if (!TGEMWorld.Cryotine)
                {                                                          
                    Main.NewText("Ice crystallizes beneath the tundra!", 36, 242, 242);
    				TGEMWorld.Cryotine = true;
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
            }
			if (npc.type == 134)
            {
                if (NPC.downedMechBoss2 && NPC.downedMechBoss3 && !TGEMWorld.Blight)
                {                                                          
					Main.NewText("A malevolent mineral seeps into the most pestillent stone...", 221, 153, 255);
				    TGEMWorld.Blight = true;
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
            }
			if (npc.type == 125 && !NPC.AnyNPCs(126))
            {
                if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && !TGEMWorld.Blight)
                {                                                          
					Main.NewText("A malevolent mineral seeps into the most pestillent stone...", 221, 153, 255);
				    TGEMWorld.Blight = true;
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
            }
			else if (npc.type == 126 && !NPC.AnyNPCs(125))
            {
                if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && !TGEMWorld.Blight)
                {                                                          
					Main.NewText("A malevolent mineral seeps into the most pestillent stone...", 221, 153, 255);
				    TGEMWorld.Blight = true;
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
            }
			if (npc.type == 127)
            {
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && !TGEMWorld.Blight)
                {                                                          
					Main.NewText("A malevolent mineral seeps into the most pestillent stone...", 221, 153, 255);
				    TGEMWorld.Blight = true;
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
            }
			if (npc.type == mod.NPCType("TitanRock"))
            {
                if (!TGEMWorld.Cosmirock)
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
            }
        }
    }
}