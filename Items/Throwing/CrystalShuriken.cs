using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class CrystalShurikenP : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.CloneDefaults(3);
			projectile.width = 22;       //projectile width
			projectile.height = 22;
			projectile.penetrate = 1;
			aiType = 3;
			projectile.ignoreWater = true;
			projectile.timeLeft = 6000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Shuriken");
		}


		public override void Kill(int timeLeft)
		{
			int num = Main.rand.Next(3, 7);
			for (int index1 = 0; index1 < num; ++index1)
			{
				int index2 = Dust.NewDust(projectile.Center - (projectile.velocity/2f), 0, 0, 67, projectile.velocity.X/3, projectile.velocity.Y/3, 100, new Color(), 2.1f);
				Dust dust = Main.dust[index2];
				Main.dust[index2].noGravity = true;
			}
			
			int amountOfProjectiles = Main.rand.Next(3, 4);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
				float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
				int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 90, 15, 5f, projectile.owner);
				Main.projectile[p].thrown = true;
				Main.projectile[p].ranged = false;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}

	public class CrystalShuriken : ModItem
	{

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.shoot = mod.ProjectileType("CrystalShurikenP");
			item.damage = 37;
			item.rare = 4;
			item.autoReuse = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Shuriken");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 1);
			recipe.AddTile(16);
			recipe.SetResult(this, 33);
			recipe.AddRecipe();
		}
	}
}
