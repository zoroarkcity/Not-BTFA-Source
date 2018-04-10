using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class GoredLung : ModItem
	{
		int AmmoCounter = 0;
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Flamethrower);

			item.damage = 37;
			item.ranged = true;
			item.width = 44;
			item.height = 20;

			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 140000;
			item.rare = 4;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BloodStream");
			item.useAmmo = AmmoID.Gel;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gored Lung");
			Tooltip.SetDefault("Sprays streams of blood, leaves behind some lasting blood");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			if (AmmoCounter == 0)
			{
				AmmoCounter = 5;
				return true;
			}
			else
			{
				return false;
			}
			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			AmmoCounter -= 1;
			return true;
		}
	}
}
