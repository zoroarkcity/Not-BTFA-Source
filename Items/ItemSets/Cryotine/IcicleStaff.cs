using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class IcicleStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.magic = true;
			item.mana = 6;
			item.width = 21;
			item.height = 22;
			item.channel = true;
			item.useTime = 4;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 4;
			item.reuseDelay = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			Item.staff[item.type] = true;
			item.value = 16800;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("IceMagic");
			item.shootSpeed = 9f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 vel = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
			Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, type, damage, knockBack, player.whoAmI);
			
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 10);
			recipe.AddIngredient(ItemID.Diamond, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Icicle Staff");
		  Tooltip.SetDefault("Creates a storm of ice magic that orbits you and flies towards your cursor when releasing the attack button");
		}

	}
}
