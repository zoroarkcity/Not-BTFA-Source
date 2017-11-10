using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class CursedLanceProjectile : ModProjectile
    {
    	
        public override void SetDefaults()
        {
			projectile.width = 40;  
			projectile.aiStyle = 19;
			projectile.melee = true; 
			projectile.timeLeft = 90;
			projectile.height = 40;  
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
			projectile.hide = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Lance");
		}

         public override void AI()
        {
			if(projectile.ai[0] == 0f)
        	{
        		projectile.ai[0] = 6f;
        		projectile.netUpdate = true;
        	}
        	Main.player[projectile.owner].direction = projectile.direction;
        	Main.player[projectile.owner].heldProj = projectile.whoAmI;
        	Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
        	projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
        	projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
        	projectile.position += projectile.velocity * projectile.ai[0];
        	if(Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
        	{
        		projectile.ai[0] -= 0.95f;
				if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
				{
					projectile.localAI[0] = 1f;
				}
        	}
        	else
        	{
        		projectile.ai[0] += 1.5f;
        	}
        	
        	if(Main.player[projectile.owner].itemAnimation == 0)
        	{
        		projectile.Kill();
        	}
        	
        	projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
        	if(projectile.spriteDirection == -1)
        	{
        		projectile.rotation -= 1.57f;
        	}
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(39, 360, false);
			}
			float sX = (float)Main.rand.Next(-60, 61) * 0.3f;
			float sY = (float)Main.rand.Next(-60, 61) * 0.3f;
			int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 95, projectile.damage, 5f, projectile.owner);
			Main.projectile[z].magic = false;
			Main.projectile[z].melee = true;
			Main.projectile[z].timeLeft = 100;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position - (7 * projectile.velocity) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), lightColor, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/CoroSpearMask"), projectile.position - (7 * projectile.velocity) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
    }
}