using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class Needler : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 46;
			item.noMelee = true;
			item.ranged = true;
			item.width = 27;
			item.height = 11;
			item.useTime = 16;

			item.useAnimation = 16;
			item.useStyle = 5;
			item.shoot = 3;
			item.useAmmo = 40;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 5;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Needle Bow");
      Tooltip.SetDefault("Has a 1/3 chance to fire 2 homing lasers");
    }


		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(3) == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					float sX = speedX;
					float sY = speedY;
					sX += (float)Main.rand.Next(-60, 61) * 0.03f;
					sY += (float)Main.rand.Next(-60, 61) * 0.03f;
					Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("laserbeamNeedle"), damage / 2, knockBack, player.whoAmI);
				}
			}
			return true;
		}
	}
}
