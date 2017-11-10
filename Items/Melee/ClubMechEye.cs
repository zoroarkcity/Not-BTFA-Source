using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubMechEye : ModItem
	{
		Vector2 gayvector = new Vector2(0f, -5f);
		Vector2 homovector = new Vector2(0f, 5f);
		Vector2 bivector = new Vector2(-5f, 0f);
		Vector2 lesvector = new Vector2(5f, 0f);
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Visionary Clobber");
			Tooltip.SetDefault("'Said to use the spread of retinazer itself'\nFires a circle of red lasers");
		}
		public override void SetDefaults()
		{
			item.damage = 86; 
			item.crit = 2;
			item.melee = true;
			item.knockBack = 6; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 55;
			item.useAnimation = 55;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 100000;
			item.rare = 7;
			item.expert = true;
			item.shoot = 1;
			item.shootSpeed = 10;
		}
			
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
			}
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 newVect = gayvector.RotatedBy(System.Math.PI / 35);
			gayvector = newVect;
			homovector = gayvector.RotatedBy(System.Math.PI);
			bivector = gayvector.RotatedBy(System.Math.PI / 2);
			lesvector = gayvector.RotatedBy(System.Math.PI / -2);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, gayvector.X, gayvector.Y, mod.ProjectileType("Retinlaser"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, homovector.X, homovector.Y, mod.ProjectileType("Retinlaser"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, bivector.X, bivector.Y, mod.ProjectileType("Retinlaser"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, lesvector.X, lesvector.Y, mod.ProjectileType("Retinlaser"), damage, 1, Main.myPlayer, 0, 0);
			Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 15);
			return false;
		}
	}
}
