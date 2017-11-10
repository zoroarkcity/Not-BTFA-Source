using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Acheron
{
	public class MacabreGrimoire : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.mana = 15;
			item.magic = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 19;
			item.useAnimation = 19;

			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 50000;
			item.rare = 4;
			item.shoot = mod.ProjectileType("GrimoireHandA");
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Macabre Grimoire");
		  Tooltip.SetDefault("Casts hands of the dead to strike enemies");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(3) == 0)
			{
				type = mod.ProjectileType("GrimoireHandB");
				speedX *= 1.5f;
				speedY *= 1.5f;
				damage += (int)(damage/3);
			}
			return true;
		}
	}
}
