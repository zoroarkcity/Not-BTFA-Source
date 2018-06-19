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
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Biomes;
using Terraria.GameContent.Events;
using Terraria.GameContent.Generation;
using Terraria.GameContent.Tile_Entities;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.World.Generation;
using System.IO;
using Terraria;
using Terraria.ModLoader;

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
		public static bool MagnoliacBool = false;
		public static bool GentBool = false;	
		public static bool spawnedGems = false;
		public static int TremorTime;

		public static bool Cosmirock = false;
		
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
			Cosmirock = false;
			MagnoliacBool = false;
			GentBool = false;
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

			if (Cosmirock) ore.Add ("Cosmirock");
			
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
			Cosmirock = ore.Contains("Cosmirock");				
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
			flags[10] = Cosmirock;
			flags[11] = GentBool;
			flags[12] = MagnoliacBool;
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
			Cosmirock = flags[10];
			GentBool = flags[11];
			MagnoliacBool = flags[12];
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
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
			tasks.Insert(genIndex + 1, new PassLegacy("BTFA Gems", delegate (GenerationProgress progress)
			{	
				int spinelGen = 0;
				while (spinelGen <= 200)  //this allows us to have X ore veins increase or decrease it at your will
				{
					int spinelX = Main.rand.Next(Main.maxTilesX);
					double spinelNum = (int) (Main.rockLayer + Main.rockLayer + (double) Main.maxTilesY) / 3.0;
					int spinelY = Main.rand.Next(Main.maxTilesY);
					if (spinelX >= Main.maxTilesX - 50)
					{
						spinelX = spinelX - 50;
					}
					if (spinelX <= 50)
					{
						spinelX = spinelX + 50;
					}						
					if ((Main.tile[spinelX, spinelY].type == 57))
					{
						spinelGen++;
						WorldGen.TileRunner(spinelX, spinelY, (double) WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), mod.TileType<SpinelOre>(), false, 0.0f, 0.0f, false, true);
					}
				
				}
				int tourmalineGen = 0;
				while (tourmalineGen <= 900)  //this allows us to have X ore veins increase or decrease it at your will
				{
					int tourmalineX = Main.rand.Next(Main.maxTilesX);
					double spinelNum = (int) (Main.rockLayer + Main.rockLayer + (double) Main.maxTilesY) / 3.0;
					int tourmalineY = Main.rand.Next(Main.maxTilesY);
					if (tourmalineX >= Main.maxTilesX - 50)
					{
						tourmalineX = tourmalineX - 50;
					}
					if (tourmalineX <= 50)
					{
						tourmalineX = tourmalineX + 50;
					}						
					if ((Main.tile[tourmalineX, tourmalineY].type == 368))
					{
						tourmalineGen++;
						WorldGen.TileRunner(tourmalineX, tourmalineY, (double) WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), mod.TileType<TourmalineOre>(), false, 0.0f, 0.0f, false, true);
					}
				
				}
				int citrineGen = 0;
				while (citrineGen <= 900)  //this allows us to have X ore veins increase or decrease it at your will
				{
					int citrineX = Main.rand.Next(Main.maxTilesX);
					double spinelNum = (int) (Main.rockLayer + Main.rockLayer + (double) Main.maxTilesY) / 3.0;
					int citrineY = Main.rand.Next(Main.maxTilesY);
					if (citrineX >= Main.maxTilesX - 50)
					{
						citrineX = citrineX - 50;
					}
					if (citrineX <= 50)
					{
						citrineX = citrineX + 50;
					}						
					if ((Main.tile[citrineX, citrineY].type == 367))
					{
						citrineGen++;
						WorldGen.TileRunner(citrineX, citrineY, (double) WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), mod.TileType<CitrineOre>(), false, 0.0f, 0.0f, false, true);
					}
				
				}
			}));	
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
				if (type == mod.NPCType("Ghastly_Ent"))
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
				if (type == mod.NPCType("Ghastly_Ent"))
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
