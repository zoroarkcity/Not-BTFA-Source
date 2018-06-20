using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class TonsilLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tonsil Launcher");
			Tooltip.SetDefault("Fires an infinite amount of Exploding Tonsils");
		}
		
		public override void SetDefaults()
		{
			item.damage = 65;
			item.noMelee = true;
			item.thrown = true;
			item.width = 30;
			item.height = 28;
			item.useTime = 37;
			item.useAnimation = 37;
			item.useStyle = 5;
			item.shoot = 133;
			item.UseSound = SoundID.NPCDeath13;
			item.knockBack = 4.4f;
			item.value = Item.sellPrice(0, 2, 8, 0);
			item.rare = 4;
			item.autoReuse = true;
			item.shootSpeed = 10.4f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("ExplodingTonsil");
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
