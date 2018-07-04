using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class CryotineKatana : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 17;
			item.melee = true;
			item.crit = 23;
			item.width = 88;
			item.height = 88;
			item.useTime = 12;
			item.useAnimation = 12;

			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 16800;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Katana");
      Tooltip.SetDefault("Inflicts frostburn on hit \nHit enemies freeze, greatly reducing movement speed");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 67);
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(BuffID.Frostburn, (60 * Main.rand.Next(1, 4)), false);
			target.AddBuff(mod.BuffType("Frozen"), 60, false);
        }
	}
}
