using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ForgottenMemories.Items.Melee
{
	public class ObliterationBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 70;
			item.melee = true;
			item.width = 62;
			item.height = 62;

			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 2000000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Obliteration Blade");
      Tooltip.SetDefault("Shreds your enemies in seconds \nKilling enemies with more than 100 max life restores health and creates an explosion of blood");
    }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5);
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5);
				Main.dust[dust2].scale = 2.5f;
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			if (target.life <= 0 && target.lifeMax >= 100)
            {
				player.HealEffect((int)(target.lifeMax * 0.005));
				player.statLife += ((int)(target.lifeMax * 0.005));
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BloodBoom"), damage, 0f, player.whoAmI, 0f, 0f);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"murderblade", 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}
