using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class CapillaryRepeater : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Capillary Repeater");
			Tooltip.SetDefault("Fires arrows that wring the blood from enemies");
		}
		
		public override void SetDefaults()
		{
			item.damage = 24;
			item.noMelee = true;
			item.ranged = true;
			item.width = 40;
			item.height = 26;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 5;
			item.shoot = 3;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.knockBack = 2.5f;
			item.value = Item.sellPrice(0, 2, 8, 0);
			item.rare = 4;
			item.autoReuse = true;
			item.shootSpeed = 11f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("BloodArrow");
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			float sX = speedX + Main.rand.Next(-20, 21) * 0.1f;
			float sY = speedY + Main.rand.Next(-20, 21) * 0.1f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
