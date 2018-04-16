using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.ItemSets.Blightstone
{
    public class BlightedChakram : ModItem
    {
        public override void SetDefaults()
        {
			item.damage = 130;            
            item.melee = false;
			item.thrown = true;
            item.width = 30;
            item.height = 30;

            item.useTime = 10;
            item.useAnimation = 10;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 250000;
            item.rare = 7;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType ("BlightedChakram");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Chakram");
			Tooltip.SetDefault("Throws 4 chakrams that pierce through enemies at an insane velocity");
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			//float damageMultiplier = (player.meleeDamage + player.thrownDamage) / 2;
			//damage = item.damage * damageMultiplier;
			
			int projectileAmount = 4;
			Vector2 velVect = new Vector2(speedX, speedY);
			//Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect.X, velVect.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			for (int k = 0; k < projectileAmount; k++)
			{
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-15, 15)));
				
				Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			}
            return false;
        }
		
        public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
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
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
