using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class FinaleBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 52;
			projectile.height = 52;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = projectile.timeLeft;
			Main.projFrames[projectile.type] = 5;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Finale Boom");
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.velocity = player.velocity;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 2)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 5;
			} 
		}
		
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int thing = 153;
			switch (Main.rand.Next(8))
			{
			case 0: thing = 189;
				break;
			case 1: thing = mod.BuffType("DevilsFlame");
				break;
			case 2: thing = mod.BuffType("Electrified");
				break;
			case 3: thing = mod.BuffType("BlightFlame");
				break;
			case 4: thing = 69;
				break;
			case 5: thing = 72;
				break;
			case 6: thing = 70;
				break;
			case 7: thing = 153;
				break;
			default: break;
			}
			target.AddBuff(thing, 360, false);
		}
	}
}