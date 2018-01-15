using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEnt
{
    public class Ball_of_the_Hallow_Ent : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ball of the Hallow Ent");
        }
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 20; 
            projectile.aiStyle = 1;
            projectile.friendly = true; 
            projectile.hostile = false;
            projectile.tileCollide = true; 
            projectile.thrown = true;   
            projectile.timeLeft = 1000; 
			projectile.extraUpdates = 0;
			projectile.scale = 1f;
			Main.projFrames[projectile.type] = 4;
            aiType = ProjectileID.Bullet;		
        }
		public override void AI()
        {
			projectile.frameCounter++;
			
			if (projectile.frameCounter > 6)
			{
			   projectile.frame++;
               projectile.frameCounter = 1;
			}
            if (projectile.frame > 3)
            {
               projectile.frame = 0;
            }
			
			if (Main.rand.Next(9) == 0)
			{
				int index = Dust.NewDust(projectile.Center, 8, 8, 75, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].position = projectile.Center;
				Main.dust[index].velocity *= 0.2f;
				Main.dust[index].noGravity = true;
				Main.dust[index].scale = 1f;
			}
			if (Main.rand.Next(9) == 0)
			{
				int index = Dust.NewDust(projectile.Center, 8, 8, 75, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].position = projectile.Center;
				Main.dust[index].velocity *= 0.2f;
				Main.dust[index].noGravity = true;
				Main.dust[index].scale = 1.5f;
			}
			if (Main.rand.Next(9) == 0)
			{
				int index = Dust.NewDust(projectile.Center, 8, 8, 75, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].position = projectile.Center;
				Main.dust[index].velocity *= 0.2f;
				Main.dust[index].noGravity = true;
				Main.dust[index].scale = 2f;
			}
	    }	
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(2, 4), false);
			int num2 = Main.rand.Next(20, 40);
            for (int index1 = 0; index1 < num2; ++index1)
            {
                int index2 = Dust.NewDust(projectile.Center, 0, 0, 75, 0.0f, 0.0f, 100, new Color(), 0.8f);
                Main.dust[index2].velocity *= 1.2f;
                --Main.dust[index2].velocity.Y;
                Main.dust[index2].velocity += projectile.velocity;
                Main.dust[index2].noGravity = true;
            }
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item122, projectile.position);
			int num23 = 36;
                for (int index1 = 0; index1 < num23; ++index1)
                {
                    Vector2 vector2_3 = (Vector2.Normalize(projectile.velocity) * new Vector2((float) projectile.width / 2f, (float) projectile.height) * 0.75f * 0.5f).RotatedBy((double) (index1 - (num23 / 2 - 1)) * 6.28318548202515 / (double) num23, new Vector2()) + projectile.Center;
                    Vector2 vector2_4 = vector2_3 - projectile.Center;
                    int index2 = Dust.NewDust(vector2_3 + vector2_4, 0, 0, 75, vector2_4.X * 2f, vector2_4.Y * 2f, 100, new Color(), 1.4f);
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].noLight = false;
                    Main.dust[index2].scale = 1.5f;
                    Main.dust[index2].velocity = Vector2.Normalize(vector2_4) * 5f;
                }
			if (projectile.owner == Main.myPlayer)
			{
				projectile.penetrate = -1;
				projectile.position.X += (float) (projectile.width / 2);
				projectile.position.Y += (float) (projectile.height / 2);
				projectile.width = 86;
				projectile.height = 86;
				projectile.position.X -= (float) (projectile.width / 2);
				projectile.position.Y -= (float) (projectile.height / 2);
				projectile.Damage();
			}
			int type = 39;
			if (projectile.owner == Main.myPlayer)
            {
                for (int index2 = 0; index2 < 200; ++index2)
                {
                    NPC npc = Main.npc[index2];
                    if (npc.active && !npc.friendly && (npc.damage > 0 && !npc.dontTakeDamage) && (!npc.buffImmune[type] && (double) Vector2.Distance(projectile.Center, npc.Center) <= (double) 100f))
                    {
                        npc.AddBuff(type, 300, false);
                    }
                }
			}
		}
    }
}