using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet
{
	public class HauntedCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Haunted Candle");
			Tooltip.SetDefault("Summons a haunted candle that increases enemy spawn rates \nDoes not stack with water candles");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("HauntedCandle");
			item.width = 16;
			item.height = 30;
			item.UseSound = SoundID.NPCHit36;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 3;
			item.buffType = mod.BuffType("HauntedCandle");
			item.noMelee = true;
			item.value = Item.sellPrice(0, 5, 50, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WaterCandle, 1);
			recipe.AddIngredient(null, "WaterShard", 12);
			recipe.AddIngredient(null, "UndeadEnergy", 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(mod.BuffType("HauntedCandle"), 3600, true);
			}
		}
	}
}
