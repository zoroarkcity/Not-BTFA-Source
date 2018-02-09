using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class arknife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 23;
			item.ranged = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 0.5f;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("arknife");
			item.shootSpeed = 8;
			item.noMelee = true;
			item.noUseGraphic = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ark Dagger");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ThrowingKnife, 250);
			recipe.AddIngredient(null,"DarkEnergy", 4);
			recipe.AddIngredient(null,"BossEnergy", 4);
			recipe.AddIngredient(null,"SoaringEnergy", 4);
			recipe.AddIngredient(null,"UndeadEnergy", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void GetWeaponDamage(Player player, ref int damage)
		{
			damage = (int)((damage / player.rangedDamage)* player.thrownDamage);
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit = (crit - player.rangedCrit)+ player.thrownCrit;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " throwing " + damageWord;
			}
		}
	}
}
