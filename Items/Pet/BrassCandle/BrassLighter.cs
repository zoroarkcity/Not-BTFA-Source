using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet.BrassCandle
{
	public class BrassLighter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Lighter");
			Tooltip.SetDefault("Summons a candlebra to provide light and burn enemies");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("BrassCandle");
			item.width = 16;
			item.height = 30;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 4;
			item.buffType = mod.BuffType("BrassCandleBuff");
			item.noMelee = true;
			item.value = 10000;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassAlloy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(mod.BuffType("BrassCandleBuff"), 3600, true);
			}
		}
	}
}
