using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class Scabular : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scabular");
			Tooltip.SetDefault("Casts blood balls that inflict a plethora of curses upon enemies");
		}
		
		public override void SetDefaults()
		{
			item.damage = 34;
			item.noMelee = true;
			item.magic = true;
			item.mana = 24;
			item.width = 40;
			item.height = 40;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("BloodBall");
			item.UseSound = SoundID.Item8;
			item.knockBack = 4.4f;
			item.value = Item.sellPrice(0, 2, 8, 0);
			item.rare = 4;
			item.autoReuse = true;
			item.shootSpeed = 11.8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX + Main.rand.Next(-24, 25) * 0.14f, speedY + Main.rand.Next(-24, 25) * 0.14f, type, damage, knockBack, player.whoAmI, 1f);
			Projectile.NewProjectile(position.X, position.Y, speedX + Main.rand.Next(-24, 25) * 0.14f, speedY + Main.rand.Next(-24, 25) * 0.14f, type, damage, knockBack, player.whoAmI, 2f);
			return false;
		}
	}
}
