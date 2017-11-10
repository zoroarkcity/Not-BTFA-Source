using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class ColdSnap : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 250;
			projectile.height = 250;
			projectile.timeLeft = 2;
			projectile.penetrate = -1;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icy Aura");
		}
		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			projectile.timeLeft = 2;
			player.itemTime = 2;
			player.itemAnimation = 2;
			int amountOfDust = (projectile.width/35);
			for (int i = 0; i < amountOfDust; ++i)
				{
					projectile.tileCollide = false;
					int dust;
					dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 135, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
					Main.dust[dust].noGravity = true;
				}
			if (player.statMana <= 1)
			{
				projectile.Kill();
			}
			if (Main.myPlayer == projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					if (projectile.width <= 400 && Main.rand.Next(3) == 0)
					{
						projectile.width++;
						projectile.height++;
					}
					
					if (Main.rand.Next(3) == 0)
					{
						player.statMana -= 1;
					}
					projectile.Center = player.MountedCenter;
					projectile.position.X += player.width / 2 * player.direction;
				}
				else
				{
					projectile.Kill();
				}
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			if (Main.rand.Next(6) == 0)
			{
				target.AddBuff(BuffID.Frostburn, 180, false);
			}
		}
		
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}	