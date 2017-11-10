using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class ForcedPride : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 145;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 900000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 5f;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forced Pride");
      Tooltip.SetDefault("Striking an enemy with the blade will unleash piercing and explosive sparks \nStriking a low health enemy with the blade will create more sparks, restore some health, and greatly lower their defense \nKilling an enemy with the blade will restore even more health \n'A blade fit for a god'");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RoyalCrusher", 1);
			recipe.AddIngredient(ItemID.CrystalShard, 20);
			recipe.AddIngredient(ItemID.BeetleHusk, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 69);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
			if (Main.rand.Next(6) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 137);
				Main.dust[dust2].scale = 1.2f;
				Main.dust[dust2].noGravity = true;
			}
			if (Main.rand.Next(2) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 63);
				Main.dust[dust2].scale = 1.1f;
				Main.dust[dust2].noGravity = true;
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			float sX = 3f;
			float sY = 3f;
			sX += (float)Main.rand.Next(-60, 61) * 0.2f;
			sY += (float)Main.rand.Next(-60, 61) * 0.2f;
			
			if (Main.rand.Next(2) == 0)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, sX, sY, mod.ProjectileType("PiercingSpark"), damage, knockback, player.whoAmI, 0f, 0f);
            }
			
			if (Main.rand.Next(2) == 0)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, sX, sY, mod.ProjectileType("ExplosiveSpark"), damage, knockback, player.whoAmI, 0f, 0f);
            }
			if (target.life <= (target.lifeMax/2))
            {
                target.AddBuff(69, 1800, false);
				target.AddBuff(203, 1800, false);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, sX, sY, mod.ProjectileType("PiercingSpark"), damage, knockback, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, sX, sY, mod.ProjectileType("ExplosiveSpark"), damage, knockback, player.whoAmI, 0f, 0f);
				player.HealEffect((int)(damage * 0.01));
				player.statLife += ((int)(damage * 0.01));
            }
			if (target.life <= 0)
            {
				player.HealEffect((int)(damage * 0.05));
				player.statLife += ((int)(damage * 0.05));
            }
        }
	}
}
