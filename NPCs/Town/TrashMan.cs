using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Town
{
	[AutoloadHead]
	public class TrashMan : ModNPC
	{
		
		public override bool Autoload(ref string name)
		{
			name = "Trash Man";
			return mod.Properties.Autoload;
		}
		
		public override string Texture
		{
			get
			{
				return "ForgottenMemories/NPCs/Town/TrashMan";
			}
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trash Man");
			Main.npcFrameCount[npc.type] = 21;
			NPCID.Sets.ExtraFramesCount[npc.type] = 21;
			NPCID.Sets.AttackFrameCount[npc.type] = 2;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			animationType = NPCID.Dryad;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(3))
			{
				case 0:
					return "Danny";
				case 1:
					return "Frank";
				case 2:
					return "DeVito";
				default:
					return "Tymon";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(4))
			{
				case 0:
                    return "That's my character! I'm the trash man!";
				case 1:
					return "I throw trash all over the ring!";
				case 2: 
					return "Someone told me I should be the ref. I'm not going to be the ref! I'm a villain, don't you see?";
				default:
					return "I eat garbage!";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            if (NPC.downedBoss1)
            {
                return true;
            }
            return false;
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            shop.item[nextSlot].SetDefaults(mod.ItemType("trashlid"));
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(mod.ItemType("trashcan"));
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(mod.ItemType("EdibleTrash"));
			nextSlot++;
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DirtDagger"));
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(mod.ItemType("Hamboy"));
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(mod.ItemType("PlungerArrow"));
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.BandofRegeneration);
				nextSlot++;
			}
			
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.DemonScythe);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.EnchantedSword);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.Arkhalis);
				nextSlot++;
			}
			
			if (TGEMWorld.downedTitanRock)
			{
				shop.item[nextSlot].SetDefaults(ItemID.CrystalSerpent);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.Ichor);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.CursedFlame);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.Bananarang);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.Bladetongue);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(3210);
				nextSlot++;
			}
			
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				shop.item[nextSlot].SetDefaults(ItemID.Uzi);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.FrostStaff);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.UnholyTrident);
				nextSlot++;
			}
			
			if (NPC.downedPlantBoss)
			{
				
				shop.item[nextSlot].SetDefaults(mod.ItemType("TrashCannon"));
				nextSlot++;
			
				shop.item[nextSlot].SetDefaults(ItemID.TurtleShell);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.FrozenTurtleShell);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.CrossNecklace);
				nextSlot++;
				
			}
			
			if (NPC.downedGolemBoss)
			{
				
				shop.item[nextSlot].SetDefaults(ItemID.RodofDiscord);
				nextSlot++;
				
			}
			
			if (NPC.downedMoonlord)
			{
				shop.item[nextSlot].SetDefaults(ItemID.RainbowGun);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.PiranhaGun);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.StaffoftheFrostHydra);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(ItemID.VampireKnives);
				nextSlot++;
				
				shop.item[nextSlot].SetDefaults(1571);
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 35 + ((Main.hardMode) ? 25 : 0) + ((NPC.downedMoonlord) ? 100 : 0);
			knockback = 6f + ((Main.hardMode) ? 3f : 0);
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30 - ((Main.hardMode) ? 5 : 0) - ((NPC.downedMoonlord) ? 15 : 0);
			randExtraCooldown = 2;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("trashcan");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 20f + ((Main.hardMode) ? 2 : 0) + ((NPC.downedMoonlord) ? 2 : 0);
			randomOffset = 5f;
		}
		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TrashManGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TrashManGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TrashManGore3"), 1f);
		}
	}
}
