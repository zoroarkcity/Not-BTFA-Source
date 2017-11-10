using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class TreeStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 35;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 27000;
			item.rare = 2;
			item.UseSound = SoundID.Item82;
			item.shoot = mod.ProjectileType("TreeMinion");
			item.shootSpeed = 20f;
			ProjectileID.Sets.MinionTargettingFeature[item.shoot] = true;
			item.buffType = mod.BuffType("TreeMinion");
			item.buffTime = 3600;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ent Staff");
      Tooltip.SetDefault("Summons a ghastly tree to fight for you");
    }

		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
