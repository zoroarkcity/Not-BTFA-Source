using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.NPCs.Magnoliac
{
	[AutoloadBossHead]
    public class MagnoliacSecondStage : ModNPC
    {	
	    public bool Acorn = false;
	    public bool HoverOveringStage = true;
		public static int AcornTimer = 0;
		public static int ExpertTimer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magnoliac");
			Main.npcFrameCount[npc.type] = 10; // to be changed
		}
		
        public override void SetDefaults()
        {
			npc.aiStyle = 2;//custom ai
            npc.lifeMax = 2750;
            npc.damage = 32; 
            npc.defense = 8; 
            npc.knockBackResist = 0f;
            npc.width = 100; // change after testing
            npc.height = 150; // change after testing
            npc.value = Item.buyPrice(0, 0, 80, 0); // change
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
			npc.boss = true;  
            npc.HitSound = SoundID.NPCHit32;// to be changed
            npc.DeathSound = SoundID.NPCDeath31;// to be changed
            npc.netAlways = true;
			npc.scale = 1f;
			bossBag = mod.ItemType("MagnoliacTreasureBag");
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/ForestArmy");
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity / npc.velocity, mod.GetGoreSlot("Gores/SentryStone1"), 1f); // gore upon death
            }
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.3f);
		}	
        public override void BossLoot(ref string name, ref int potionType)
        {
			potionType = ItemID.LesserHealingPotion; //Applies to Bosses regardless of world difficulty- pre hm is always lesser, hm is always greater   			
			TGEMWorld.downedMag = true;
            if (Main.expertMode) //if it's expert mode the treasure bag will drop
            {
                npc.DropBossBags();
            }
			else
			{
				switch (Main.rand.Next(5))
				{
					case 0: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Beechorang"));
						break;
					case 1: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Dandelion_Staff"));
						break;
					case 2:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SequoiaWaraxe"));
						break;
					case 3:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Acorn_Launcher"));
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Acorn"), Main.rand.Next(30, 60));
						break;
					case 4:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GhastlyKnife"));
						break;
					default:
						break;
				}
			}
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Magnoliac/MagnoliacGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Magnoliac/MagnoliacGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Magnoliac/MagnoliacGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Magnoliac/MagnoliacGore4"), 1f);
        }
		public override void AI()
        {
			AcornTimer++;
			ExpertTimer++;
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			float num1 = 4f;
            float number2 = 0.25f;
            Vector2 vektor2 = new Vector2(npc.Center.X, npc.Center.Y);
            float number3 = Main.player[npc.target].Center.X - vektor2.X;
            float number4 = (float) ((double) Main.player[npc.target].Center.Y - (double) vektor2.Y - 400.0);
            float num5 = (float) Math.Sqrt((double) number3 * (double) number3 + (double) number4 * (double) number4);
            float num6;
            float num7;
			if (npc.position.Y < player.position.Y - 2500 && npc.position.X < player.position.X - 2500 && npc.life < (npc.lifeMax - 1))
			{
				npc.active = false;		
			}
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
	  	    if (Main.player[npc.target].dead)
			{
				npc.active = false;
			}
			if (HoverOveringStage)
			{
				npc.aiStyle = 0;
				if ((double) num5 < 20.0)
                {
                    num6 = npc.velocity.X;
                    num7 = npc.velocity.Y;
                }
                else
                {
                    float num8 = num1 / num5;
                    num6 = number3 * num8;
                    num7 = number4 * num8;
                }
                if ((double) npc.velocity.X < (double) num6)
                {
                    npc.velocity.X += number2;
                    if ((double) npc.velocity.X < 0.0 && (double) num6 > 0.0)
                        npc.velocity.X += number2 * 4f;
                }
                else if ((double) npc.velocity.X > (double) num6)
                {
                    npc.velocity.X -= number2;
                    if ((double) npc.velocity.X > 0.0 && (double) num6 < 0.0)
                        npc.velocity.X -= number2 * 4f;
                }
                if ((double) npc.velocity.Y < (double) num7)
                {
                    npc.velocity.Y += number2;
                    if ((double) npc.velocity.Y < 0.0 && (double) num7 > 0.0)
                        npc.velocity.Y += number2 * 4f;
                }
                else if ((double) npc.velocity.Y > (double) num7)
                {
                    npc.velocity.Y -= number2;
                    if ((double) npc.velocity.Y > 0.0 && (double) num7 < 0.0)
                        npc.velocity.Y -= number2 * 4f;
                }
				if (AcornTimer >= 81)//SHOOT ACORN AT MAXHP-2K
				{
					AcornTimer = 0;
					Main.PlaySound(19, (int) npc.position.X, (int) npc.position.Y, 1, 1f, 0.0f);
				    float Speed = 16f;  // projectile speed
				    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
				    int damage = 20;  // projectile damage
				    int type = mod.ProjectileType("AcornSecondStage");  //put your projectile
				    int num54 = Projectile.NewProjectile(npc.position.X, npc.position.Y + 50, 0f, 2f, type, damage, 0f, 0);	    
				}
				if (Main.expertMode && ExpertTimer >= 60 * 3) //EXPERT STAGE
			    {
				    ExpertTimer = 0;	
				    for (int i = 0; i < (Main.rand.Next(5) + 15); i++)    // More dust
				    {
					    Main.PlaySound(SoundID.Item17, npc.position);
					    float Speed = 20f;  // projectile speed
					    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
					    int damage = 8;  // projectile damage
					    int type = mod.ProjectileType("ExpertMagnoliac");  //put your projectile
					    float rotation = (float)Math.Atan2(vector8.Y - (npc.position.Y), vector8.X - (npc.position.X + (npc.width * 0.5f) - 130 + (Main.rand.Next(2600) / 10)));
					    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1) + 10, type, damage, 0f, 0);	
				    }
			}
			}
			///////////////////////////1 STAGE ENDS HERE///////////////////////////////
		}
		const int Frame_With_Acorn_1 = 0;
		const int Frame_With_Acorn_2 = 1;
		const int Frame_With_Acorn_3 = 2;
		const int Frame_With_Acorn_4 = 3;
		const int Frame_With_Acorn_5 = 4;
		const int Frame_With_Acorn_6 = 5;
		const int Frame_With_Acorn_7 = 6;
		const int Frame_Without_Acorn_1 = 7;
		const int Frame_Without_Acorn_2 = 8;
		const int Frame_Without_Acorn_3 = 9;

		public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = npc.direction;
			{
				npc.frameCounter++;
				if (npc.frameCounter < 3)
				{
					npc.frame.Y = Frame_With_Acorn_1 * frameHeight;
				}
				else if (npc.frameCounter < 6)
				{
					npc.frame.Y = Frame_With_Acorn_2 * frameHeight;
				}
				else if (npc.frameCounter < 9)
				{
					npc.frame.Y = Frame_With_Acorn_3 * frameHeight;
				}
				else if (npc.frameCounter < 12)
				{
					npc.frame.Y = Frame_With_Acorn_4 * frameHeight;
				}
				else if (npc.frameCounter < 15)
				{
					npc.frame.Y = Frame_With_Acorn_5 * frameHeight;
				}
				else if (npc.frameCounter < 18)
				{
					npc.frame.Y = Frame_With_Acorn_6 * frameHeight;
				}
				else if (npc.frameCounter < 21)
				{
					npc.frame.Y = Frame_Without_Acorn_1 * frameHeight;
				}
				else if (npc.frameCounter < 41)
				{
					npc.frame.Y = Frame_Without_Acorn_2 * frameHeight;
				}
				else if (npc.frameCounter < 61)
				{
					npc.frame.Y = Frame_Without_Acorn_3 * frameHeight;
				}
				else if (npc.frameCounter < 81)
				{
					npc.frame.Y = Frame_With_Acorn_1 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
		}
	    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f; // larger health bar
			return null;
        }
    }
}