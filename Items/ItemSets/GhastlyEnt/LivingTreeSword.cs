using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt 
{
	public class LivingTreeSword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 82;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 30;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 7.5f;
			item.value = 27000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Willow Wood Blade");
		  Tooltip.SetDefault("Creates druidic energy blades on hit");
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			Vector2 Center = (new Vector2(150, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 31))) * player.direction) + target.Center;
			Vector2 Velocity = target.Center - Center;
			Velocity.Normalize();
			Velocity *= 12;
			Projectile.NewProjectile(Center, Velocity, mod.ProjectileType("DruidBlade"), damage, 0f, player.whoAmI);
        }
	}
}
