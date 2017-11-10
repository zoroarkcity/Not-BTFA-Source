using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class BladeOfMight : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.useTime = 36;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 500000;
			item.rare = 5;
			item.shoot = mod.ProjectileType("MightBeam");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 13f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Blade of Might");
		  Tooltip.SetDefault("Fires an explosive sword beam");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 29);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
		}
	}
}
