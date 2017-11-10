using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class SnowstormCannon : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 10;
			item.ranged = true;
			item.width = 46;
			item.height = 28;
			item.useTime = 16;
			item.useAnimation = 16;

			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 16800;
			item.noMelee = true;
			item.rare = 2;
			item.shoot = 3;
			item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Snowball;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Snowstorm Cannon");
		  Tooltip.SetDefault("33% chance not to consume ammo \nHas a chance to launch a larger, splitting snowball");
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 10);
			recipe.AddIngredient(ItemID.SnowballCannon, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(3) == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
			
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, -2);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.Next(5) == 0)
			{
				int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].scale = 1.75f;
				Main.projectile[p].GetGlobalProjectile<Info>(mod).SnowSplit = true;
				return false;
			}
			
			return true;
		}
	}
}
