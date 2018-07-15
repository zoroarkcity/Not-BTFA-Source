using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Serrated_Dagger       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class Serrated_Dagger : ModItem
    {
		public override void SetDefaults()
		{
			item.damage = 7;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.thrown = true;
			item.value = 12000;
			item.width = 20;
			item.height = 20;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 2.15f;
			item.rare = 2;
			item.UseSound = SoundID.Item7;
			item.autoReuse = false;
			item.shootSpeed = 7f;
			item.shoot = mod.ProjectileType("Serrated_Dagger_Projectile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Serrated Dagger");
			Tooltip.SetDefault("Throws a dagger that stick to ground or enemies\nWill slowly drain your enemies life if stuck\nWill deal contact damage when stuck on the ground\nCannot be used if there are more than 4 static projectiles\nRight Click to delete static daggers");
		}
		
		public override bool AltFunctionUse(Player player)
		{
			for (int k = 0; k < Main.projectile.Length; k++)
            { 
		        Projectile proj = Main.projectile[k];
				if (proj.active && proj.type == mod.ProjectileType("Serrated_Dagger_Static") && proj.owner == player.whoAmI)
                { 
                    proj.Kill();
					player.GetModPlayer<WhirlingWorldsPlayer>().SerratedDaggerProjectileCount = 0;
                }
            }
            return false;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.GetModPlayer<WhirlingWorldsPlayer>().SerratedDaggerProjectileCount > 3)
            { 
                return false;
            }
            return true;
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Barksteel", 7);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
 
    }
}
