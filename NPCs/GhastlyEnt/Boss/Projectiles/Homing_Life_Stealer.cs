using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.GhastlyEnt.Boss.Projectiles
{
    public class Homing_Life_Stealer: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Healing Magic");
        } 
        public override void SetDefaults()
        {
			projectile.timeLeft = 270;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.hide = true;
			projectile.friendly = false;
			projectile.extraUpdates = 1;			
            projectile.hostile = true;
        }
		public override void AI()
        {			
			Player player = Main.LocalPlayer;
			
			projectile.rotation = projectile.direction >= 0 ? (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) : (float) Math.Atan2(-(double) projectile.velocity.Y, -(double) projectile.velocity.X);
			Vector2 vector2_1 = (new Vector2(0.0f, (float) Math.Cos((double) projectile.frameCounter * 6.28318548202515 / 40.0 - 1.57079637050629)) * 16f).RotatedBy((double) projectile.rotation, Vector2.Zero);
			  Vector2 vector2_2 = projectile.velocity.SafeNormalize(Vector2.Zero);
			  for (int index = 0; index < 1; ++index)
			  {
				Dust dust1 = Dust.NewDustDirect(projectile.Center - projectile.Size / 4f, projectile.width / 2, projectile.height / 2, 75, 0.0f, 0.0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.2f);
				int num1 = 1;
				dust1.noGravity = num1 != 0;
				Vector2 vector2_3 = projectile.Center + vector2_1;
				dust1.position = vector2_3;
				Vector2 vector2_4 = dust1.velocity * 0.0f;
				dust1.velocity = vector2_4;
				double num2 = 0.79999997615814;
				dust1.fadeIn = (float) num2;
				double num3 = 1.14999997615814;
				dust1.scale = (float) 1f;
				int num4 = 1;
				Vector2 vector2_5 = dust1.position + projectile.velocity * 1.2f;
				dust1.position = vector2_5;
				Vector2 vector2_6 = dust1.velocity + vector2_2 * 2f;
				dust1.velocity = vector2_6;
				Dust dust2 = Dust.NewDustDirect((projectile.Center - projectile.Size / 4f), projectile.width / 2, projectile.height / 2, 110, 0.0f, 0.0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.1f);
				int num5 = 1;
				dust2.noGravity = num5 != 0;
				Vector2 vector2_7 = projectile.Center + vector2_1;
				dust2.position = vector2_7;
				Vector2 vector2_8 = dust2.velocity * 0.0f;
				dust2.velocity = vector2_8;
				double num6 = 0.89999997615814;
				dust2.fadeIn = (float) num6;
				double num7 = 1.14999997615814;
				dust2.scale = (float) 0.5f;
				int num8 = 1;
				Vector2 vector2_9 = dust2.position + projectile.velocity * 0.5f;
				dust2.position = vector2_9;
				Vector2 vector2_10 = dust2.position + projectile.velocity * 1.2f;
				dust2.position = vector2_10;
				Vector2 vector2_11 = dust2.velocity + vector2_2 * 2f;
				dust2.velocity = vector2_11;
			  }
			int num9 = projectile.frameCounter + 1;
			projectile.frameCounter = num9;
			if (num9 >= 40)
				projectile.frameCounter = 0;
			projectile.frame = projectile.frameCounter / 5;
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 800f;
			if (distance > 800f)
			{
				projectile.active = false;
			}
			else
			{
				projectile.active = true;
			}
			bool target = false;
			Vector2 newMove = player.Center - projectile.Center;
			float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
			if (distanceTo < distance)
			{
				move = newMove;
				distance = distanceTo;
				target = true;
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 3f;
				AdjustMagnitude(ref projectile.velocity);
			}
        }
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
		public override void OnHitPlayer (Player target, int damage, bool crit)
		{
			int num2 = Main.rand.Next(20, 40);
            for (int index1 = 0; index1 < num2; ++index1)
            {
                int index2 = Dust.NewDust(projectile.Center, 0, 0, 110, 0.0f, 0.0f, 100, new Color(), 0.8f);
                Main.dust[index2].velocity *= 1.2f;
                --Main.dust[index2].velocity.Y;
                Main.dust[index2].velocity += projectile.velocity;
                Main.dust[index2].noGravity = true;
            }
			projectile.Kill();
		}
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			float num = 32f;
            for (int index1 = 0; (double) index1 < (double) num; ++index1)
            {
              Vector2 vector2 = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(1f, 4f)).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2());
              int index2 = Dust.NewDust(projectile.Center, 0, 0, 110, 0.0f, 0.0f, 0, new Color(), 2f);
              Main.dust[index2].scale = 1.5f;
              Main.dust[index2].noLight = true;
              Main.dust[index2].noGravity = true;
              Main.dust[index2].position = projectile.Center + vector2;
              Main.dust[index2].velocity = Main.dust[index2].velocity * 4f + projectile.velocity * 0.3f;
            }
			for (int index = 0; index < 1; ++index)
			{
				float SpeedX = (float) (-(double) projectile.velocity.X * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
				float SpeedY = (float) (-(double) projectile.velocity.Y * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
				Projectile.NewProjectile(projectile.position.X + SpeedX, projectile.position.Y + SpeedY, SpeedX, SpeedY, mod.ProjectileType("Homing_Life_Stealer_Alt"), 1, 0.0f, projectile.owner, 0.0f, 0.0f);
			}
		}
    }
}