using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class PineStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.magic = true;
			item.mana = 3;
			item.width = 25;
			item.height = 26;

			item.useTime = 10;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 10000;
			item.rare = 3;
			item.autoReuse = true;
			item.shoot = 336;
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pine Staff");
      Tooltip.SetDefault("Constantly ejects pine needles");
    }

		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.03f;
			sY += (float)Main.rand.Next(-60, 61) * 0.03f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
