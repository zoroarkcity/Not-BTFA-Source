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
    public class WoodlouseStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 32;
            item.summon = true;
            item.mana = 10;
            item.width = 42;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4f;
            item.buffType = mod.BuffType("Woodlice");
            item.buffTime = 3600;
            item.value = 27000;
            item.rare = 3;
            item.UseSound = SoundID.Item82;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("WoodlouseMinion");
			ProjectileID.Sets.MinionTargettingFeature[item.shoot] = true;
            item.shootSpeed = 10f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Woodlouse Staff");
      Tooltip.SetDefault("Summons a Woodlouse to devour your foes");
    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			return false;
		}
    }
}
