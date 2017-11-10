using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class IceMagic : ModProjectile
    {
		bool hasAimed = false;
		//float num415 = 0;
		//float num416 = 0;	
		//bool flag12 = false;
		//bool flag13 = false;
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.magic = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
			projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.alpha = 255;
            projectile.timeLeft = 300;

        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 180, false);
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Shard");
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
        }

        public override void AI()
        {
			for (int index1 = 0; index1 < 5; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 135, 0.0f, 0.0f, 200, default(Color), 1.3f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			
			int num1022 = 617;
			float num1023 = 500f;
			float x4 = 0.15f;
			float y3 = 0.15f;
			bool flag59 = false;
			bool flag60 = false;
			int num1024 = projectile.type;
			Player player = Main.player[projectile.owner];
			
			if (player.channel == true && hasAimed == false)
			{
				if (flag60)
				{
					int num1025 = (int)projectile.ai[1];
					if (!player.active)
					{
						projectile.Kill();
						return;
					}
					projectile.timeLeft = 2;
				}
				projectile.ai[0] += 1f;
				if (projectile.ai[0] < num1023)
				{
					bool flag61 = true;
					int num1026 = (int)projectile.ai[1];
					if (player.active)
					{
						if (!flag59 && player.oldPosition != Vector2.Zero)
						{
							projectile.position += player.position - player.oldPosition;
						}
						if (projectile.Center.HasNaNs())
						{
							projectile.Kill();
							return;
						}
					}
					else
					{
						projectile.ai[0] = num1023;
						flag61 = false;
						projectile.Kill();
					}
					if (flag61 && !flag59)
					{
						projectile.velocity += new Vector2((float)Math.Sign(player.Center.X - projectile.Center.X), (float)Math.Sign(player.Center.Y - projectile.Center.Y)) * new Vector2(x4, y3);
						if (projectile.velocity.Length() > 9f)
						{
							projectile.velocity *= 9f / projectile.velocity.Length();
						}
					}
					
					{
						projectile.alpha = 255;
						return;
					}
					
					projectile.Kill();
					return;
				}
			}
			
			else
			{
				if (hasAimed == false)
				{
				//	num415 = Main.MouseWorld.X;
					//num416 = Main.MouseWorld.Y;
					projectile.netUpdate = true;
					Vector2 vel = Main.MouseWorld - projectile.Center;
					vel.Normalize();
					projectile.velocity = vel * 11;
					projectile.timeLeft = 300;
					hasAimed = true;
				}
				
				if (hasAimed == true && projectile.timeLeft < 280)
				{
					projectile.tileCollide = true;
				}
			}
        }
    }       
}
