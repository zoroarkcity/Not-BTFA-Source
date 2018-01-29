using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged
{
	public class VortexLauncher : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.RocketLauncher);

			item.damage = 48;
			item.ranged = true;
			item.width = 29;
			item.height = 24;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = 10000;
			item.rare = 10;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			//item.shoot = 134;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Rocket;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vortex Launcher");
      Tooltip.SetDefault("'Fires a rocket that tears the fabric of space'");
    BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/VortexLauncher");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/VortexLauncher"),
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
		}/////////////////////////////////////////////////////////WORLD GLOWMASK///////////////////////////

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("VortexRocket"), damage, knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3456, 18);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}
		
		public override bool ConsumeAmmo(Player player)
	    {
	    	if (Main.rand.Next(0, 100) <= 66)
			{
	    		return false;
			}
	    	return true;
	    }
	}
}
