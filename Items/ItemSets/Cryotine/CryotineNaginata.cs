using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class CryotineNaginata : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(3836);
			item.damage = 27;

			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.maxStack = 1;
			//item.useTime = 27;
			//item.useAnimation = 27;
			item.knockBack = 5f;
			item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.value = 16800;
			item.rare = 2;
			item.shoot = mod.ProjectileType("CryotineNaginata");
			//item.shootSpeed = 42f;
			item.channel = true;
			item.autoReuse = true;

		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Naginata");
      Tooltip.SetDefault("Inflicts frostburn");
    }

		
		public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int Damage, ref float knockBack)
		{
			Vector2 vector2_1 = player.RotatedRelativePoint(player.MountedCenter, true);
			float ai0 = (float) ((double) Main.rand.NextFloat() * (double) item.shootSpeed * 0.75) * (float) player.direction;
            Vector2 velocity = new Vector2(speedX, speedY);
            Projectile.NewProjectile(vector2_1, velocity, type, Damage, knockBack, player.whoAmI, ai0, 0.0f);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
