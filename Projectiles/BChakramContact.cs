using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BChakramContact : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = -1;
			projectile.extraUpdates = 2;
            projectile.timeLeft = 600;
			projectile.tileCollide = false;
			projectile.hide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Chakram");
		}
		
		public override void AI()
		{
			Projectile parent = Main.projectile[(int) projectile.ai[0]];
			if (!parent.active || parent.type != mod.ProjectileType("BlightedChakram2"))
			{
				projectile.Kill();
				return;
			}
			projectile.Center = parent.Center;
		}

		public override void Kill (int timeLeft)
		{
			Projectile parent = Main.projectile[(int) projectile.ai[0]];
			if (parent.active && parent.type == mod.ProjectileType("BlightedChakram2"))
			{
				parent.Kill();
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
			target.GetGlobalNPC<BTFANPC>(mod).blightChakramHits++;
			if (target.GetGlobalNPC<BTFANPC>(mod).blightChakramHits == 4)
			{
				target.GetGlobalNPC<BTFANPC>(mod).blightChakramHits = 0;
				target.immune[projectile.owner] = 0;
				
				for (int i = 0; i < 5; i++)
				{
					float posX = target.position.X + Main.rand.Next(target.width);
					float posY = target.position.Y + Main.rand.Next(target.height);
					int p = Projectile.NewProjectile(posX, posY, 0, 0, mod.ProjectileType("BlightBoomRange"), damage * 2, knockback * 1.5f, projectile.owner);
					Main.projectile[p].ranged = false;
					Main.projectile[p].thrown = true;
					Main.projectile[p].scale = 1f + Main.rand.Next(-75, 51) / 100f;
					Main.projectile[p].Damage();
				}

				Main.PlaySound(SoundID.Item20, target.position);
			}
			
			target.AddBuff(mod.BuffType("BlightFlame"), 420, false);
		}
	}
}