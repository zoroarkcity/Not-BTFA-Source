using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Cork_Pistol
{
	public class Cork_Pistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cork Pistol");
			Tooltip.SetDefault("Fires a cork\nHas a chance to shoot a spread of short sparks additionally\nUses acorns as ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 12000;
			item.rare = 2;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Cork");
			item.shootSpeed = 13f;
			item.useAmmo = ItemID.Acorn;
		}

		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Barksteel", 7);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(3) == 0)
			{
				Main.PlaySound(SoundID.Item38, item.position);
				int numberProjectiles = 3 + Main.rand.Next(2); 
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(16)); 
					float scale = 2.5f - (Main.rand.NextFloat() * .3f);
					perturbedSpeed = perturbedSpeed * scale; 
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Cork_Shard"), 12, 2f, player.whoAmI);
				}
			}
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 60f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, -4);
		}
	}
}
