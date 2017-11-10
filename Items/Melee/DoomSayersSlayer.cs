using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee
{
	public class DoomSayersSlayer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 200;
			item.melee = true;
			item.width = 82;
			item.height = 82;

			item.useTime = 16;
			item.useAnimation = 16;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				item.useStyle = 1;
			}
			item.knockBack = 6;
			item.value = 637500;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DoomBeam");
			item.shootSpeed = 10;
		}
		
		    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Doom Sayer's Slayer");
      Tooltip.SetDefault("Fires a homing bolt of Reality Fury \nRight-Clicking fires bolts of Despair, Dread, and Anger \nOnly usable if Thorium is installed");
    }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
				Main.dust[dust2].scale = 0.5f;
				Main.dust[dust2].noGravity = true;
				int dust3 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
				Main.dust[dust3].scale = 0.5f;
				Main.dust[dust3].noGravity = true;
			}
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(255, 127, 0);
                }
            }
        }
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void AddRecipes()
        {
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence"));
				recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence"));
				recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence"));
				recipe.AddTile(412);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Vector2 newVect = new Vector2(speedX, speedY);
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.Pi / 16);
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.Pi / -16);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect.X, newVect.Y, mod.ProjectileType("AngerBolt"), damage/2, knockBack, player.whoAmI, 0f, 0f);
				
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector2 = new Vector2(4, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
					int kek = Projectile.NewProjectile(position.X, position.Y, vector2.X, vector2.Y, mod.ProjectileType("DespairBolt"), damage, knockBack, player.whoAmI);
				}
				
				int num8 = 1;
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
					Projectile.NewProjectile(vector2_1.X, vector2_1.Y, num15 * 0.75f, num16 * 0.75f, mod.ProjectileType("DreadBolt"), damage, knockBack, player.whoAmI, 0.0f, (float) (0.5 + Main.rand.NextDouble() * 0.300000011920929));
				}
				
				return false;
			}
			
			else
			{
				
				Vector2 newVect = new Vector2(9, 0);
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.Pi / 2);
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.Pi);
				Vector2 newVect4 = newVect.RotatedBy(3*MathHelper.Pi / 2);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect.X, newVect.Y, mod.ProjectileType("DoomBeam"), damage, knockBack, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect2.X, newVect2.Y, mod.ProjectileType("DoomBeam"), damage, knockBack, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect3.X, newVect3.Y, mod.ProjectileType("DoomBeam"), damage, knockBack, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, newVect4.X, newVect4.Y, mod.ProjectileType("DoomBeam"), damage, knockBack, player.whoAmI, 0f, 0f);
				return false;
			}
		}
	}
}
