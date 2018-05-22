using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class impurity : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 116;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item18;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DarkWave");
			item.shootSpeed = 14;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Impurity");
      Tooltip.SetDefault("Fires a wave of dark energy that inflicts several debuffs");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 173);
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, (int)position.X, (int)position.Y, 15);
			return true;
		}
	}
}
