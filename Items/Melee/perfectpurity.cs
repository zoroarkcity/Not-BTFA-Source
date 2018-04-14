using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ForgottenMemories.Items.Melee
{
	public class perfectpurity : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 115;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item18;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LightBall");
			item.shootSpeed = 10;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Perfect Purity");
      Tooltip.SetDefault("Fires bouncing bolts of light that create pillars of light on hit");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Purity", 1);
			recipe.AddIngredient(ItemID.Meowmere, 1);
			recipe.AddIngredient(ItemID.LightShard, 1);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, (int)position.X, (int)position.Y, 9);
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.05f;
			sY += (float)Main.rand.Next(-60, 61) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, (int)(damage * 1.6f), knockBack, player.whoAmI, (float)(damage * 1.6f), 0f);
			
			float sX2 = speedX;
			float sY2 = speedY;
			sX2 += (float)Main.rand.Next(-60, 61) * 0.05f;
			sY2 += (float)Main.rand.Next(-60, 61) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, sX2, sY2, type, (int)(damage * 1.6f), knockBack, player.whoAmI, (float)(damage * 1.6f), 0f);
			
			return false;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 160);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			Projectile.NewProjectile(target.Center.X, target.Center.Y - 500, 0, 15, mod.ProjectileType("LightPillar"), damage * 2, knockback, player.whoAmI, 0f, 0f);
        }
	}
}
