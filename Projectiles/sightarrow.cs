using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class sightarrow : ModProjectile
    {
		int counter = 0;
        public override void SetDefaults()
        {
            projectile.width = 10;
			projectile.height = 10;
           // projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
			//projectile.scale = 1.3f;
			projectile.timeLeft = 1000;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Bolt");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			for (int i = 0; i < 7; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, projectile.velocity.X, projectile.velocity.Y, 0, new Color(), 1f);
				Main.dust[dust].scale = 1.95f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void AI()
		{
			float num29 = 5f;
			float num30 = 250f;
			float scaleFactor = 6f;
			Vector2 value7 = new Vector2(8f, 10f);
			float num31 = 1.2f;
			Vector3 rgb = new Vector3(0.7f, 0.1f, 0.5f);
			int num32 = 4 * projectile.MaxUpdates;
			int num33 = Utils.SelectRandom<int>(Main.rand, new int[]
			{
				242,
				73,
				72,
				71,
				255
			});
			int num34 = 74;
			int num;
			if (projectile.ai[1] >= 1f && projectile.ai[1] < num29)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] == num29)
				{
					projectile.ai[1] = 1f;
				}
			}
			projectile.spriteDirection = projectile.direction;
			num = projectile.frameCounter;
			projectile.frameCounter = num + 1;
			Lighting.AddLight(projectile.Center, rgb);
			projectile.rotation = projectile.velocity.ToRotation();
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] == 48f)
			{
				projectile.localAI[0] = 0f;
			}
			
			for (int num41 = 0; num41 < 2; num41 = num + 1)
			{
				Vector2 value8 = Vector2.UnitX * -30f;
				value8 = -Vector2.UnitY.RotatedBy((double)(projectile.localAI[0] * 0.1308997f + (float)num41 * 3.14159274f), default(Vector2)) * value7 - projectile.rotation.ToRotationVector2() * 10f;
				int num42 = Dust.NewDust(projectile.Center, 0, 0, num34, 0f, 0f, 160, default(Color), 1f);
				Main.dust[num42].scale = num31;
				Main.dust[num42].noGravity = true;
				Main.dust[num42].position = projectile.Center + value8 + projectile.velocity * 2f;
				Main.dust[num42].velocity = Vector2.Normalize(projectile.Center + projectile.velocity * 2f * 8f - Main.dust[num42].position) * 2f + projectile.velocity * 2f;
				num = num41;
			}
			
			if (Main.rand.Next(12) == 0)
			{
				for (int num43 = 0; num43 < 1; num43 = num + 1)
				{
					Vector2 value9 = -Vector2.UnitX.RotatedByRandom(0.19634954631328583).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num44 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0f, 0f, 100, default(Color), 1f);
					Dust dust3 = Main.dust[num44];
					
					Main.dust[num44].noGravity = true;
					dust3.velocity *= 0.1f;
					Main.dust[num44].position = projectile.Center + value9 * (float)projectile.width / 2f + projectile.velocity * 2f;
					Main.dust[num44].fadeIn = 0.9f;
					num = num43;
				}
			}
			if (Main.rand.Next(64) == 0)
			{
				for (int num45 = 0; num45 < 1; num45 = num + 1)
				{
					Vector2 value10 = -Vector2.UnitX.RotatedByRandom(0.39269909262657166).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num46 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0f, 0f, 155, default(Color), 0.8f);
					Dust dust3 = Main.dust[num46];
					dust3.velocity *= 0.3f;
					
					Main.dust[num46].noGravity = true;
					Main.dust[num46].position = projectile.Center + value10 * (float)projectile.width / 2f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num46].fadeIn = 1.4f;
					}
					num = num45;
				}
			}
			if (Main.rand.Next(4) == 0)
			{
				for (int num47 = 0; num47 < 2; num47 = num + 1)
				{
					Vector2 value11 = -Vector2.UnitX.RotatedByRandom(0.78539818525314331).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num48 = Dust.NewDust(projectile.position, projectile.width, projectile.height, num34, 0f, 0f, 0, default(Color), 1.2f);
					Dust dust3 = Main.dust[num48];
					dust3.velocity *= 0.3f;
					Main.dust[num48].noGravity = true;
					Main.dust[num48].position = projectile.Center + value11 * (float)projectile.width / 2f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num48].fadeIn = 1.4f;
					}
					num = num47;
				}
			}
			if (Main.rand.Next(12) == 0)
			{
				Vector2 value12 = -Vector2.UnitX.RotatedByRandom(0.19634954631328583).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
				int num49 = Dust.NewDust(projectile.position, projectile.width, projectile.height, num34, 0f, 0f, 100, default(Color), 1f);
				Dust dust3 = Main.dust[num49];
				dust3.velocity *= 0.3f;
				Main.dust[num49].position = projectile.Center + value12 * (float)projectile.width / 2f;
				Main.dust[num49].fadeIn = 0.9f;
				Main.dust[num49].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 7; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, projectile.velocity.X * 3, projectile.velocity.Y * 3, 0, new Color(), 1f);
				Main.dust[dust].scale = 1.95f;
				Main.dust[dust].noGravity = true;
			}
        }
    }
}