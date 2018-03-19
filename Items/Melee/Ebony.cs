using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee
{
	public class Ebony : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 66;
			item.melee = true;
			item.width = 68;
			item.height = 66;

			item.useTime = 30;
			item.crit = 10;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 500000;
			item.rare = 8;
			item.shoot = mod.ProjectileType("CosmirockMeteor");
			item.shootSpeed = 15f;
			item.useTurn = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ebony");
      Tooltip.SetDefault("Rains down blighted meteors \nTrue melee strikes reduce enemy defense");
    }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.75f;
				Main.dust[dust].fadeIn = 1.3f;
				Main.dust[dust].scale = 0.7f;
			}
			
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 65);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.75f;
				Main.dust[dust].fadeIn = 1.3f;
				Main.dust[dust].scale = 0.7f;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Main.PlaySound(2, (int)position.X, (int)position.Y, 88);
			int num8 = 2;
			for (int index = 0; index < num8; ++index)
			{
				Vector2 vector2_1 = new Vector2((float) ((double) player.position.X + (double) player.width * 0.5 + (double) (Main.rand.Next(201) * -player.direction) + ((double) Main.mouseX + (double) Main.screenPosition.X - (double) player.position.X)), player.MountedCenter.Y - 600f);
				vector2_1.X = (float) (((double) vector2_1.X + (double) player.Center.X) / 2.0) + (float) Main.rand.Next(-200, 201);
				vector2_1.Y -= (float) (100 * index);
				float num9 = (float) ((double) Main.mouseX + (double) Main.screenPosition.X - (double) vector2_1.X + (double) Main.rand.Next(-40, 41) * 0.0299999993294477);
				float num10 = (float) Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if ((double) num10 < 0.0)
				num10 *= -1f;
				if ((double) num10 < 20.0)
				num10 = 20f;
				float num11 = (float) Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
				float num12 = item.shootSpeed / num11;
				float num13 = num9 * num12;
				float num14 = num10 * num12;
				float num15 = num13;
				float num16 = num14 + (float) Main.rand.Next(-40, 41) * 0.02f;
				int p = Projectile.NewProjectile(vector2_1.X, vector2_1.Y, num15 * 0.75f, num16 * 0.75f, mod.ProjectileType("BlightedMeteor"), damage, knockBack, player.whoAmI, 0.0f, (float) (0.5 + Main.rand.NextDouble() * 0.300000011920929));
				Main.projectile[p].ai[1] = player.position.Y;
			}
			return false;
        }
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("CosmicCurse"), 180, false);
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
			if (crit == true)
			{
				target.defense -= 10;
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BlightedBoom"), damage, 5f, player.whoAmI, 0f, 0f);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "cosmorock_sword", 1);
			recipe.AddIngredient(null, "BlightedCrusher", 1);
			recipe.AddIngredient(null, "SubmergedAshes", 1);
			recipe.AddIngredient(547, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
