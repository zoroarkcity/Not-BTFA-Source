using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEnt
{

	public class BranchBodyFriendly : ModProjectile
	{
		int dist = -60;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.alpha = (int) byte.MaxValue;
			projectile.ignoreWater = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghastly Branch");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(186, 500, false);
		}
		
		public override void AI()
		{
			Vector2 position = new Vector2(0, dist + ((projectile.ai[1] >= 4f) ? 10 : 0)).RotatedBy(projectile.rotation);
			if ((double) projectile.ai[0] == 0.0)
			{
				projectile.alpha = projectile.alpha - 50;
				if (projectile.alpha > 0)
					return;
				projectile.alpha = 0;
				projectile.ai[0] = 1f;
				if ((double) projectile.ai[1] == 0.0)
				{
					projectile.ai[1]++;
					projectile.position = (projectile.position + (projectile.velocity * 1f));
				}
				if (projectile.type == mod.ProjectileType("BranchBodyFriendly") && Main.myPlayer == projectile.owner)
				{
					int type = projectile.type;
					if ((double) projectile.ai[1] >= 4.0)
						type = mod.ProjectileType("BranchTipFriendly");
					int number = Projectile.NewProjectile((float) (projectile.Center.X + position.X), (float) (projectile.Center.Y + position.Y), (float) projectile.velocity.X, (float) projectile.velocity.Y, type, projectile.damage, projectile.knockBack, projectile.owner, 0.0f, 0.0f);
					Main.projectile[number].damage = projectile.damage;
					Main.projectile[number].rotation = projectile.rotation;
					Main.projectile[number].ai[1] = projectile.ai[1] + 1f;
					NetMessage.SendData(27, -1, -1, (NetworkText) null, number, 0.0f, 0.0f, 0.0f, 0, 0, 0);
				}
			}
			else
			{
				if (projectile.alpha < 170 && projectile.alpha + 5 >= 170)
				{
					for (int index = 0; index < 3; ++index)
						Dust.NewDust(projectile.position, projectile.width, projectile.height, 14, (float) (projectile.velocity.X * 0.025000000372529), (float) (projectile.velocity.Y * 0.025000000372529), 170, new Color(), 1.2f);
					Dust.NewDust(projectile.position, projectile.width, projectile.height, 163, 0.0f, 0.0f, 170, new Color(), 1.1f);
				}
				projectile.alpha += 3;;
				if (projectile.alpha < (int) byte.MaxValue)
					return;
				projectile.Kill();
			}
		}
	}
}