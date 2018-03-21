using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee
{
	public class WyvernScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 74;
			item.melee = true;
			item.width = 58;
			item.height = 52;

			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6.5f;
			item.value = 138000;
			item.rare = 6;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.shoot = 85;
			item.shootSpeed = 9f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wyvern Scythe");
      Tooltip.SetDefault("Creates a burst of short ranged wind blades that move around you in a spiral pattern");
    }

		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			for (int i = 0; i < 8; i++)
			{
				Vector2 Offset = Vector2.UnitX * 10;
				Offset.RotatedBy(MathHelper.ToRadians(360/8 * i));
				int ai = (speedX < 0) ? -1 : 1;
				int p = Projectile.NewProjectile(position + Offset, Offset, Mod.ProjectileType("Windblade"), damage, knockBack, player.whoAmI, 0, ai);
			}
			return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFlight, 15);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
