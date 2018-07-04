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

namespace ForgottenMemories.Items.ItemSets.Arterius
{
    public class HemorrhageStaff : ModItem
    {
        public override void SetDefaults()
        {
			item.damage = 35;
            item.summon = true;
            item.mana = 10;
            item.width = 42;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2f;
            item.buffType = mod.BuffType("BloodSlime");
            item.buffTime = 3600;
            item.value = 140000;
            item.rare = 4;
            item.UseSound = SoundID.Item82;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BloodSlime");
            item.shootSpeed = 10f;
			ProjectileID.Sets.MinionTargettingFeature[item.shoot] = true;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hemorrhage Staff");
			Tooltip.SetDefault("Summons an Accursed Bloodling that dashes towards enemies");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			return false;
		}
    }
}
