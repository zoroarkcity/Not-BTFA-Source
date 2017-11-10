using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class AquaticKatana : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 29;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 50000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Aquatic Katana");
		  Tooltip.SetDefault("Splashes water on hit");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 33);
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			if (player.direction != 1)
			{
				float sX = (float)Main.rand.Next(-150, -50) * 0.1f;
				float sY = (float)Main.rand.Next(-20, 20) * 0.1f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, mod.ProjectileType("AquaBolt"), damage, 0f, player.whoAmI, 0f, 0f);
			}
			else
			{
				float sX = (float)Main.rand.Next(50, 150) * 0.1f;
				float sY = (float)Main.rand.Next(-20, 20) * 0.1f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, mod.ProjectileType("AquaBolt"), damage, 0f, player.whoAmI, 0f, 0f);
			}
        }
	}
}
