using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Magnoliac.Projectiles
{
	public class Acorn : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn");
        }
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.damage = 40;
			projectile.height = 30;
			projectile.aiStyle = 1;
			aiType = ProjectileID.WoodenArrowHostile;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.timeLeft = 1000;
			projectile.extraUpdates = 2;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.usesLocalNPCImmunity = false;
			Main.projFrames[projectile.type] = 5;
		}
        public override void AI()
        {         	
			projectile.frameCounter++;
			
			if (projectile.frameCounter > 3)
			{
			   projectile.frame++;
               projectile.frameCounter = 1;
			}
            if (projectile.frame > 4)
            {
               projectile.frame = 0;
            }
        }
		public override void Kill(int timeLeft)
	{
          Main.PlaySound(SoundID.Item14, projectile.position);
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
          for (int index1 = 0; index1 < 5; ++index1)
          {
            int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
            Main.dust[index2].noGravity = true;
            Main.dust[index2].velocity *= 3f;
            int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
            Main.dust[index3].velocity *= 2f;
          }
          int index4 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
          Main.gore[index4].velocity *= 0.4f;
          Main.gore[index4].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
          Main.gore[index4].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
          int index5 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
          Main.gore[index5].velocity *= 0.4f;
          Main.gore[index5].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
          Main.gore[index5].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
          if (projectile.owner == Main.myPlayer)
          {
            projectile.penetrate = -1;
            projectile.position.X += (float) (projectile.width / 2);
            projectile.position.Y += (float) (projectile.height / 2);
            projectile.width = 64;
            projectile.height = 64;
            projectile.position.X -= (float) (projectile.width / 2);
            projectile.position.Y -= (float) (projectile.height / 2);
            projectile.Damage();
          }
    }
    }
}
