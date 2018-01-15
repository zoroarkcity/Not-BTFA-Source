using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEnt
{
    public class Fireball_of_the_Hallow_Ent : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball of the Hallow Ent");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16; 
            projectile.aiStyle = 1;
            projectile.friendly = true; 
            projectile.hostile = false;
            projectile.tileCollide = true; 
            projectile.thrown = true;   
            projectile.timeLeft = 1000; 
			projectile.extraUpdates = 0;
			projectile.scale = 1f;
			Main.projFrames[projectile.type] = 4;
            aiType = ProjectileID.Bullet;		
        }
		public override void AI()
        {
			projectile.frameCounter++;
			
			if (projectile.frameCounter > 6)
			{
			   projectile.frame++;
               projectile.frameCounter = 1;
			}
            if (projectile.frame > 3)
            {
               projectile.frame = 0;
            }
			
			++projectile.ai[1];
            if (projectile.ai[1] > Main.rand.Next(25, 35))
            {
				projectile.ai[1] = 0f;
				Projectile.NewProjectile(projectile.Center, Vector2.Zero, 480, (int) (projectile.damage * 0.75), projectile.knockBack * 0.5f, projectile.owner, 0.0f, 0.0f);
            }
			
			Vector2 vector2 = projectile.Center + Vector2.Normalize(projectile.velocity) * 10f;
			Dust dust1 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0.0f, 0.0f, 0, new Color(), 1f)];
			dust1.position = vector2;
			dust1.velocity = projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 4f;
			dust1.position += projectile.velocity.RotatedBy(1.57079637050629, new Vector2());
			dust1.fadeIn = 0.5f;
			dust1.scale = 1.5f;
			dust1.noGravity = true;
			Dust dust2 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0.0f, 0.0f, 0, new Color(), 1f)];
			dust2.position = vector2;
			dust2.velocity = projectile.velocity.RotatedBy(-1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 4f;
			dust2.position += projectile.velocity.RotatedBy(-1.57079637050629, new Vector2());
			dust2.fadeIn = 0.5f;
			dust2.scale = 1.5f;
			dust2.noGravity = true;
			if (Main.rand.Next(9) == 0)
			{
				int index = Dust.NewDust(projectile.Center, 8, 8, 75, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].position = projectile.Center;
				Main.dust[index].velocity *= 0.2f;
				Main.dust[index].noGravity = true;
				Main.dust[index].scale = 1f;
			}
			if (Main.rand.Next(9) == 0)
			{
				int index = Dust.NewDust(projectile.Center, 8, 8, 75, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].position = projectile.Center;
				Main.dust[index].velocity *= 0.2f;
				Main.dust[index].noGravity = true;
				Main.dust[index].scale = 1.5f;
			}
			if (Main.rand.Next(9) == 0)
			{
				int index = Dust.NewDust(projectile.Center, 8, 8, 75, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].position = projectile.Center;
				Main.dust[index].velocity *= 0.2f;
				Main.dust[index].noGravity = true;
				Main.dust[index].scale = 2f;
			}
	    }	
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(1, 3), false);
			int num2 = Main.rand.Next(20, 40);
            for (int index1 = 0; index1 < num2; ++index1)
            {
                int index2 = Dust.NewDust(projectile.Center, 0, 0, 75, 0.0f, 0.0f, 100, new Color(), 0.8f);
                Main.dust[index2].velocity *= 1.2f;
                --Main.dust[index2].velocity.Y;
                Main.dust[index2].velocity += projectile.velocity;
                Main.dust[index2].noGravity = true;
            }
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item122, projectile.position);
			for (int index = 0; index < 20; ++index)
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 75, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 10; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 75, 0.0f, 0.0f, 100, new Color(), 2.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 3f;
				int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 75, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index3].velocity *= 2f;
			}
			if (projectile.owner == Main.myPlayer)
			{
				projectile.penetrate = -1;
				projectile.position.X += (float) (projectile.width / 2);
				projectile.position.Y += (float) (projectile.height / 2);
				projectile.width = 86;
				projectile.height = 86;
				projectile.position.X -= (float) (projectile.width / 2);
				projectile.position.Y -= (float) (projectile.height / 2);
				projectile.Damage();
			}
		}
    }
}