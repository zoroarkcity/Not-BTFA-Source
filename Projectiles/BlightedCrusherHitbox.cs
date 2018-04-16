using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BlightedCrusherHitbox : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 45;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.hide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Crusher");
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			
			if (!player.active || player.dead || player.itemAnimation == 0 || player.altFunctionUse != 2)
			{
				projectile.Kill();
				return;
			}

			projectile.Center = player.Center;
			if (player.direction == -1)
				projectile.position.X -= 60;
			else
				projectile.position.X += 60;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			
			if (target.FindBuffIndex(mod.BuffType("BlightMark")) != -1 && player.active && !player.dead)
			{
				target.immune[projectile.owner] = 3;

				if (Main.rand.Next(2) == 0)
				{
					for (int i = 0; i < 3; i++)
					{
						float posX = target.position.X + Main.rand.Next(target.width);
						float posY = target.position.Y + Main.rand.Next(target.height);
						int p = Projectile.NewProjectile(posX, posY, 0, 0, mod.ProjectileType("BlightBoomRange"), damage, knockback, player.whoAmI);
						Main.projectile[p].ranged = false;
						Main.projectile[p].melee = true;
						Main.projectile[p].scale = 1f + Main.rand.Next(-50, 76) / 100f;
						Main.PlaySound(SoundID.Item14, player.position);
					}
				}
				
				if (!player.immune || player.immuneTime < 30)
				{
					player.immune = true;
					player.immuneTime = 30;
				}
			}
			
			int blightMark = mod.BuffType("BlightMark");
			if (target.buffImmune[blightMark])
				target.buffImmune[blightMark] = false;
			target.AddBuff(blightMark, 120);
		}
	}
}