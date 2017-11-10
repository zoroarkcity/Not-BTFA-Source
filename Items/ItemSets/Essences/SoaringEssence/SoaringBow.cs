using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence 
{
	public class SoaringBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soaring Bow");
			Tooltip.SetDefault("Turns wooden arrows into gravity ignoring arrows");
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}
		
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == 1)
            {
                type = mod.ProjectileType("SoaringArrow");
            }
            return true;
        }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
