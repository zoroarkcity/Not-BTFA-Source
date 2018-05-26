using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class HexwoodWand : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 46;
			item.magic = true;
			item.mana = 15;
			item.width = 25;
			item.height = 26;
			item.useTime = 23;
			item.UseSound = SoundID.Item103;
			item.crit = 4;
			item.useAnimation = 23;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 50000;
			item.rare = 3;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DarkMagicFriendly");
			item.shootSpeed = 7f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Eldritch Wand");
		  Tooltip.SetDefault("Casts a piercing bolt of dark magic that slowly chases after enemies");
		}
	}
}
