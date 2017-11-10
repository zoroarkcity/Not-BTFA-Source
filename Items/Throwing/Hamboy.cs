using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class Hamboy: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ham Shank");
			Tooltip.SetDefault("'There's a reason you don't eat it...'");
		}		
		
		public override void SetDefaults()
		{
			item.damage = 27;
			item.thrown = true;
			item.width = 30;
			item.height = 30;
			item.useAnimation = 25;
			item.useTime = 25;
			item.maxStack = 999;
			item.consumable = true;
			item.useStyle = 1;
			item.autoReuse = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 0, 0, 1);
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("HamboyProj");
			item.shootSpeed = 10f;
		}
	}
}
