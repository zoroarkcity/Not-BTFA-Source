using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Mounts.MagMount
{
	public class MountAcorn : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn");
        }
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.damage = 30;
			projectile.height = 8;
			projectile.aiStyle = 1;
			aiType = ProjectileID.WoodenArrowHostile;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.timeLeft = 1000;
			projectile.extraUpdates = 2;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.usesLocalNPCImmunity = false;
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
		  for (int index = 0; index < 4; ++index)
            {
                float SpeedX = (float) (-(double) projectile.velocity.X * (double) Main.rand.Next(30, 100) * 0.00999999977648258 + (double) Main.rand.Next(-40, 41) * 0.400000005960464);
                float SpeedY = (float) (-(double) projectile.velocity.Y * (double) Main.rand.Next(30, 100) * 0.00999999977648258 + (double) Main.rand.Next(-40, 41) * 0.400000005960464);
				float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
				float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
				int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("MiniAcornSeed"), projectile.damage / 2, 5f, projectile.owner);
			    int r = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("MiniAcornSeed"), projectile.damage / 2, 5f, projectile.owner);
            }
    }
    }
}
