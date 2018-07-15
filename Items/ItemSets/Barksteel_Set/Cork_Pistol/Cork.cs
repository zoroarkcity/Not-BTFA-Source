using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Cork_Pistol
{
    public class Cork : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cork");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4; 
            projectile.aiStyle = 1;
            projectile.friendly = true; 
            projectile.hostile = false;
            projectile.tileCollide = true; 
            projectile.ranged = true;   
            projectile.timeLeft = 400; 
			projectile.extraUpdates = 0;
			projectile.scale = 1f;
            aiType = ProjectileID.Bullet;		
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int num2 = Main.rand.Next(20, 40);
            for (int index1 = 0; index1 < num2; ++index1)
            {
                int index2 = Dust.NewDust(projectile.Center, 0, 0, 7, 0.0f, 0.0f, 100, new Color(), 0.8f);
                Main.dust[index2].velocity *= 1.2f;
                --Main.dust[index2].velocity.Y;
                Main.dust[index2].velocity += projectile.velocity;
                Main.dust[index2].noGravity = true;
            }
		}
		public override void Kill(int timeLeft)
		{
			int num2 = Main.rand.Next(20, 40);
            for (int index1 = 0; index1 < num2; ++index1)
            {
                int index2 = Dust.NewDust(projectile.Center, 0, 0, 7, 0.0f, 0.0f, 100, new Color(), 0.8f);
                Main.dust[index2].velocity *= 1.2f;
                --Main.dust[index2].velocity.Y;
                Main.dust[index2].velocity += projectile.velocity;
                Main.dust[index2].noGravity = true;
            }
		}
    }
}