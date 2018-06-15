using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Magnoliac.Projectiles
{
	public class AcornSeed : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 34;
            projectile.aiStyle = 2;
			projectile.damage = 8;
			projectile.hostile = true;
			projectile.timeLeft = 6000;
			projectile.penetrate = 1;
			projectile.ignoreWater = true;
			aiType = ProjectileID.BeachBall;
			projectile.tileCollide = true;
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 38);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(6, (int)projectile.position.X, (int)projectile.position.Y);
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
            player.AddBuff(BuffID.Poisoned, 360);
		}
	}
}
