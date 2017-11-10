using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class Magnoliac : ModNPC
	{
		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 5000;
			npc.damage = 40;
			npc.defense = 10;
			npc.knockBackResist = 0f;
			npc.width = 88;
			npc.height = 160;
			npc.scale = 1.2f;
			npc.value = 15000;
			npc.buffImmune[31] = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[186] = true;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
			music = 12;
			npc.npcSlots = 5;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 1;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 9000 + ((numPlayers) * 1000);
			npc.damage = 55;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magnoliac");
			Main.npcFrameCount[npc.type] = 6;
		}


		public override void AI()
		{
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			npc.ai[0]++;
			
			Phase1(player);
			
		}
		
		public void Phase1(Player player)
		{
			float num586 = 0.03f;
			float num587 = 4f;
			float num588 = 0.07f;
			float num589 = 9.5f;
			if (Main.expertMode)
			{
				num586 = 0.04f;
				num587 = 15f;
				num588 = 0.09f;
				num589 = 15f;
			}
			if (npc.position.Y > Main.player[npc.target].position.Y - 250f)
			{
				if (npc.velocity.Y > 0f)
				{
					npc.velocity.Y = npc.velocity.Y * 0.96f;
				}
				npc.velocity.Y = npc.velocity.Y - num586;
				if (npc.velocity.Y > num587)
				{
					npc.velocity.Y = num587;
				}
			}
			else if (npc.position.Y < Main.player[npc.target].position.Y - 250f)
			{
				if (npc.velocity.Y < 0f)
				{
					npc.velocity.Y = npc.velocity.Y * 0.96f;
				}
				npc.velocity.Y = npc.velocity.Y + num586;
				if (npc.velocity.Y < -num587)
				{
					npc.velocity.Y = -num587;
				}
			}
			if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
			{
				if (npc.velocity.X > 0f)
				{
					npc.velocity.X = npc.velocity.X * 0.96f;
				}
				npc.velocity.X = npc.velocity.X - num588;
				if (npc.velocity.X > num589)
				{
					npc.velocity.X = num589;
				}
			}
			if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
			{
				if (npc.velocity.X < 0f)
				{
					npc.velocity.X = npc.velocity.X * 0.96f;
				}
				npc.velocity.X = npc.velocity.X + num588;
				if (npc.velocity.X < -num589)
				{
					npc.velocity.X = -num589;
				}
			}
			
			if ((npc.ai[0] % 50) == 0 && npc.ai[0] < 750)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				float sX = direction.X * 7f;
				float sY = direction.Y * 7f;
				int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("AirslashWhite"), 25, 1, Main.myPlayer, 0, 0);
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
				Main.projectile[p].netUpdate = true;
			}
			
			if (npc.ai[0] == 750)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 5f;
				direction.Y *= 5f;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("AirslashGreen"), 25, 1, Main.myPlayer, 0, 0);
				direction = direction.RotatedBy(MathHelper.ToRadians(30));
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("AirslashGreen"), 25, 1, Main.myPlayer, 0, 0);
				direction = direction.RotatedBy(MathHelper.ToRadians(30));
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("AirslashGreen"), 25, 1, Main.myPlayer, 0, 0);
				direction = direction.RotatedBy(MathHelper.ToRadians(-90));
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("AirslashGreen"), 25, 1, Main.myPlayer, 0, 0);
				direction = direction.RotatedBy(MathHelper.ToRadians(-30));
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("AirslashGreen"), 25, 1, Main.myPlayer, 0, 0);
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
				npc.ai[0] = 0;
			}
		}
		
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.2f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		public override void NPCLoot()
		{
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("MegaTreeBag")));
			}
			else
			{
				int amountToDrop = Main.rand.Next(10,30);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ForestEnergy"), amountToDrop);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, (amountToDrop * 3));
			}
		}
	}
}
