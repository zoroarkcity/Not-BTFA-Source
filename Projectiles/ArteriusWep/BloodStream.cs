using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class BloodStream : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 70;
			projectile.extraUpdates = 2;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Stream");
		}
		
		public override void AI()
		{
			if (projectile.timeLeft > 60)
			{
				projectile.timeLeft = 60;
			}
			if (projectile.ai[0] > 7f)
			{
				
				if (Main.rand.Next(10) == 0)
				{
					Vector2 velVect = new Vector2(projectile.velocity.X / 2, projectile.velocity.Y / 2);
					Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-25, 25)));
					
					int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velVect2.X, velVect2.Y, mod.ProjectileType("BloodTrail"), projectile.damage, projectile.knockBack, projectile.owner);
					Main.projectile[p].ranged = true;
					Main.projectile[p].timeLeft = 45;
				}
				
				float num297 = 1f;
				if (projectile.ai[0] == 8f)
				{
					num297 = 0.25f;
				}
				else if (projectile.ai[0] == 9f)
				{
					num297 = 0.5f;
				}
				else if (projectile.ai[0] == 10f)
				{
					num297 = 0.75f;
				}
				projectile.ai[0] += 1f;
				int num298 = mod.DustType("BloodDust");
				if (num298 == 6 || Main.rand.Next(2) == 0)
				{
					int num3;
					for (int num299 = 0; num299 < 1; num299 = num3 + 1)
					{
						int num300 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num298, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
						Dust dust3;
						if (Main.rand.Next(3) != 0 || (num298 == 75 && Main.rand.Next(3) == 0))
						{
							Main.dust[num300].noGravity = true;
							dust3 = Main.dust[num300];
							dust3.scale *= 3f;
							Dust dust52 = Main.dust[num300];
							dust52.velocity.X = dust52.velocity.X * 2f;
							Dust dust53 = Main.dust[num300];
							dust53.velocity.Y = dust53.velocity.Y * 2f;
						}
						else
						{
							dust3 = Main.dust[num300];
							dust3.scale *= 1.5f;
						}
						Dust dust54 = Main.dust[num300];
						dust54.velocity.X = dust54.velocity.X * 1.2f;
						Dust dust55 = Main.dust[num300];
						dust55.velocity.Y = dust55.velocity.Y * 1.2f;
						dust3 = Main.dust[num300];
						dust3.scale *= num297;
						if (num298 == 75)
						{
							dust3 = Main.dust[num300];
							dust3.velocity += projectile.velocity;
							if (!Main.dust[num300].noGravity)
							{
								dust3 = Main.dust[num300];
								dust3.velocity *= 0.5f;
							}
						}
						num3 = num299;
					}
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * (float)projectile.direction;
			return;
		}
	}
}