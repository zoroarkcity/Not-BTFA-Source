using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee
{
	public class Intergalactic : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			Tooltip.SetDefault("'Devours foes with pure starlight'");
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("IntergalacticProj");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 8f;

			item.knockBack = 5f;
			item.damage = 82;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 7;
		}
			
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Aaru", 1);
			recipe.AddIngredient(null, "Elysian", 1);
			recipe.AddIngredient(null, "SubmergedAshes", 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
