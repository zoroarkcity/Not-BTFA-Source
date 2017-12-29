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
			projectile.width = 150;
			projectile.height = 150;
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
			for (int index1 = 0; index1 < 1; ++index1)
			if (Main.rand.Next(4) == 0)
			{
				int dust;
				Vector2 newVect = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(player.Center, 0, 0, 111, newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(player.Center, 0, 0, 111, newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(player.Center, 0, 0, 111, newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(player.Center, 0, 0, 111, newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(player.Center, 0, 0, 111, newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(player.Center, 0, 0, 111, newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(player.Center, 0, 0, 111, newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(player.Center, 0, 0, 111, newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
				Main.dust[dust].scale = 2;
				Main.dust[dust2].scale = 2;
				Main.dust[dust3].scale = 2;
				Main.dust[dust4].scale = 2;
				Main.dust[dust5].scale = 2;
				Main.dust[dust6].scale = 2;
				Main.dust[dust7].scale = 2;
				Main.dust[dust8].scale = 2;
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