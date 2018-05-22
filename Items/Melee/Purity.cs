using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class Purity : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 110;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.useTurn = true;
			item.rare = 8;
			item.UseSound = SoundID.Item18;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LightBeam");
			item.shootSpeed = 10;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Purity");
      Tooltip.SetDefault("Fires a high damage, bouncing beam of light that loses damage over time");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 160);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, (int)position.X, (int)position.Y, 9);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)(damage * 1.8f), knockBack, player.whoAmI, (float)(damage * 1.8f), 0f);
			return false;
		}
	}
}
