using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee
{
	public class Portobello : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			Tooltip.SetDefault("Confuses hit enemies");
            DisplayName.SetDefault("Xenon");
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
			item.shoot = mod.ProjectileType("PortobelloProj");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;

			item.knockBack = 2.5f;
			item.damage = 39;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 5;
		}
	}
}
