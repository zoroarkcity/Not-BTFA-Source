using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class BlueFlare : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 128;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useTurn = true;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 250000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Dragonfire Blade");
		  Tooltip.SetDefault("Striking enemies creates a pillar of fire");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 18);
			recipe.AddIngredient(ItemID.FragmentSolar, 8);
			recipe.AddIngredient(ItemID.Sapphire, 8);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RedFlare", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BlueFlare2"), damage, 0f, player.whoAmI, 0f, (float)player.whoAmI);
        }
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
			}
		}
	}
}
