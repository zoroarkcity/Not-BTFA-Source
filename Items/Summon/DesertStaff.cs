using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Summon
{
	public class DesertStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 28;
			item.summon = true;
			item.mana = 10;
			item.width = 19;
			item.height = 19;

			item.useTime = 36;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
            item.knockBack = 2f;
            item.buffType = mod.BuffType("ShadowflameSpirit");
            item.buffTime = 3600;
			item.value = 50000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ShadowflameSpirit");
			ProjectileID.Sets.MinionTargettingFeature[item.shoot] = true;
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Djinn Staff");
      Tooltip.SetDefault("Creates a shadowflame spirit to fight for you");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
