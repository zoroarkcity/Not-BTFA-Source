using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class infrost : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 48;
			item.melee = true;
			item.width = 62;
			item.height = 70;

			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 200000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("infrost");
			item.shootSpeed = 8;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Serial Inferost");
      Tooltip.SetDefault("Fires a wave of extreme cold that freezes your foes");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Frostbrand, 1);
			recipe.AddIngredient(ItemID.IceBlade, 1);
			recipe.AddIngredient(ItemID.FrostCore, 3);
			recipe.AddIngredient(null,"CryotineBar", 18);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Frostbrand, 1);
			recipe.AddIngredient(null, "CryotineKatana", 1);
			recipe.AddIngredient(ItemID.FrostCore, 3);
			recipe.AddIngredient(null,"CryotineBar", 18);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 67);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
				Main.dust[dust2].scale = 1.2f;
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) < 2)
			{
				target.AddBuff(BuffID.Frostburn, 60, false);
			}
			if (Main.rand.Next(100) < 99)
			{
				target.AddBuff(mod.BuffType("Frozen"), 10, false);
			}
			
		}
	}
}
