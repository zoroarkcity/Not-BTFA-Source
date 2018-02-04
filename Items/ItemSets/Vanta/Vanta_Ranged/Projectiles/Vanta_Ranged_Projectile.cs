using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Vanta.Vanta_Ranged.Projectiles
{
    public class Vanta_Ranged_Projectile : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vanta Heatwave");
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
			int Type = 87 + Main.rand.Next(4);
			Player player = Main.player[projectile.owner];
			if ((double) Vector2.Distance(player.Center, projectile.Center) >= (double) 100f)
			{
				for (int index1 = 0; index1 < 10; ++index1)
                {
                    float x = projectile.position.X - projectile.velocity.X / 5f * (float) index1;
                    float y = projectile.position.Y - projectile.velocity.Y / 5f * (float) index1;
                    int index2 = Dust.NewDust(new Vector2(x, y), 1, 1, Type, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index2].alpha = projectile.alpha;
                    Main.dust[index2].position.X = x;
                    Main.dust[index2].position.Y = y;
			        Main.dust[index2].scale = (float) Main.rand.Next(50, 50) * 0.013f;
                    Main.dust[index2].velocity *= 0.0f;
                    Main.dust[index2].noGravity = true;
                }
			}
		}
    }
}