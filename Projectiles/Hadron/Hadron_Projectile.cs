using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;

namespace ForgottenMemories.Projectiles.Hadron
{
    public class Hadron_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hadron Bullet");
        } 
        public override void SetDefaults()
        {
            projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.timeLeft = 100;
			projectile.penetrate = -1;
			aiType = 14;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.hide = true;
			projectile.ignoreWater = true;
        }
        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if ((double) Vector2.Distance(player.Center, projectile.Center) >= (double) 10f)
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
					int num42 = Dust.NewDust(projectile.Center, 0, 0, 156, 0f, 0f, 160, default(Color), 1f);
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
						int num44 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1f);
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
						int num46 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 155, default(Color), 0.8f);
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
						int num48 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 0, default(Color), 1.2f);
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
					int num49 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0f, 0f, 100, default(Color), 1f);
					Dust dust3 = Main.dust[num49];
					dust3.velocity *= 0.3f;
					Main.dust[num49].position = projectile.Center + value12 * (float)projectile.width / 2f;
					Main.dust[num49].fadeIn = 0.9f;
					Main.dust[num49].noGravity = true;
				}
			}
			if (projectile.timeLeft == 96)
			{    	
				projectile.Kill();
				float porn = 16f;
				for (int index1 = 0; (double) index1 < (double) porn; ++index1)
				{
					Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) porn), new Vector2()) * new Vector2(1f, 4f)).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2());
					int index2 = Dust.NewDust(projectile.Center, 0, 0, 156, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].scale = 1f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position = projectile.Center + v;
					Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitY) * 1f;
					Main.dust[index2].noLight = true;
				}
			}
		}
    }
}