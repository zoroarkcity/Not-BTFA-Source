using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BlightBullet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 600;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Bullet");
		}
		
		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f); 
			Main.dust[dust].noGravity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("BlightBoomRange"), projectile.damage, 0, projectile.owner);
			Main.projectile[p].scale = 0.75f;
			Main.projectile[p].timeLeft -= 5;
		}
	}
}