using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class ShadowDartProj : ModProjectile
	{
		int timer = 0;
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Dart");
		}
		
		
		public override void Kill(int timeLeft)
		{
			if(projectile.alpha != 200)
			{
				for (int i = 0; i < 5; i++)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 14);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
				}
				Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			}
		}


		
		public override void AI()
		{
			timer++;
			if(timer == 15 && projectile.alpha != 200)
			{
				int z = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, projectile.type, projectile.damage, 0f, projectile.owner, 0f, 0f);
				Main.projectile[z].alpha = 200;
				Main.projectile[z].aiStyle = -1;
				Main.projectile[z].tileCollide = false;
				Main.projectile[z].penetrate = -1;
				Main.projectile[z].timeLeft = 50;
				Main.projectile[z].rotation = projectile.rotation;
				
				timer = 0;
			}
		}
	}
}