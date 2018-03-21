using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class AncientLauncher : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.RocketLauncher);

			item.damage = 50;
			item.ranged = true;
			item.width = 29;
			item.height = 24;

			item.useTime = 48;
			item.useAnimation = 48;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = 50000;
			item.rare = 5;
			item.UseSound = SoundID.Item38;
			item.autoReuse = true;
			//item.shoot = 134;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Rocket;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ancient Launcher");
      Tooltip.SetDefault("Transforms Rockets into Rock Missiles");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float sX, ref float sY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("ROCKet"), damage, knockBack, player.whoAmI);
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-36, -6);
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
