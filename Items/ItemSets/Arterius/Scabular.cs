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
			Tooltip.SetDefault("Casts blood balls that deal increasing damage over time\nEnemies that die while debuffed will explode into boiling blood and infect nearby enemies");
		}
		
		public override void SetDefaults()
		{
			item.damage = 59;
			item.noMelee = true;
			item.magic = true;
			item.mana = 14;
			item.width = 40;
			item.height = 40;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("BloodBall");
			item.UseSound = SoundID.Item8;
			item.knockBack = 4.4f;
			item.value = Item.sellPrice(0, 2, 8, 0);
			item.rare = 4;
			item.autoReuse = true;
			item.shootSpeed = 11.8f;
		}
	}
}
