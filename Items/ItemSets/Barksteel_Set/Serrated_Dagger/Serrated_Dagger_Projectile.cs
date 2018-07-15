using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Serrated_Dagger
{
    public class Serrated_Dagger_Projectile : ModProjectile
    {	
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
            projectile.friendly = true;
			projectile.thrown = true;
            projectile.penetrate = 3;
			projectile.scale = 1f;
            projectile.timeLeft = 800;
			projectile.extraUpdates = 1;
			projectile.tileCollide = true;
        }
		
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Serrated Dagger");
        } 
		
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}
		
		public bool isStickingToTarget
		{
			get { return projectile.ai[0] == 1f; }
			set { projectile.ai[0] = value ? 1f : 0f; }
		}

		public float targetWhoAmI
		{
			get { return projectile.ai[1]; }
			set { projectile.ai[1] = value; }
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			isStickingToTarget = true; 
			targetWhoAmI = (float)target.whoAmI;
			projectile.velocity =
				(target.Center - projectile.Center) *
				0.75f;
			projectile.netUpdate = true;
			target.AddBuff(mod.BuffType("SerratedTag"), 300); 

			projectile.damage = 0;

			int oldJavelinIndex = 0;
			int javelinIndex = 0;
			int maxStickingJavelins = 3; 
			 Point[] stickingJavelins = new Point[maxStickingJavelins]; 
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI 
				    && currentProjectile.active
				    && currentProjectile.owner == Main.myPlayer 
				    && currentProjectile.type == projectile.type 
				    && currentProjectile.ai[0] == 1f 
				    && currentProjectile.ai[1] == (float)target.whoAmI
				)
				{
					stickingJavelins[javelinIndex++] =
						new Point(i, currentProjectile.timeLeft); 
					if (javelinIndex >= stickingJavelins.Length
					) 
					{
						break;
					}
				}
			}
			if (javelinIndex >= stickingJavelins.Length)
			{
				for (int i = 1; i < stickingJavelins.Length; i++)
				{
					if (stickingJavelins[i].Y < stickingJavelins[oldJavelinIndex].Y)
					{
						oldJavelinIndex = i;
					}
				}
				Main.projectile[stickingJavelins[oldJavelinIndex].X].Kill();
			}
		}
		
		private const float maxTicks = 45f;
		
		public override void AI()
		{
			if (isStickingToTarget)
			{
				projectile.ignoreWater = true;
				projectile.tileCollide = false; 
				int aiFactor = 15; 
				bool killProj = false; 
				bool hitEffect = false;
				projectile.localAI[0] += 1f;
				hitEffect = projectile.localAI[0] % 30f == 0f;
				int projTargetIndex = (int)targetWhoAmI;
				if (projectile.localAI[0] >= (float)(60 * aiFactor)
				    || (projTargetIndex < 0 || projTargetIndex >= 200)) 
				{
					killProj = true;
				}
				else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
				{
					projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
					if (hitEffect)
					{
						Main.npc[projTargetIndex].HitEffect(0, 1.0);
					}
				}
				else 
				{
					killProj = true;
				}

				if (killProj)
				{
					projectile.Kill();
				}
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Player player = Main.player[projectile.owner];
			player.GetModPlayer<WhirlingWorldsPlayer>().SerratedDaggerProjectileCount += 1;
			for (int index2 = 0; index2 < 1; ++index2)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("Serrated_Dagger_Static"), 7, 0f, Main.myPlayer, 0f, 0f); 
            }
			return true;
		}
		
		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			
			Vector2 usePos = projectile.position;	
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); 
			usePos += rotVector * 16f;

			for (int i = 0; i < 20; i++)
			{	
				int dustIndex = Dust.NewDust(usePos, projectile.width, projectile.height, 8, 0f, 0f, 0, default(Color), 1f);
				Dust currentDust = Main.dust[dustIndex];
				currentDust.position = (currentDust.position + projectile.Center) / 2f;
				currentDust.velocity += rotVector * 2f;
				currentDust.velocity *= 0.5f;
				currentDust.noGravity = true;
				usePos -= rotVector * 8f;
			}
		}
    }
}