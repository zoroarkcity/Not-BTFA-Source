using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class CherryBomb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 2;
			projectile.friendly = true;
			projectile.penetrate = 1;
			Main.projFrames[projectile.type] = 2;
			projectile.tileCollide = true;
			projectile.thrown = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cherry Bomb");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			} 
			
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = (projectile.direction = -1);
			}
			else if (projectile.velocity.X < 0f)
			{
				projectile.spriteDirection = (projectile.direction = 1);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X + 20, projectile.position.Y + 20, 0f, 0f, mod.ProjectileType("wooboomfriendly"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.PlaySound(SoundID.Item89, projectile.position);
			
			for (int i = 0; i < 3; ++i)
			{
				Vector2 newVect1 = new Vector2 (6, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				int stalin = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect1.X, newVect1.Y, 221, (int)(projectile.damage/3), 5f, projectile.owner);
				Main.projectile[stalin].timeLeft = 200;
				Main.projectile[stalin].tileCollide = true;
				Main.projectile[stalin].thrown = true;
				Main.projectile[stalin].netUpdate = true;
				Main.projectile[stalin].penetrate = -1;
				Main.projectile[stalin].GetGlobalProjectile<Info>(mod).Bouncy = true;
				
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 13;
		}
	}
}