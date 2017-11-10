using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class climaxproj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 98;
			projectile.height = 98;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 21;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 7;
			projectile.scale = 0.75f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Climax");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 6)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 7;
			} 
		}
	}
}