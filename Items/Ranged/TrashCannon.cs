using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class TrashCannon : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 41;
			item.ranged = true;
			item.width = 40;
			item.height = 14;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;

			item.knockBack = 6;
			item.value = 250000;
			item.rare = -1;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 14f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Rocket;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Trash Cannon");
      Tooltip.SetDefault("Has a chance to launch explosive garbage");
    }

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-22, -8);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < Main.rand.Next(2) + 1; i++)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.03f;
				sY += (float)Main.rand.Next(-60, 61) * 0.03f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("ExplosiveTrash"), damage, knockBack, player.whoAmI); 
			}
			
			return false;
		}
	}
}
