using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Melee
{
	public class LightningDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 42;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 3;
			item.knockBack = 3;
			item.value = 60000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Lightning Dagger");
      Tooltip.SetDefault("Creates an aura of static electricity when hitting enemies");
    }

		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("StaticAura"), damage, 0f, player.whoAmI, 0f, 0f);
        }
	}
}
