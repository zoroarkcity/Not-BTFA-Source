using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.GhastlyEnt.Boss.Projectiles
{
    public class Sharp_Leaf : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharp Leaf");
        } 
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 14;
            projectile.aiStyle = 1;
			aiType = ProjectileID.WoodenArrowFriendly;
			projectile.timeLeft = 200;
			projectile.hostile = true;
        }
        public override void AI()
        {    
			if (Main.rand.Next(4)==0)
			{
				for (int index1 = 0; index1 < 2; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 2, projectile.velocity.X, projectile.velocity.Y, 50, new Color(), 1.2f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0.1f;
				}
			}
		}
		public override void Kill(int timeLeft)
        {
        }
    }
}