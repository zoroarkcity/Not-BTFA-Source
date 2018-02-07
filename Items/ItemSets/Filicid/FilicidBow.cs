using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Filicid
{
	public class FilicidBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.ranged = true;
			item.width = 20;
			item.height = 36;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 800;
            item.rare = 1;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.shoot = 1;
			item.shootSpeed = 8.25f;
			item.noMelee = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Filicid Bow");
      Tooltip.SetDefault("Has a chance to fire a blood cell that sticks to enemies, lowering defense");
    }

		
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(3) == 0)
            {
				Vector2 Vel =  new Vector2(speedX, speedY);
				Vel *= 0.8f;
                int p = Projectile.NewProjectile(position, Vel, mod.ProjectileType("FilicidCellRange"), (int)(damage/2), knockBack, player.whoAmI);
				Main.projectile[p].netUpdate = true;
            }
            return true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"FilicidCore", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
