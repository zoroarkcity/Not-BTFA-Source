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
        bool hasDashed = false;
        Int16 dashes = 0;
        Int16 pygmyDashes = 0;
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

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(phase2);
            writer.Write(phase3);
            writer.Write(hasDashed);
            writer.Write(dashes);
            writer.Write(pygmyDashes);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            phase2 = reader.ReadBoolean();
            phase3 = reader.ReadBoolean();
            hasDashed = reader.ReadBoolean();
            dashes = reader.ReadInt16();
            pygmyDashes = reader.ReadInt16();
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

        public void SpawnPygmies()
        {
            if (Main.netMode != 1)
            {
                int cap = Main.expertMode ? 5 : 3;
                for (int i = 0; i < cap; i++)
                {
                    int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BjornPygmy"));
                    if (n < 200)
                    {
                        Main.npc[n].velocity.X = (float)Main.rand.Next(-15, 16) * 0.4f;
                        Main.npc[n].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.4f;
                        if (Main.netMode == 2)
                            NetMessage.SendData(23, -1, -1, null, n, 0f, 0f, 0f, 0, 0, 0);
                    }
                }
            }
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

            if (hasDashed)
            {
                if (phase3)
                {
                    if (Main.rand.Next(8) == 0) //spawn spores during charges in phase 3
                    {
                        if (Main.netMode != 1)
                        {
                            float SpeedX = Main.rand.Next(-25, 26) * 0.15f;
                            float SpeedY = Main.rand.Next(-25, 26) * 0.15f;
                            int damage = npc.damage / 5;
                            Projectile.NewProjectile(npc.position.X + Main.rand.Next(npc.width), npc.position.Y + Main.rand.Next(npc.height), SpeedX, SpeedY, mod.ProjectileType("BjornSpore"), damage, 0f, Main.myPlayer);
                        }
                    }
                }
                else //run check when not in phase 3
                {
                    if (npc.life < npc.lifeMax / 3)
                    {
                        if (!phase2)
                            SpawnPygmies();

                        phase2 = true;
                        phase3 = true;

                        Main.PlaySound(15, (int)npc.Center.X, (int)npc.Center.Y, 0);

                        //add dust here

                        npc.netUpdate = true;
                    }
                }
            }
            else if (npc.velocity.X == 6f || npc.velocity.X == -6f) //while dashing at full speed (this runs ONCE per dash when bjorn hits full speed)
            {
                hasDashed = true;

                dashes++;
                if (dashes == 3) //dash counter
                {
                    dashes = 0;
                    if (Main.netMode != 1)
                    {
                        int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BjornLilypad"));
                        if (Main.netMode == 2 && n < 200)
                            NetMessage.SendData(23, -1, -1, null, n, 0f, 0f, 0f, 0, 0, 0);

                        if (phase3)
                        {
                            int n1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BjornLilypadPoison"));
                            if (n1 < 200)
                            {
                                Main.npc[n1].velocity.X = (float)Main.rand.Next(-20, -6) * 1.2f;
                                Main.npc[n1].velocity.Y = (float)Main.rand.Next(-5, 0) * 1.2f;
                                Main.npc[n1].ai[0] = npc.damage / 5;
                                if (Main.netMode == 2)
                                    NetMessage.SendData(23, -1, -1, null, n1, 0f, 0f, 0f, 0, 0, 0);
                            }

                            int n2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BjornLilypadPoison"));
                            if (n2 < 200)
                            {
                                Main.npc[n2].velocity.X = (float)Main.rand.Next(5, 21) * 1.2f;
                                Main.npc[n2].velocity.Y = (float)Main.rand.Next(-5, 0) * 1.2f;
                                Main.npc[n2].ai[0] = npc.damage / 5;
                                if (Main.netMode == 2)
                                    NetMessage.SendData(23, -1, -1, null, n2, 0f, 0f, 0f, 0, 0, 0);
                            }
                        }
                    }
                }

                if (phase2)
                {
                    pygmyDashes++;
                    if (pygmyDashes == 5)
                    {
                        pygmyDashes = 0;
                        SpawnPygmies();
                    }
                }
                else //only run when in phase1
                {
                    if (npc.life < npc.lifeMax * 2 / 3) //entering phase 2
                    {
                        phase2 = true;
                        SpawnPygmies();
                        Main.PlaySound(15, (int)npc.Center.X, (int)npc.Center.Y, 0);

                        //insert dust here
                    }
                }

                npc.netUpdate = true;
            }

			if (npc.velocity.X > -1f && npc.velocity.X < 1f) //when coming to a stop after charge
			{
				if (hasDashed)
				{
					hasDashed = false;

                    if (Main.netMode != 1)
                    {
                        for (int index = 0; index < 15; ++index) //add some dust + a sound
                        {
                            float SpeedX = Main.rand.Next(-20, 21) * 0.25f;
                            float SpeedY = Main.rand.Next(-20, 6) * 0.25f;
                            int damage = npc.damage / 5;
                            Projectile.NewProjectile(npc.Center.X + SpeedX, npc.Center.Y + SpeedY, SpeedX, SpeedY, mod.ProjectileType("BjornSpore"), damage, 0f, Main.myPlayer);
                        }
                    }

                    npc.netUpdate = true;
                }

                //activate expert mode leapdive every X charges
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
