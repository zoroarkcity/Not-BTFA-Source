using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class CrystalDrop : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.KingSlime && !Main.expertMode && Main.rand.Next(8) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimeRod"), 1); 
			}
			
			if (npc.type == 32 && Main.rand.Next(3) == 0)
			{
				int amountToDrop = Main.rand.Next(1,2);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WaterShard"), amountToDrop); 
			}
			
			if (npc.type == NPCID.AngryNimbus && Main.rand.Next(25) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LightningDagger"), 1); 
			}
			
			if (npc.type == 204 && Main.rand.Next(50) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JungleSlimePendant"), 1); 
			}
			
			if (npc.type == 147 && Main.rand.Next(50) == 0 || npc.type == 184 && Main.rand.Next(40) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSlimeNecklace"), 1); 
			}
			
			if (npc.type == 533 && Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DesertStaff"), 1); 
			}
			
			if (npc.type == 471)
			{
				int amountToDrop = Main.rand.Next(9,14);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameEmber"), amountToDrop); 
			}
			
			
			if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
			{
				int amountToDrop = Main.rand.Next(10,15);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassAlloy"), amountToDrop); 
				
				if (Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MinerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShinobiEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BerserkerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinEmblem"), 1); 
				}
			}
			
			if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
			{
				if (Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ClubMeat"), 1); 
				}
			}
			
			if (npc.type == 4 && !Main.expertMode)
			{
				switch (Main.rand.Next(2))
				{
				case 0: Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ServantStaff"), 1); 
					break;
				case 1: Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThirdEye"), 1); 
					break;
				}
			}
			
			if (npc.type == 439)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VortexSphere"), 1); 
			}
			
			if (npc.type == 483 && Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Tourmaline"), Main.rand.Next(1, 3)); 
			}
			
			if (npc.type == 481 && Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Citrine"), Main.rand.Next(1, 3)); 
			}
			
			if (npc.type == NPCID.KingSlime && NPC.downedSlimeKing && Main.rand.Next(10) == 0)
			{
				if (NPC.downedSlimeKing && Main.rand.Next(10) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimeCrystal"), 1); 
				
				else if (!NPC.downedSlimeKing)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimeCrystal"), 1); 
			}
			
			if ((npc.type == 13 || npc.type == 14 || npc.type == 15) && npc.boss == true || npc.type == 266)
			{
				if (NPC.downedBoss2 && Main.rand.Next(10) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CryoCrystal"), 1); 
				else if (!NPC.downedBoss2)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CryoCrystal"), 1); 
			}
			
			if (npc.type == 134 || npc.type == 127 || npc.type == 125 && !NPC.AnyNPCs(126) || npc.type == 126 && !NPC.AnyNPCs(125))
			{
				if (NPC.downedMechBossAny && Main.rand.Next(10) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlightCrystal"), 1); 
				else if (!NPC.downedMechBossAny)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlightCrystal"), 1); 
			}

			if (Main.invasionType == 4 && Main.rand.Next(50) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MartianYoyo"), 1); 
			}

			if (npc.value > 0.0 && Main.rand.Next(5) == 0 && Main.player[(int) Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DevilFlame"), 1); 
			}
			
			if (npc.value > 0.0 && Main.rand.Next(25) == 0 && Main.player[(int) Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Spinel"), 1); 
			}
			
			if (npc.value > 0.0 && Main.rand.Next(60) == 0 && Main.player[(int) Player.FindClosest(npc.position, npc.width, npc.height)].ZoneBeach)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pearl"), 1); 
			}
			
			if (Main.hardMode && (double) npc.value > 0.0)
			{
				if (Main.rand.Next(4) == 0 && Main.player[(int) Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDesert)
					Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("SpiritflameChunk"), 1, false, 0, false, false);
			}
			
			if (npc.type == NPCID.ManEater)
			{
				if (Main.rand.Next(30) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ExoticBoquet"), Main.rand.Next(1, 1));
				}
			}
			
			if (npc.type == NPCID.Snatcher)
			{
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ExoticBoquet"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.Reaper)
			{
				if (Main.rand.Next(17) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SubmergedAshes"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.Skeleton)
			{
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GooRattle"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.CaveBat)
			{
				if (Main.rand.Next(30) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WhackTree"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.GiantWormHead)
			{
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Axle"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.DarkCaster)
			{
				if (Main.rand.Next(18) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Atlantean"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.Piranha)
			{
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ExoticBouquet"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.DiggerHead)
			{
				if (Main.rand.Next(30) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Axle"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.GiantBat)
			{
				if (Main.rand.Next(30) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WhackTree"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.BloodCrawler)
			{
				if (Main.rand.Next(12) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Spiderbook"), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.Crab)
			{
				if (Main.rand.Next(36) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ClubFish"), Main.rand.Next(1, 1));
				}
			}
		}
	}
}