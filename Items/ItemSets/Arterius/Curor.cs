using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class Curor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Curor");
			Tooltip.SetDefault("Drains life from enemies\nJANK AS FUCK. TERRY CANT CODE SPEARS SOMEONE SEND HELP PLS MEW");
		}
		
		public override void SetDefaults()
		{
			item.damage = 40;
			item.knockBack = 6f;
			item.useTime = 24;
			item.useAnimation = 27;
			item.autoReuse = true;

			item.width = 54;
			item.height = 52;
			item.useStyle = 5;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 2, 8, 0);
			item.rare = 4;

			item.noMelee = true;
			item.noUseGraphic = true;
			
			item.shootSpeed = 4f;
			item.shoot = mod.ProjectileType("CurorProjectile");
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}
	}
}
