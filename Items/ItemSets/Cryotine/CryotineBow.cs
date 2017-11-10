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

			item.damage = 11;
			item.ranged = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 25;
			item.useAnimation = 25;

			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 16800;
			item.noMelee = true;
			item.rare = 2;
			item.shoot = 3;
			item.shootSpeed = 10f;
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
      Tooltip.SetDefault("Has a chance to fire a spread of frostburn arrows");
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
			if (Main.rand.Next(4) == 0)
			{
				for (int i = 0; i < 3; ++i)
				{
					float sX = speedX;
					float sY = speedY;
					sX += (float)Main.rand.Next(-60, 61) * 0.05f;
					sY += (float)Main.rand.Next(-60, 61) * 0.05f;
					int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, ProjectileID.FrostburnArrow, damage, knockBack, player.whoAmI);
					Main.projectile[p].noDropItem = true;
				}
			}
			
			return true;
		}
	}
}
