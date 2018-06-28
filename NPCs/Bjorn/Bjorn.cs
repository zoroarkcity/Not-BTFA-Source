using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Bjorn
{
	[AutoloadBossHead]
    public class Bjorn : ModNPC
    {
        int dashes = 0;
		int pygmyDashes = 4;
		bool hasDashed = false;
		bool phase2 = false;
		bool phase3 = false;
		
		public override void SetDefaults()
        {
			npc.aiStyle = 26;
			aiType = 508;
			npc.width = 30;
			npc.height = 40;
			npc.damage = 30;
            npc.defense = 10;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 2, 0, 0);
            npc.boss = true;
			npc.lifeMax = 2400;
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
			bossBag = mod.ItemType("MegaTreeBag");
            music = MusicID.Boss1;
			npc.npcSlots = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bjorn");
			Main.npcFrameCount[npc.type] = 4;
        }

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.LesserHealingPotion; //Applies to Bosses regardless of world difficulty- pre hm is always lesser, hm is always greater   
		}		

		public override void AI()
		{
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			
			Vector2 newMove = npc.Center - player.Center;
			if (!player.active || player.dead || newMove.Length() >= 3000)
            {
                npc.TargetClosest(false);
				
				if (npc.timeLeft > 60)
				{
					npc.timeLeft = 60;
				}
            }

			if (npc.velocity.X == 6f || npc.velocity.X == -6f)
			{
				if (!hasDashed)
				{
					hasDashed = true;
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SlimeSpiked); //placeholder for frog, presumably slime AI

					dashes++;
					if (dashes == 3)
					{
						dashes = 0;
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Pinky);
					}

					if (phase2)
					{
						pygmyDashes++;
						if (pygmyDashes == 5)
						{
							pygmyDashes = 0;
							NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Undead_Heart"));
						}
					}
					else phase2 = npc.life < npc.lifeMax * 2 / 3;
				}

				if (phase3)
				{
					if (Main.rand.Next(10) == 0)
					{
						float SpeedX = Main.rand.Next(-20, 21) * 0.8f;
						float SpeedY = Main.rand.Next(-20, 21) * 0.8f;
						int p = Projectile.NewProjectile(npc.position.X + Main.rand.Next(npc.width), npc.position.Y + Main.rand.Next(npc.height), SpeedX, SpeedY, 567 + Main.rand.Next(2), npc.damage / 5, 0f, Main.myPlayer);
						Main.projectile[p].friendly = false;
						Main.projectile[p].hostile = true;
						Main.projectile[p].netUpdate = true;
					}
				}
				else phase3 = npc.life < npc.lifeMax / 3;
			}

			if (npc.velocity.X > -1 && npc.velocity.X < 1)
			{
				if (hasDashed)
				{
					hasDashed = false;

					for (int index = 0; index < 9; ++index) //replace with lichen, add some dust + a sound
					{
						float SpeedX = Main.rand.Next(-20, 21) * 0.8f;
						float SpeedY = Main.rand.Next(-20, 5) * 0.8f;
						Projectile.NewProjectile(npc.Center.X + SpeedX, npc.Center.Y + SpeedY, SpeedX, SpeedY, mod.ProjectileType("SpinalBoltEvil"), npc.damage / 5, 0f, Main.myPlayer, 1f, 0f);
					}
				}
			}
		}

		public override void FindFrame(int frameHeight)
		{
			if (npc.velocity.Y == 0.0)
			{
				if (npc.direction == 1)
					npc.spriteDirection = 1;
				if (npc.direction == -1)
					npc.spriteDirection = -1;
				
				npc.frameCounter += 0.25f; 
				npc.frameCounter %= 4; 
				int frame = (int)npc.frameCounter; 
				npc.frame.Y = frame * frameHeight;
			}
		}

	    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f; // larger health bar
			return null;
        }		

		public override void NPCLoot()
		{
			TGEMWorld.downedGhastlyEnt = true;

			if (Main.expertMode)
			{
                npc.DropBossBags();
			}
			else
			{
			    switch (Main.rand.Next(6))
			    {
				    case 0: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Fist_of_the_Hallow_Ent")));
					    break;
				    case 1: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ForestBlast")));
					    break;
				    case 2: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("LeafScythe")));
					    break;
				    case 3: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("LivingTreeSword")));
					    break;
				    case 4: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("WoodChipper")));
					    break;
				    case 5: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("TreeStaff")));
					    break;
				    default:
					    break;
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ForestEnergy")), Main.rand.Next(22, 35));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("BlossomBranch")), Main.rand.Next(5, 10));
			    TGEMWorld.TryForBossMask(npc.Center, npc.type);
				}
			}
		}
    }
}
