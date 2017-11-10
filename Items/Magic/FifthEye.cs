using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
    public class FifthEye : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 107;
            item.magic = true;
            item.mana = 8;
            item.width = 16;
            item.height = 17;
			item.noUseGraphic = true;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 27000;
            item.rare = 10;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LunarBolt");
            item.shootSpeed = 2.25f;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("The Fifth Eye");
		  Tooltip.SetDefault("'Predicts the locations of enemies and annihilates them'");
		}


        public override void HoldItem(Player player)
        {
            player.AddBuff(BuffID.Hunter, 2);
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int projectileAmount = 3;
			for (int k = 0; k < projectileAmount; k++)
			{
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-15, 15)));
				
				Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			}
            return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FourthEye", 1);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
