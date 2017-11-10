using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence
{
	public class CactusWand : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11;
			item.magic = true;
			item.mana = 7;
			item.width = 25;
			item.height = 26;
			item.useTime = 22;
			item.UseSound = SoundID.Item43;
			item.useAnimation = 22;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 5000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CactusThorn");
			item.shootSpeed = 7f;
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int projectileAmount = 3;
			for (int k = 0; k < projectileAmount; k++)
			{
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-10, 10)));
				
				Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			}
            return false;
        } 
		
		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Cactus Wand");
		  Tooltip.SetDefault("Fires cactus thorns at enemies");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BossEnergy", 6);
			recipe.AddIngredient(ItemID.Cactus, 35);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
