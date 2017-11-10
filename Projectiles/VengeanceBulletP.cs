using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class VengeanceBulletP : ModProjectile
    {
		int j = 0;
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.magic = true;
            projectile.width = 2;
            projectile.height = 2;
			projectile.alpha = 255;
            projectile.friendly = true;
			projectile.tileCollide = true;
            projectile.penetrate = 2;
			projectile.extraUpdates = 1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
            projectile.timeLeft = 300;
			projectile.light = 0.2f;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vengeance Bullet");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 269);
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			for (int i = 0; i < 200; i++)
            {
				if (Main.npc[i] == target)
				{
					j = i;
				}
			}
			projectile.damage = (int)projectile.damage/5;
			projectile.tileCollide = false;
		}

        public override void AI()
        {
			int num;
			int num2 = 3;
			if (projectile.timeLeft <= 296)
			{
				for (int num164 = 0; num164 < 5; num164 = num + 1)
				{
					float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)(num164 * 2);
					float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)(num164 * 2);
					int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 269, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num165].position.X = x2;
					Main.dust[num165].position.Y = y2;
					Dust dust3 = Main.dust[num165];
					dust3.velocity *= 0f;
					Main.dust[num165].noGravity = true;
					num = num164;
				}
			}
			
			Vector2 targetPos = projectile.Center;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (projectile.penetrate == 1 && Main.npc[j].life >= 0)
            {
				targetPos = Main.npc[j].Center;
                float homingSpeedFactor = 7f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist2 = projectile.Distance(targetPos);
                dist2 = homingSpeedFactor / dist2;
                homingVect *= dist2;

                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
            }
        }
    }       
}
