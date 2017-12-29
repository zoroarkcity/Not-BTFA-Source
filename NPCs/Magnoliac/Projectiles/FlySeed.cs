using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.Magnoliac.Projectiles
{
    public class FlySeed : ModProjectile
    {
 
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 102;
            projectile.hostile = true;
			projectile.scale = 1f;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
			projectile.extraUpdates = 0;
			projectile.tileCollide = false;
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flying Seed");
        } 
		public override void Kill(int timeLeft)
        {
            for(int i=0; i<45; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 110);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;
            }
        }
    }
}