using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Spiritflame
{
	public class SpiritSpear : ModProjectile
	{
		int timer = 0;
		public override void SetDefaults()
		{
			projectile.width = 19;
			projectile.height = 19;
			projectile.scale = 1.1f;
			projectile.aiStyle = 19;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 90;
			projectile.hide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Lance");
		}


		public override void AI()
		{
			Main.player[projectile.owner].direction = projectile.direction;
			Main.player[projectile.owner].heldProj = projectile.whoAmI;
			Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
			projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
			projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
			projectile.position += projectile.velocity * projectile.ai[0]; if (projectile.ai[0] == 0f)
			{
				projectile.ai[0] = 3f;
				projectile.netUpdate = true;
			}
			if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
			{
				projectile.ai[0] -= 0.8f;
			}
			else
			{
				projectile.ai[0] += 0.7f;
			}

			if (Main.player[projectile.owner].itemAnimation == 0)
			{
				projectile.Kill();
			}

			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= 1.57f;
			}
			
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
			
			Vector2 move = Vector2.Zero;
			float distance = 190f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != 488)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						newMove.Normalize();
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			timer++;
			if (target && timer >= 7)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, move.X * 12f, move.Y * 12f, mod.ProjectileType("SpiritBoomer"), projectile.damage, 5f, projectile.owner);
				timer = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("Spiritflame"), 180, false);
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position - (7 * projectile.velocity) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), lightColor, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/SpiritSpear"), projectile.position - (7 * projectile.velocity) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}