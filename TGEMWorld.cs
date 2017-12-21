using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System;
using System.Linq;
using Terraria.ModLoader.IO;
using ForgottenMemories;

namespace ForgottenMemories
{
	public class TGEMWorld : ModWorld
	{
		public static bool Cryotine = false;
		public static bool Gelatine = false;
		public static bool Blight = false;
		public static bool downedGhastlyEnt = false;
		public static bool downedArterius = false;
		public static bool downedTitanRock = false;
		public static bool forestInvasionUp = false;
		public static bool downedAcheron = false;
		public static bool downedForestInvasion = false;
		public static int TremorTime;
		
		public override void Initialize()
		{
			Gelatine = false;
			Blight = false;
			downedArterius = false;
			Cryotine = false;
			downedGhastlyEnt = false;
			TremorTime = 0;
			downedTitanRock = false;
			Main.invasionSize = 0;
			downedAcheron = false;
			forestInvasionUp = false;
			downedForestInvasion = false;
		}
		
		public override TagCompound Save()
		{
			var downed = new List<string>();
			var ore = new List<string>();
			if (Gelatine) ore.Add("Gelatine");
			if (Cryotine) ore.Add("Cryotine");
			if (Blight) ore.Add("Blight");
			if (downedGhastlyEnt) downed.Add("GhastlyEnt");
			if (downedTitanRock) downed.Add("TitanRock");
			if (downedArterius) downed.Add("acheron");
			if (downedArterius) downed.Add("Arterius");
			if (downedForestInvasion) downed.Add("forestInvasion");
			
			return new TagCompound {
				{"downed", downed},
				{"ore", ore}
			};;
		}
		
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			var ore = tag.GetList<string>("ore");
			downedGhastlyEnt = downed.Contains("GhastlyEnt");
			downedTitanRock = downed.Contains("TitanRock");
			downedArterius = downed.Contains("Arterius");
			Gelatine = ore.Contains("Gelatine");
			Cryotine = ore.Contains("Cryotine");
			Blight = ore.Contains("Blight");
			downedForestInvasion = downed.Contains("forestInvasion");
			
			downedAcheron = downed.Contains("acheron");
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = Gelatine;
			flags[1] = Cryotine;
			flags[2] = downedGhastlyEnt;
			flags[3] = downedTitanRock;
			flags[4] = Blight;
			flags[5] = downedArterius;
			flags[6] = downedForestInvasion;
			flags[7] = downedAcheron;
			writer.Write(flags);
		}
		
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			Gelatine = flags[0];
			Cryotine = flags[1];
			downedGhastlyEnt = flags[2];
			downedTitanRock = flags[3];
			Blight = flags[4];
			downedArterius = flags[5];
			downedForestInvasion = flags[6];
			downedAcheron = flags[7];
		}
		
		public override void PostUpdate()
		{
			if(forestInvasionUp)
			{
				if(Main.invasionX == (double)Main.spawnTileX)
				{
					CustomInvasion.CheckCustomInvasionProgress();
				}
				CustomInvasion.UpdateCustomInvasion();
			}
		}
		
		public static void TryForBossMask(Vector2 center, int type)
		{
			if (Main.rand.Next(7) == 0 && !Main.expertMode)
			{
				int maskType = 0;
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("TitanRock"))
				{
					maskType = ModLoader.GetMod("ForgottenMemories").ItemType("TitanMask");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("FaceOfInsanity"))
				{
					maskType = ModLoader.GetMod("ForgottenMemories").ItemType("ArteryMask");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("GhastlyEnt"))
				{
					maskType = ModLoader.GetMod("ForgottenMemories").ItemType("GhastlyMask");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("Acheron"))
				{
					maskType = ModLoader.GetMod("ForgottenMemories").ItemType("picklerick");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("Magnoliac"))
				{
					maskType = ModLoader.GetMod("ForgottenMemories").ItemType("birdman");
				}
				Item mask = Main.item[Item.NewItem((int)center.X, (int)center.Y, 0, 0, maskType, 1)];
			}
			if (Main.rand.Next(10) == 0)
			{
				int trophyType = 0;
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("TitanRock"))
				{
					trophyType = ModLoader.GetMod("ForgottenMemories").ItemType("TitanRockTrophy");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("FaceOfInsanity"))
				{
					trophyType = ModLoader.GetMod("ForgottenMemories").ItemType("ArteriusTrophy");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("GhastlyEnt"))
				{
					trophyType = ModLoader.GetMod("ForgottenMemories").ItemType("GhastlyEntTrophy");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("Acheron"))
				{
					trophyType = ModLoader.GetMod("ForgottenMemories").ItemType("AcheronTrophy");
				}
				if (type == ModLoader.GetMod("ForgottenMemories").NPCType("Magnoliac"))
				{
					trophyType = ModLoader.GetMod("ForgottenMemories").ItemType("MagnoliacTrophy");
				}
				Item trophy = Main.item[Item.NewItem((int)center.X, (int)center.Y, 0, 0, trophyType, 1)];
			}
		}
		
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Adding BTFA Gems", delegate (GenerationProgress progress)
				{
					progress.Message = "Moulding forgotten gemstones";
					for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 35E-05); k++)
					{
						int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
						int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
						Tile tile = Main.tile[i, j];
						if ((tile.type == 368) && j > Main.worldSurface)
						{
							WorldGen.TileRunner(i, j, (double)WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 6), mod.TileType("TourmalineOre"), false, 0f, 0f, false, true);
						}
						if ((tile.type == 367) && j > Main.worldSurface)
						{
							WorldGen.TileRunner(i, j, (double)WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 6), mod.TileType("CitrineOre"), false, 0f, 0f, false, true);
						}
					}
					for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 31-05); k++)
					{
						int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
						int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
						Tile tile = Main.tile[i, j];
						if ((tile.type == 57) && j > Main.worldSurface)
						{
							WorldGen.TileRunner(i, j, (double)WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 6), mod.TileType("SpinelOre"), false, 0f, 0f, false, true);
						}
					}
				}));
			}
		}
	}
}
