using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.DevilFlame
{
	public class Incinerator : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 30;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 50000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Devil's Blade");
		  Tooltip.SetDefault("Striking the enemy with the blade lights them ablaze and temporarily reduces defense");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DevilFlame", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 360, false);
			target.AddBuff(mod.BuffType("DevilsCurse"), 360, false);
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
	}
}
