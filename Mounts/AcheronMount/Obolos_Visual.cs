using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Mounts.AcheronMount
{
    public class Obolos_Visual: ModProjectile
    {
		Vector2 Location;
		Vector2 Location2;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obolos Wisp");
        } 
        public override void SetDefaults()
        {
			projectile.width = 4;
			projectile.height = 4;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			projectile.scale = 1f;
			projectile.tileCollide = false;
			projectile.hide = true;
			Main.projFrames[projectile.type] = 15;
        }
		public override void AI()
        {
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				Vector2 position = new Vector2(projectile.position.X, projectile.position.Y);
				dust = Terraria.Dust.NewDustPerfect(position , 229, new Vector2(0f, -0.5263156f), 150, new Color(255,255,255), 1f);
				dust.noGravity = true;
				dust.noLight = true;
			}
			if (projectile.ai[0] == 0)
			{
				Location = projectile.Center - Main.player[(int)projectile.ai[1]].Center;
				Location2 = projectile.Center - Main.player[(int)projectile.ai[1]].Center;
				projectile.ai[0]++;
			}
			else
			{
				Location2 = Location.RotatedBy((MathHelper.Pi / 180));
				Location = Location2;
				projectile.Center = Location + Main.player[(int)projectile.ai[1]].Center;
			}
        }
    }
}