using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Acheron
{
	public class LostSoul : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.thrown = true;
			item.width = 32;
			item.height = 32;
			item.knockBack = 1.25f;
			item.value = 50;
			item.rare = 0;
			item.shoot = mod.ProjectileType("LostSoul");
			item.shootSpeed = 4f;
			
			item.ammo = item.type;
			item.consumable = true;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Lost Soul");
		}
	}
}
