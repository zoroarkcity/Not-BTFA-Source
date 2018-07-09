using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class CryotineBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 28;
			item.ranged = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 22;
			item.useAnimation = 22;

			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 16800;
			item.noMelee = true;
			item.rare = 2;
			item.shoot = 3;
			item.shootSpeed = 8f;
            item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Bow");
      Tooltip.SetDefault("Lights wooden arrows ablaze with icy fire");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (type == ProjectileID.WoodenArrowFriendly)
				type = ProjectileID.FrostburnArrow;
			
			return true;
		}
	}
}
