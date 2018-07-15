using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Cork_Pistol
{
    public class Cork_Shard: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cork Shard");
        } 
        public override void SetDefaults()
        {
        projectile.width = 4;
        projectile.height = 4;
        projectile.aiStyle = 24;
        projectile.friendly = true;
        projectile.alpha = 50;
        projectile.scale = 0f;
        projectile.timeLeft = 900;
        projectile.ranged = true;
        projectile.tileCollide = true;
        }
		
		public override void AI()
        {
			Player player = Main.player[projectile.owner];
			if ((double) Vector2.Distance(player.Center, projectile.Center) >= (double) 40f)
			{
				for (int index1 = 0; index1 < 5; ++index1)
                {
                    float x = projectile.position.X - projectile.velocity.X / 10f * (float) index1;
                    float y = projectile.position.Y - projectile.velocity.Y / 10f * (float) index1;
                    int index2 = Dust.NewDust(new Vector2(x, y), 1, 1, 6, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index2].alpha = projectile.alpha;
                    Main.dust[index2].position.X = x;
                    Main.dust[index2].position.Y = y;
			        Main.dust[index2].scale = (float) Main.rand.Next(60, 60) * 0.013f;
                    Main.dust[index2].velocity *= 0.1f;
                    Main.dust[index2].noGravity = true;
                }
			}
        }
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item98, projectile.position);
		}
    }
}