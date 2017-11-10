using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class IchorBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 98;
			projectile.height = 98;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 15;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 7;
			projectile.scale = 1.25f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosive Ichor");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Ichor, 500);
		}
	}
}