using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	public class MiniTitan : ModNPC
	{
		int timer = 0;
		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 64;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 1500;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.scale = 1.3f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Pebble");
		}

		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 2000;
			npc.damage = 40;
		}
		
		public override bool PreNPCLoot()
		{
			for (int i = 0; i < 30; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
				Main.dust[dust].scale = 1.5f;
			}
			
			return false;
		}
		
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			timer++;
			npc.velocity.Y = 0;
			if (timer >= 80)
			{
				int A = Main.rand.Next(-250, 250) * 2;
				int B = Main.rand.Next(-100, 100) - 300;
				npc.position.X = player.Center.X + A;
				npc.position.Y = player.Center.Y + B;
				for (int m = 0; m <= 10; m++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					}
				for (int i = 0; i < 2; ++i)
					{
						Vector2 direction = Main.player[npc.target].Center - npc.Center;
						direction.Normalize();
						float sX = direction.X * 4f;
						float sY = direction.Y * 4f;
						sX += (float)Main.rand.Next(-60, 61) * 0.02f;
						sY += (float)Main.rand.Next(-60, 61) * 0.02f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball2"), 25, 1, Main.myPlayer, 0, 0);
					}
				timer = 0;
			}
			if (npc.position.X > player.position.X)
			{
				npc.spriteDirection = -1;
			}
			if (npc.position.X < player.position.X)
			{
				npc.spriteDirection = 1;
			}
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = -20;
				timer = 0;
			}
		}
		
	}
}
