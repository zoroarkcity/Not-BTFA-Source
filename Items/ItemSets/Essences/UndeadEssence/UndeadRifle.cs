using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence 
{
	public class UndeadRifle : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 19;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vampire's Bane");
			Tooltip.SetDefault("Fires homing death energy when below 25% life");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 Accuracy = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-5, 5)));
			speedX = Accuracy.X;
			speedY = Accuracy.Y;
			if (player.statLife <= (int)(player.statLifeMax2 / 4))
			{
				type = mod.ProjectileType("DeathEnergy");
				speedX /= 2;
				speedY /= 2;
				
				int num5 = Dust.NewDust(player.position, player.width, player.height, mod.DustType("UndeadDust"), 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num5].noGravity = true;
				Main.dust[num5].velocity *= 0.75f;
				Main.dust[num5].fadeIn = 1.3f;
				Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
				vector.Normalize();
				vector *= (float)Main.rand.Next(50, 100) * 0.04f;
				Main.dust[num5].velocity = -vector;
				vector.Normalize();
				vector *= 34f;
				Main.dust[num5].position = player.Center;
			}
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "UndeadEnergy", 10);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 2);
		}
	}
}
