using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.Ammo 
{
	public class VengeanceBullet : ModItem
	{	
		public override void SetDefaults()
		{

			item.damage = 6;
			item.ranged = true;
			item.width = 22;
			item.height = 22;

			item.shootSpeed = 4.5f;
			item.shoot = mod.ProjectileType("VengeanceBulletP");
			item.knockBack = 1.2f;
			item.UseSound = SoundID.Item1;
			item.value = 100;
			item.rare = 10;
			item.ammo = AmmoID.Bullet;
			item.maxStack = 999;
			item.consumable = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vengeance Bullet");
      Tooltip.SetDefault("Homes in on an enemy it just hit, dealing a portion of the original damage");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
    }

	}
}
