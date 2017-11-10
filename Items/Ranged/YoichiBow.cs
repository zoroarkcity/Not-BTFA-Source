using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
    public class YoichiBow : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 15;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 21;

            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 27000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Yoichi Bow");
      Tooltip.SetDefault("Has a chance to fire waterbolts");
    }
	
	public override Vector2? HoldoutOffset()
		{
			return new Vector2(4, 0);
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.Next(4) == 0)
			{
				Vector2 origVect = new Vector2(speedX, speedY);
				Vector2 newVect = origVect.RotatedBy(System.Math.PI / 15);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 15);
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / 20);
				Vector2 newVect4 = origVect.RotatedBy(-System.Math.PI / 20);

				int p = Projectile.NewProjectile(position.X, position.Y, newVect.X * 0.5f, newVect.Y * 0.5f, 27, damage / 2, knockBack, player.whoAmI, 0, 0);
				Main.projectile[p].penetrate = 1;
				Main.projectile[p].magic = false;
				Main.projectile[p].ranged = true;
				int p2 = Projectile.NewProjectile(position.X, position.Y, newVect2.X * 0.5f, newVect2.Y * 0.5f, 27, damage / 2, knockBack, player.whoAmI, 0, 0);
				Main.projectile[p2].penetrate = 1;
				Main.projectile[p2].magic = false;
				Main.projectile[p2].ranged = true;
			}
            return true;
        }
    }
}
