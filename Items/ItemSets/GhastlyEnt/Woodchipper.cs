using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt 
{
	public class Woodchipper : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.ranged = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 12;
			item.useAnimation = 12;
			item.UseSound = SoundID.Item36;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 27000;
			item.rare = 7;
			item.autoReuse = true;

			item.shoot = 10; 
			item.shootSpeed = 7f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wood Chipper");
			Tooltip.SetDefault("Fires a bullet along with a number of woodchips");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = 2;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.03f;
				sY += (float)Main.rand.Next(-60, 61) * 0.03f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("Woodchip"), damage / 3, knockBack, player.whoAmI);
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}
	}}
