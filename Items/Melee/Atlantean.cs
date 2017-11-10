using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee
{
	public class Atlantean : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			Tooltip.SetDefault("'It reeks of seawater'");
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
			item.shoot = mod.ProjectileType("AtlanteanProj");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 8f;

			item.knockBack = 4f;
			item.damage = 26;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 3;
		}
	}
}
