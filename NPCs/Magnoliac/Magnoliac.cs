using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Magnoliac
{
	[AutoloadBossHead]
    public class Magnoliac : ModNPC
    {	
	    public bool SecondStage = false;
	    public bool FlySeed = false;
	    public bool VineSeed = false;
	    public bool Acorn = false;
		public static int FlySeedTimer = 0;
		public static int AcornTimer = 0;
		public static int VineSeedTimer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magnoliac");
			Main.npcFrameCount[npc.type] = 10; // to be changed
		}
		
        public override void SetDefaults()
        {
			npc.aiStyle = 2;//custom ai
            npc.lifeMax = 3500; 
            npc.damage = 25; 
            npc.defense = 14;
            npc.knockBackResist = 0f;
            npc.width = 100; // change after testing
            npc.height = 150; // change after testing
            npc.value = Item.buyPrice(0, 0, 80, 0); // change
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit32;// to be changed
            npc.DeathSound = SoundID.NPCDeath31;// to be changed
            npc.netAlways = true;
			npc.scale = 1f;
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Forests_Army");
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
		public override void NPCLoot()
		{
			NPC.NewNPC((int)(npc.position.X), (int)(npc.position.Y + 160), (mod.NPCType("MagnoliacSwitchingPhase")));
			Main.NewText("Magnoliac's bulb opens with your force!", 175, 75, 255);
		}
		public override void AI()
        {
			FlySeedTimer++;
			AcornTimer++;
			VineSeedTimer++;
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			float num1 = 4f;
            float number2 = 0.25f;
            Vector2 vektor2 = new Vector2(npc.Center.X, npc.Center.Y);
            float number3 = Main.player[npc.target].Center.X - vektor2.X;
            float number4 = (float) ((double) Main.player[npc.target].Center.Y - (double) vektor2.Y - 450.0);
            float num5 = (float) Math.Sqrt((double) number3 * (double) number3 + (double) number4 * (double) number4);
            float num6;
            float num7;
			if (npc.position.Y < player.position.Y - 2500 && npc.life < (npc.lifeMax - 1))
			{
				npc.active = false;		
			}
			float DistanceBeetweenBossnPlayer = 200f;
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
	  	    if (Main.player[npc.target].dead)
			{
				npc.active = false;
			}
		    if (npc.life <= (npc.lifeMax / 4) && Main.expertMode)//expert effect
			{
			    SecondStage = true;	
			}
			if (player.active && npc.life >= npc.lifeMax - 500 && Main.expertMode && (double) Vector2.Distance(npc.Center, player.Center) >= (double) DistanceBeetweenBossnPlayer)//SWOOP DOWN STAGE
			{
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
                float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
                float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
                float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
				npc.velocity.X = num2 * num4 / 1.1f;
                npc.velocity.Y = num3 * num4 / 1.1f;
			}
			if (npc.life <= npc.lifeMax - 500)
			{
				FlySeed = true;
			}
			if (FlySeedTimer >= 60 && FlySeed) //SEED TIME MAXHP-500
		    {
			    FlySeedTimer = 0;
				Main.PlaySound(SoundID.Item17, npc.position);
				float Speed = 16f;  // projectile speed
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
				int damage = 7;  // projectile damage
				int type = mod.ProjectileType("FlySeed");  //put your projectile
				float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
            }
			if (npc.life <= npc.lifeMax - 1999)
			{
				npc.aiStyle = 2;
                VineSeed = true;				
                Acorn = true;				
			}					
			if (npc.life <= npc.lifeMax - 2000) // HOVER OVER AND SHOOT ACORNS STAGE
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
				if (AcornTimer >= 51)//SHOOT ACORN AT MAXHP-2K
				{
					AcornTimer = 0;
					Main.PlaySound(19, (int) npc.position.X, (int) npc.position.Y, 1, 1f, 0.0f);
				    float Speed = 16f;  // projectile speed
				    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
				    int damage = 20;  // projectile damage
				    int type = mod.ProjectileType("Acorn");  //put your projectile
				    int num54 = Projectile.NewProjectile(npc.position.X, npc.position.Y + 50, 0f, 2f, type, damage, 0f, 0);	    
				}
				if ((npc.life <= npc.lifeMax / 2) && VineSeedTimer >= 90 && VineSeed) // SHOOT SEEDS THAT CREATES VINES AT HALF HP
				{
					VineSeedTimer = 0;
					Main.PlaySound(SoundID.NPCHit28, npc.position);
				    float Speed = 16f;  // projectile speed
				    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 4), npc.position.Y + (npc.height / 4));
				    int damage = 7;  // projectile damage
				    int type = mod.ProjectileType("VineSeed");  //put your projectile
				    float rotation = (float)Math.Atan2(vector8.Y - ((player.position.Y) + (player.height * 0.5f)), vector8.X - ((player.position.X) + (player.width * 0.5f)));
				    int num54 = Projectile.NewProjectile(vector8.X * 1.3f, vector8.Y * 1.3f, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
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
			if (npc.life >= npc.lifeMax - 1999)
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
					npc.frame.Y = Frame_With_Acorn_1 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
			else if (npc.life <= npc.lifeMax - 1999)
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
				else if (npc.frameCounter < 31)
				{
					npc.frame.Y = Frame_Without_Acorn_2 * frameHeight;
				}
				else if (npc.frameCounter < 41)
				{
					npc.frame.Y = Frame_Without_Acorn_3 * frameHeight;
				}
				else if (npc.frameCounter < 51)
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