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
			item.damage = 52;
			item.noMelee = true;
            item.melee = false;
			item.thrown = true;
            item.width = 30;
            item.height = 30;

            item.useTime = 11;
            item.useAnimation = 11;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 7;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("BlightedChakram");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
			item.useTurn = false;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Chakram");
			Tooltip.SetDefault("Throws chakrams that baptise enemies in blighted flame\nLeft click to throw homing chakrams\nRight click to throw piercing chakrams");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (player.altFunctionUse == 2)
			{
				int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BlightedChakram2"), 0, 0f, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, 0, 0, mod.ProjectileType("BChakramContact"), damage, knockBack, Main.myPlayer, p);
			}
			else
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
			}
            return false;
        }
		
        public override bool AltFunctionUse(Player player)
		{
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
