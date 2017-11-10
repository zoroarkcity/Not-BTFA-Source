using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence 
{
	public class NightlyBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 30000;
            item.rare = 1;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.shoot = mod.ProjectileType("LeechingArrow");
			item.shootSpeed = 8f;
			item.scale = 1.1f;
			item.noMelee = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nightly Bow");
      Tooltip.SetDefault("Turns arrows into piercing night arrows");
    }
	
	public override Vector2? HoldoutOffset()
		{
			return new Vector2(3, 0);
		}

		
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == 1)
            {
                type = mod.ProjectileType("NightlyArrow");
            }
            return true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DarkEnergy", 8);
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddRecipeGroup("AnyIron", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
