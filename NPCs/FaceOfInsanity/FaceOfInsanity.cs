using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.FaceOfInsanity
{
	[AutoloadBossHead]
    public class FaceOfInsanity : ModNPC
    {
		int AiTimer = 0;
		int BloodTimer = 0;
		int BloodRainTimer = 0;
		int DashTimer = 0;
		bool Phase2 = false;
		
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 11000;
            npc.damage = 40;
            npc.defense = 17;
            npc.knockBackResist = 0f;
            npc.width = 128;
            npc.height = 154;
            npc.value = Item.buyPrice(0, 8, 0, 0);
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit8;
			npc.DeathSound = SoundID.NPCDeath13;
            music = MusicID.Boss4;
			npc.npcSlots = 5;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arterius");
			Main.npcFrameCount[npc.type] = 5;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 15000 + ((numPlayers) * 1000);
			npc.damage = 50;
			npc.defense = 22;
		}
		

        public override void AI()
        {
			npc.TargetClosest(true);
            Player player = Main.player[npc.target];
			AiTimer++;
			
			if (npc.life < (int)(npc.lifeMax / 2))
			{
				Phase2 = true;
			}
			
			if (AiTimer <= 240) //Flying
			{
				npc.dontTakeDamage = false;
				if (npc.alpha > 0)
				{
					npc.alpha -= 5;
				}
				
				BloodTimer += 1;
				
				if (Phase2)
				{
					if (Main.expertMode)
						BloodTimer += 1;
					DashTimer++;
				}
				
				float SpeedBoost = 0.4f;
				int maxSpeed = 6;
				if (Main.expertMode && Phase2)
				{
					SpeedBoost = 0.8f;
					maxSpeed = 8;
				}
				if (npc.direction == -1 && (double) npc.velocity.X > -maxSpeed)
				{
					npc.velocity.X -= SpeedBoost;
					if ((double) npc.velocity.X > 6.0)
					  npc.velocity.X -= SpeedBoost;
					else if ((double) npc.velocity.X > 0.0)
					  npc.velocity.X += 0.05f;
					if ((double) npc.velocity.X < -6.0)
					  npc.velocity.X = -4f;
				}
				else if (npc.direction == 1 && (double) npc.velocity.X < maxSpeed)
				{
					npc.velocity.X += SpeedBoost;
					if ((double) npc.velocity.X < -6.0)
						npc.velocity.X += SpeedBoost;
					else if ((double) npc.velocity.X < 0.0)
						npc.velocity.X -= 0.05f;
					if ((double) npc.velocity.X > 6.0)
						npc.velocity.X = 4f;
				}
				if (npc.directionY == -1 && (double) npc.velocity.Y > -maxSpeed/4)
				{
					npc.velocity.Y -= 0.04f;
					if ((double) npc.velocity.Y > 3)
					  npc.velocity.Y -= 0.05f;
					else if ((double) npc.velocity.Y > 0.0)
					  npc.velocity.Y += 0.03f;
					if ((double) npc.velocity.Y < -3)
					  npc.velocity.Y = -1.5f;
				}
				else if (npc.directionY == 1 && (double) npc.velocity.Y < maxSpeed/4)
				{
					npc.velocity.Y += 0.04f;
					if ((double) npc.velocity.Y < -3)
					  npc.velocity.Y += 0.05f;
					else if ((double) npc.velocity.Y < 0.0)
					  npc.velocity.Y -= 0.03f;
					if ((double) npc.velocity.Y > 3)
					  npc.velocity.Y = 1.5f;
				}
			}
			
			if (AiTimer > 240) // become invisible
			{
				DashTimer = 0;
				BloodTimer = 0;
				npc.dontTakeDamage = true;
				npc.velocity.X = 0;
				npc.velocity.Y = 0;
				if (npc.alpha < 255)
				{
					npc.alpha += 5;
				}
				if (npc.alpha == 255)
				{
					npc.position.Y = player.position.Y - 300 - (npc.height/2);
					npc.position.X = player.Center.X - (npc.width / 2);
				}
				BloodRainTimer++;
			}
			
			if (npc.alpha == 255 && BloodRainTimer >= 20) //rain down blood while invisible
			{
				this.BloodRain();
				BloodRainTimer = 0;
			}
		
			if (BloodTimer >= 40) //shooting a spread of blood projectiles
			{
				this.ShootBlood();
				BloodTimer = 0;
			}
			
			if (DashTimer >= 160)
			{
				this.Dash();
				DashTimer = 0;
			}
			
			if (AiTimer > 420)
			{
				AiTimer = 0;
			}
			
			if (!player.active || player.dead || Main.dayTime) //despawn
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				AiTimer = 0;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
            }
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.3f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public void ShootBlood()
		{
			int Type = mod.ProjectileType("BouncyBlood");
			
			if (Phase2)
			{
				switch (Main.rand.Next(3))
				{
					case 0: 
						Type = mod.ProjectileType("BouncyBlood");
						break;
					case 1: 
						Type = mod.ProjectileType("ExplosiveBlood");
						break;
					case 2: 
						Type = mod.ProjectileType("BloodBoltA");
						break;
					default:
						break;
				}
			}
			
			else
			{
				switch (Main.rand.Next(2))
				{
					case 0: 
						Type = mod.ProjectileType("BouncyBlood");
						break;
					case 1: 
						Type = mod.ProjectileType("BloodBoltA");
						break;
					default:
						break;
				}
			}
			
			int k = Main.rand.Next(3, 4);
			if (Type == mod.ProjectileType("BouncyBlood"))
			{
				for (int i = 0; i < k; ++i)
				{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					float sX = direction.X * 8f;
					float sY = direction.Y * 8f;
					sX += (float)Main.rand.Next(-60, 60) * 0.05f;
					sY += (float)Main.rand.Next(-60, 60) * 0.05f;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX + npc.velocity.X, sY + npc.velocity.Y , Type, (int)(npc.damage / 3), 1, Main.myPlayer, 0, 0);
				}
			}
			
			else
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X*5 + npc.velocity.X, direction.Y*5 + npc.velocity.Y , Type, (int)(npc.damage / 2), 1, Main.myPlayer, 0, 0);
			}
			Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 9);
			npc.netUpdate = true;
		}
		
		public void BloodRain()
		{
			int k = Main.rand.Next(1, 3);
			if (Phase2 && Main.expertMode)
			{
				k += Main.rand.Next (1, 2);
			}
			for (int i = 0; i < k; ++i)
			{
				Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-(Main.screenWidth/2), (Main.screenWidth/2)), npc.Center.Y - 600, 0, 11, mod.ProjectileType("zBloodStream"), (int)(npc.damage / 3), 1, Main.myPlayer, 0, 0);
			}
			npc.netUpdate = true;
		}
		
		public void Dash()
		{
			Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 2);
			float num4 = 10f;
			Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
            float num5 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
            float num6 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
            float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
            float num8 = num4 / num7;
            npc.velocity.X = num5 * num8;
            npc.velocity.Y = num6 * num8;
		}
		
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			if (npc.alpha == 255)
			{
				return false;
			}
			return true;
		}		
		
		public override void NPCLoot()
		{
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ArteriusBag")));
			}
			
			else
			{
				switch (Main.rand.Next(4))
				{
					case 0: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("HemorrhageStaff")));
						break;
					case 1: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("SeveredTongue")));
						break;
					case 2:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("BloodLeech")), Main.rand.Next(250, 270));
						break;
					case 3:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("GoredLung")));
						break;
					default:
						break;
				}
			}
			TGEMWorld.downedArterius = true;
		}
	}
}
