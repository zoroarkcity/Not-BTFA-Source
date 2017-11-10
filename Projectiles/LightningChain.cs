using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class LightningChain : ModProjectile
	{
		NPC npc1;
		NPC npc2;
		NPC npc3;
		NPC npc4;
		int counter;
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 400;
			projectile.alpha = 255;
			projectile.tileCollide = true;
			projectile.extraUpdates = 400;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Lightning");
		}
		
		public override void AI()
		{
			if (projectile.timeLeft <= 395)
			{
				for (int index1 = 0; index1 < 5; ++index1)
				{
					float num1 = projectile.velocity.X / 3f * (float) index1;
					float num2 = projectile.velocity.Y / 3f * (float) index1;
					int num3 = 4;
					int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 229);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].scale = 0.5f;
					Main.dust[index2].velocity *= 0.1f;
					Main.dust[index2].velocity += projectile.velocity * 0.1f;
					Main.dust[index2].position.X -= num1;
					Main.dust[index2].position.Y -= num2;
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (counter == 0)
			{
				npc1 = target;
			}
			if (counter <= 1)
			{
				npc2 = target;
			}
			if (counter <= 2)
			{
				npc3 = target;
			}
			if (counter <= 3)
			{
				npc4 = target;
			}
			Vector2 move = Vector2.Zero;
			float distance = 300f;
			bool xd = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != 488
				&& Main.npc[k].whoAmI != npc1.whoAmI && Main.npc[k].whoAmI != npc2.whoAmI && Main.npc[k].whoAmI != npc3.whoAmI && Main.npc[k].whoAmI != npc4.whoAmI)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						newMove.Normalize();
						move = newMove;
						distance = distanceTo;
						xd = true;
					}
				}
			}
			if (xd)
			{
				projectile.velocity = (move * 8f);
				counter++;
			}
			else
			{
				projectile.Kill();
			}
		}
	}
}