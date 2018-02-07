using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.Summon
{
	public class BlightstoneDragon : HoverShooter
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 72;
			projectile.height = 80;
			Main.projFrames[projectile.type] = 4;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 2;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 20f;
			shootCool = 45f;
			shoot = mod.ProjectileType("BlightBolt");
			shootSpeed = 5f;
			ShootOffset = new Vector2(-36, -4);
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blightstone Dragon");
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 360, false);
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.dead)
			{
				modPlayer.BlightstoneDragon = false;
			}
			if (modPlayer.BlightstoneDragon)
			{
				projectile.timeLeft = 2;
			}
		}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 6)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
			}
		}
	}
}