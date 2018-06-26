using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class LeafScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 77;
			item.melee = true;
			item.width = 58;
			item.height = 52;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 27000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ForestPortalFriendly");
			item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harvester");
			Tooltip.SetDefault("Creates a bouncing forest rift that ejects leaves");
		}
	}
}
