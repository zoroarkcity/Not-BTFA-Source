using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class UndeadGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 3;
            //projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
            projectile.alpha = 0;
			projectile.scale = 1f;
			projectile.tileCollide = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Grenade");
		}
		
		
		public override void AI()
		{
			projectile.rotation += 0.5f;
			Dust dust1 = Main.dust[Dust.NewDust(projectile.Center, 0, 0, mod.DustType("UndeadDust"), 0.0f, 0.0f, 0, new Color(), 1.2f)];
			dust1.noGravity = true;
			projectile.velocity.Y += 0.1f;
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			projectile.penetrate -= 1;
			projectile.damage += (int)(projectile.damage / 4);
			Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("BloodBoom2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			if (projectile.penetrate == 0)
			{
				projectile.Kill();
				Main.PlaySound(SoundID.Item89, projectile.position);
			}
			
			else
			{
				Main.PlaySound(SoundID.Item89, projectile.position);
			}
			
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y;
                }
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 151);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.velocity = -projectile.oldVelocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-15, 16)));;
			Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("BloodBoom2"), damage, knockback, projectile.owner, 0f, 0f);
			
			target.immune[projectile.owner] = 13;
			projectile.damage += (int)(projectile.damage / 4);
			Main.PlaySound(SoundID.Item89, projectile.position);
		}
    }
}