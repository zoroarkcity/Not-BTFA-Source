using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using ForgottenMemories.Tiles;

namespace ForgottenMemories
{
	public class TGEMWorld : ModWorld
	{
        public static readonly Mod mod = ModLoader.GetMod("ForgottenMemories");
        public static bool Cryotine = false;
		public static bool Gelatine = false;
		public static bool Blight = false;
		public static bool downedGhastlyEnt = false;
		public static bool downedArterius = false;
		public static bool downedTitanRock = false;
		public static bool forestInvasionUp = false;
		public static bool downedAcheron = false;
		public static bool downedMag = false;
		public static bool downedForestInvasion = false;
		
		public static bool spawnedGems = false;
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
			downedMag = false;
			spawnedGems = false;
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
			
			if (spawnedGems) ore.Add("Gems");
			if (downedMag) downed.Add("Mag");
			
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
			spawnedGems = ore.Contains("Gems");
			downedMag = downed.Contains("Mag");
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
			flags[9] = spawnedGems;
			flags[8] = downedMag;
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
			downedForestInvasion = flags[8];
			downedAcheron = flags[7];
			spawnedGems = flags[9];
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
			if(!spawnedGems)
			{
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 15E-04); k++)
					{
						int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
						int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
						Tile tile = Main.tile[i, j];
						if ((tile.type == 368) && tile.active())
						{
							WorldGen.TileRunner(i, j, (double)WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 6), mod.TileType<TourmalineOre>());
						}
						if ((tile.type == 367) && tile.active())
						{
							WorldGen.TileRunner(i, j, (double)WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 6), mod.TileType<CitrineOre>());
						}
					}
					for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 15E-04); k++)
					{
						int i = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
						int j = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 10);
						Tile tile = Main.tile[i, j];
						if ((tile.type == 57) && tile.active())
						{
							WorldGen.TileRunner(i, j, (double)WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 6), mod.TileType<SpinelOre>());
						}
					}
				spawnedGems = true;
			}
		}
		
		public static void TryForBossMask(Vector2 center, int type)
		{
			if (Main.rand.Next(7) == 0 && !Main.expertMode)
			{
				int maskType = 0;
				if (type == mod.NPCType("TitanRock"))
				{
					maskType = mod.ItemType("TitanMask");
				}
				if (type == mod.NPCType("FaceOfInsanity"))
				{
					maskType = mod.ItemType("ArteryMask");
				}
				if (type == mod.NPCType("GhastlyEnt"))
				{
					maskType = mod.ItemType("GhastlyMask");
				}
				if (type == mod.NPCType("Acheron"))
				{
					maskType = mod.ItemType("picklerick");
				}
				if (type == mod.NPCType("MagnoliacSecondStage"))
				{
					maskType = mod.ItemType("birdman");
				}
				Item mask = Main.item[Item.NewItem((int)center.X, (int)center.Y, 0, 0, maskType, 1)];
			}
			if (Main.rand.Next(10) == 0)
			{
				int trophyType = 0;
				if (type == mod.NPCType("TitanRock"))
				{
					trophyType = mod.ItemType("TitanRockTrophy");
				}
				if (type == mod.NPCType("FaceOfInsanity"))
				{
					trophyType = mod.ItemType("ArteriusTrophy");
				}
				if (type == mod.NPCType("GhastlyEnt"))
				{
					trophyType = mod.ItemType("GhastlyEntTrophy");
				}
				if (type == mod.NPCType("Acheron"))
				{
					trophyType = mod.ItemType("AcheronTrophy");
				}
				if (type == mod.NPCType("MagnoliacSecondStage"))
				{
					trophyType = mod.ItemType("MagnoliacTrophy");
				}
				Item trophy = Main.item[Item.NewItem((int)center.X, (int)center.Y, 0, 0, trophyType, 1)];
			}
		}
	}
}
