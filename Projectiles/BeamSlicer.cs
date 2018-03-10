using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class BeamSlicer : ModProjectile
	{
		int CounterA = 0;
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.thrown = true;
			projectile.friendly = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beam Slicer");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BeamSlicer"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
			{
			  if ((double) projectile.velocity.X != (double) velocity1.X)
				projectile.velocity.X = -velocity1.X;
			  if ((double) projectile.velocity.Y != (double) velocity1.Y)
				projectile.velocity.Y = -velocity1.Y;
			}
			return false;	
		}
		
		public override void AI()
		{
			projectile.rotation += 0.2f;
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0,  60, 0f, 0f);
			}
			
			projectile.velocity *= 0.96f;
			CounterA++;
			if (CounterA >= 40)
			{
				int[] numArray = new int[10];
				int maxValue = 0;
				int num1 = 700;
				int num2 = 20;
				for (int index = 0; index < 200; ++index)
				{
					if (Main.npc[index].CanBeChasedBy((object) this, false))
					{
						float num3 = (projectile.Center - Main.npc[index].Center).Length();
						if ((double) num3 > (double) num2 && (double) num3 < (double) num1 && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[index].Center, 1, 1))
						{
							numArray[maxValue] = index;
							++maxValue;
							if (maxValue >= 9)
								break;
						}
					}
				}
				if (maxValue > 0)
				{
					int index = Main.rand.Next(maxValue);
					Vector2 vector2 = Main.npc[numArray[index]].Center - projectile.Center;
					float num3 = projectile.velocity.Length();
					vector2.Normalize();
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X * 5f, vector2.Y * 5f, mod.ProjectileType("laserbeam"), projectile.damage, 5f, projectile.owner);
					projectile.netUpdate = true;
				}
				CounterA = 0;
			}
		}
	}
}	