using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class VoidBolt : ModProjectile
    {
		int dustcounter = 0;
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
			projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.alpha = 255;
            projectile.timeLeft = 300;
			projectile.magic = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Energy");
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("Void"), projectile.damage, projectile.knockBack, projectile.owner, projectile.Center.X, projectile.Center.Y);
        }

        public override void AI()
        {
			
			for (int index1 = 0; index1 < 5; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 240, 0.0f, 0.0f, 200, default(Color), 1.2f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			
			if (Main.rand.Next(2) == 0)
			{
				float num1 = projectile.velocity.X / 3f * (float) 1;
				float num2 = projectile.velocity.Y / 3f * (float) 1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 229, 0.0f, 0.0f, 200, default(Color), 1.2f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
        }
    }       
}
