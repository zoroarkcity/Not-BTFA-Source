using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
    public class CerberusShockwave : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cerberus Shockwave");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;  //Set the hitbox width
            projectile.height = 4;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
			projectile.penetrate = -1;
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether it is hostile to players or not
            projectile.melee = true;   //Tells the game whether it is a ranged projectile or not
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
			projectile.extraUpdates = 2;
			projectile.scale = 1f;
            aiType = ProjectileID.Bullet;		
        }
        public override void AI()
        {
			Lighting.AddLight(projectile.position, 0f, 0.5f, 1f);
            for (int index1 = 0; index1 < 10; ++index1)
                {
                    float x = projectile.position.X - projectile.velocity.X / 10f * (float) index1;
                    float y = projectile.position.Y - projectile.velocity.Y / 10f * (float) index1;
                    int index2 = Dust.NewDust(new Vector2(x, y), 1, 1, 111, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index2].alpha = projectile.alpha;
                    Main.dust[index2].position.X = x;
                    Main.dust[index2].position.Y = y;
			        Main.dust[index2].scale = (float) Main.rand.Next(30, 80) * 0.013f;
                    Main.dust[index2].velocity *= 0.0f;
                    Main.dust[index2].noGravity = true;
                }
		}
    }
}