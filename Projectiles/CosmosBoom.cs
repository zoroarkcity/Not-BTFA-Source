using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles 
{
	public class CosmosBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 52;
			projectile.height = 52;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.timeLeft = 10;
			Main.projFrames[projectile.type] = 5;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comet Explosion");
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 2)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1);
			} 
			
			if (projectile.ai[0] > 0)
				return;
	        Main.PlaySound(89, (int)projectile.position.X, (int)projectile.position.Y, 21);;
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (16.0 * (double) projectile.scale);
			projectile.height = (int) (16.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 32; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0.0f, 0.0f, 100, new Color(), 1.5f);
			  Main.dust[index3].velocity *= 2f;
			  Main.dust[index3].noGravity = true;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
			  int index2 = Gore.NewGore(projectile.position + new Vector2((float) (projectile.width * Main.rand.Next(100)) / 100f, (float) (projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
			  Main.gore[index2].velocity *= 0.3f;
			  Main.gore[index2].velocity.X += (float) Main.rand.Next(-10, 11) * 0.05f;
			  Main.gore[index2].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.05f;
			}
			if (projectile.owner == Main.myPlayer)
			{
			  projectile.localAI[1] = -1f;
			  projectile.maxPenetrate = 0;
			  projectile.Damage();
			}
			for (int index1 = 0; index1 < 5; ++index1)
			{
			  int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, Utils.SelectRandom<int>(Main.rand, new int[3]
			  {
				15,
				176,
				59
			  }), 2.5f * (float) projectile.direction, -2.5f, 0, new Color(), 1f);
			  Main.dust[index2].alpha = 200;
			  Main.dust[index2].velocity *= 2.4f;
			  Main.dust[index2].scale += Main.rand.NextFloat();
			}
		projectile.ai[0]++;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("CosmicCurse"), 180, false);
		}
	}
}	