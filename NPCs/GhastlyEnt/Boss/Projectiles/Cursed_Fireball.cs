using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.GhastlyEnt.Boss.Projectiles
{
    public class Cursed_Fireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Fireball");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; 
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        } 
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 14;
            projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			projectile.timeLeft = 200;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.extraUpdates = 1;
			Main.projFrames[projectile.type] = 4;
			projectile.hide = true;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {    
			projectile.frameCounter++;
			if (projectile.frameCounter > 6)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame > 3)
			{
				projectile.frame = 0;
			}
			projectile.direction = projectile.spriteDirection;
			projectile.rotation = projectile.direction >= 0 ? (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) : (float) Math.Atan2(-(double) projectile.velocity.Y, -(double) projectile.velocity.X);
			
			for (int index = 0; index < 2; ++index)
			{
			  Dust dust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 163, projectile.velocity.X, projectile.velocity.Y, 100, new Color(), 1f)];
			  dust.velocity = dust.velocity / 4f + projectile.velocity / 2f;
			  dust.noGravity = true;
			  dust.scale = 1.5f;
			  dust.position = projectile.Center;
			  dust.noLight = true;
			}
			{
				Vector2 vector2 = projectile.Center + Vector2.Normalize(projectile.velocity) / 2f;
				Dust dust1 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 163, 0.0f, 0.0f, 0, new Color(), 1f)];
				dust1.position = vector2;
				dust1.velocity = projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 120f;
				dust1.position += projectile.velocity.RotatedBy(1.57079637050629, new Vector2());
				dust1.fadeIn = 0.5f;
				dust1.noGravity = true;
				Dust dust2 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 163, 0.0f, 0.0f, 0, new Color(), 1f)];
				dust2.position = vector2;
				dust2.velocity = projectile.velocity.RotatedBy(-1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 120f;
				dust2.position += projectile.velocity.RotatedBy(-1.57079637050629, new Vector2());
				dust2.fadeIn = 0.5f;
				dust2.noGravity = true;
			}
		}
		public override void Kill(int timeLeft)
        {
        }
    }
}