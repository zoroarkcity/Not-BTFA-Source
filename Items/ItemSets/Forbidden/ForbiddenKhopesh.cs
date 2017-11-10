using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenKhopesh : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 46;
			item.melee = true;
			item.width = 96;
			item.height = 88;

			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("ForboodenSlush");
		}


    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Khopesh");
      Tooltip.SetDefault("Slashes at enemies");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(ItemID.TitaniumBar, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 32, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity.X += player.direction * 2f;
				Main.dust[dust].velocity.Y += 0.2f;
			}
		}
	}
}
