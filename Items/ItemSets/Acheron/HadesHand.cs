using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Acheron
{
	public class HadesHand : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 26;
			item.thrown = true;
			item.width = 32;
			item.height = 32;
			item.useTime= 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 4;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LostSoul");
			
			item.shootSpeed = 10f;
			item.useAmmo = mod.ItemType("LostSoul");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glove of Hades");
      Tooltip.SetDefault("Throws Lost Souls \n20% chance not to consume ammo");
    }

		
		
		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(5) == 0)
			{
				return false;
			}
			return true;
		}
		
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			for (int k = 0; k < Main.rand.Next(1, 4); k++)
			{
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-10, 10)));
				Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			}
            return false;
        }
	}
}
