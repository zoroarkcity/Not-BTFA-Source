using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class StaticAura : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 250;
			projectile.height = 250;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 4;
			projectile.tileCollide = false;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Static Electricity");
		}
		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			int amountOfDust = 6;
			for (int i = 0; i < amountOfDust; ++i)
				{
					projectile.tileCollide = false;
					int dust;
					dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
					Main.dust[dust].scale = 0.7f;
					Main.dust[dust].noGravity = true;
				}
			if (Main.myPlayer == projectile.owner)
			{
				if (player.inventory[player.selectedItem].type == mod.ItemType("LightningDagger") && !player.noItems && !player.CCed)
				{
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
			target.AddBuff(mod.BuffType("Electrified"), 2, false);
		}
		
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}	