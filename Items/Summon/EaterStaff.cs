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

namespace ForgottenMemories.Items.Summon
{
    public class EaterStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 13;
            item.summon = true;
            item.mana = 10;
            item.width = 42;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2f;
            item.buffType = mod.BuffType("EaterMinion");
            item.buffTime = 3600;
            item.value = 27000;
            item.rare = 2;
            item.UseSound = SoundID.Item82;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EaterMinion");
			ProjectileID.Sets.MinionTargettingFeature[item.shoot] = true;
            item.shootSpeed = 10f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Eater Staff");
      Tooltip.SetDefault("Summons Eaters of Souls to fight");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddIngredient(ItemID.RottenChunk, 4);
			recipe.AddIngredient(ItemID.ShadowScale, 6);
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
