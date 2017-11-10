using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class HellstoneGlaiveP : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Shuriken);
			projectile.width = 22;
			projectile.height = 22;
			projectile.penetrate = 2;
			aiType = ProjectileID.Shuriken;
			projectile.ignoreWater = true;
			projectile.timeLeft = 6000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosive Shuriken");
		}
		
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 4);
			projectile.position.Y += (float) (projectile.height / 4);
			projectile.width = (int) (64.0 * (double) projectile.scale);
			projectile.height = (int) (64.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 4);
			projectile.position.Y -= (float) (projectile.height / 4);
			for (int index1 = 0; index1 < 16; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 100, new Color(), 2.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 3f;
			}
			int index3 = Gore.NewGore(projectile.position + new Vector2((float) (projectile.width * Main.rand.Next(100)) / 100f, (float) (projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
			Main.gore[index3].velocity *= 0.3f;
			Main.gore[index3].velocity.X += (float) Main.rand.Next(-10, 11) * 0.05f;
			Main.gore[index3].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.05f;
			
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f;
				projectile.maxPenetrate = 0;
				projectile.Damage();
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 180, false);
			Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("HellstoneGlaiveBoom"), projectile.damage, 0f, projectile.owner, 0f, 0f);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				target.AddBuff(24, 180, false);
			}
		}
	}


	public class HellstoneGlaive : ModItem
	{

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.shoot = mod.ProjectileType("HellstoneGlaiveP");
			item.damage = 28;
			item.rare = 2;
			item.autoReuse = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellstone Glaive");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(175, 1);
			recipe.AddTile(16);
			recipe.SetResult(this, 60);
			recipe.AddRecipe();
		}
	}
}
