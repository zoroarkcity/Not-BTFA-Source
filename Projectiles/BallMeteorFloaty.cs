using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BallMeteorFloaty : ModProjectile
	{
        public bool becomeRealBall = false;
        
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ball Meteor");
		}

		public override void SetDefaults()
		{
            projectile.width = 36;
            projectile.height = 34;
            projectile.aiStyle = -1;
            //projectile.melee = true; //literally why
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.light = 0.5f;
            projectile.extraUpdates = 3;
		}

        public void BaseAI() //ai stolen from original ball meteor
        {
            projectile.rotation += projectile.velocity.X / 2f;
			if (Main.rand.Next(2) == 0)
            {
				Vector2 vector2 = projectile.Center + Vector2.Normalize(projectile.velocity) * 10f;
				Dust dust1 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, 0.0f, 0.0f, 0, new Color(), 1f)];
				dust1.position = vector2;
				dust1.velocity = projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 4f;
				dust1.position += projectile.velocity.RotatedBy(1.57079637050629, new Vector2());
				dust1.fadeIn = 0.5f;
				dust1.noGravity = true;
				Dust dust2 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, 0.0f, 0.0f, 0, new Color(), 1f)];
				dust2.position = vector2;
				dust2.velocity = projectile.velocity.RotatedBy(-1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 4f;
				dust2.position += projectile.velocity.RotatedBy(-1.57079637050629, new Vector2());
				dust2.fadeIn = 0.5f;
				dust2.noGravity = true;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 60, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].velocity *= 0.5f;
				Main.dust[index2].scale *= 1.3f;
				Main.dust[index2].fadeIn = 1f;
				Main.dust[index2].noGravity = true;
				//if (projectile.position.Y > (double)projectile.ai[1]) projectile.tileCollide = true;
			}
        }

        public override void AI()
        {
            BaseAI();

            //when spawned, decelerate to a near stop
            if (projectile.velocity.Length() > 0.05f)
            {
                projectile.velocity *= 0.982f;
            }
            else
            {
                becomeRealBall = true;
                projectile.Kill();
            }
        }

        public override void Kill(int timeLeft)
		{
            Main.PlaySound(SoundID.Item89, projectile.position);
            
            //when comes to a stop, "this" rock shoots at nearest player
            if (becomeRealBall)
            {
                int target = Player.FindClosest(projectile.Center, 0, 0);

				Vector2 targetLocation = Main.player[target].Center;
				if (Main.rand.Next(2) == 0) //may or may not lead the player
					targetLocation += Main.player[target].velocity * 17f;

                Vector2 direction = Vector2.Subtract(targetLocation, projectile.Center);
                direction.Normalize();
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, direction.X * 5.5f, direction.Y * 5.5f, mod.ProjectileType("BallMeteor"), projectile.damage, 1, Main.myPlayer);

                return;
            }
            
            projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (128.0 * (double) projectile.scale);
			projectile.height = (int) (128.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 60, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 32; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 60, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 60, 0.0f, 0.0f, 100, new Color(), 1.5f);
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
		}
	}
}
