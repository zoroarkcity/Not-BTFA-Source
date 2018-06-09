using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.GhastlyEnt.Boss.Projectiles
{
    public class Cursed_Flame_Eruption : ModProjectile
    {
 
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 1;
            projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
			projectile.hostile = true;
            projectile.penetrate = -1;
			projectile.hide = true;
			projectile.alpha = 256;
			projectile.scale = 1f;
            projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonfury Eruption");
        } 
		
	public override void AI()
	{
        int num1 = Math.Sign(projectile.velocity.Y);
        int num2 = num1 == -1 ? 0 : 1;
		int Type = Utils.SelectRandom<int>(Main.rand, new int[3]
        {
            75,
            163,
            61
        });
        if ((double) projectile.ai[0] == 0.0)
        {
			if (!Collision.SolidCollision(projectile.position + new Vector2(0.0f, num1 == -1 ? (float) (projectile.height - 48) : 0.0f), projectile.width, 48) && !Collision.WetCollision(projectile.position + new Vector2(0.0f, num1 == -1 ? (float) (projectile.height - 20) : 0.0f), projectile.width, 20))
			{
				projectile.velocity = new Vector2(0.0f, (float) Math.Sign(projectile.velocity.Y) * (1f / 1000f));
				projectile.ai[0] = 1f;
				projectile.ai[1] = 0.0f;
				projectile.timeLeft = 60;
			}
			++projectile.ai[1];
			if ((double) projectile.ai[1] >= 60.0)
				projectile.Kill();
			for (int index1 = 0; index1 < 3; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1f);
				Main.dust[index2].scale = (float) (0.100000001490116 + (double) Main.rand.Next(5) * 0.100000001490116);
				Main.dust[index2].fadeIn = (float) (1.5 + (double) Main.rand.Next(5) * 0.100000001490116);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].position = projectile.Center + new Vector2(0.0f, (float) (-projectile.height / 2)).RotatedBy((double) projectile.rotation, new Vector2()) * 1.1f;
			}
        }
        if ((double) projectile.ai[0] != 1.0)
          return;
        projectile.velocity = new Vector2(0.0f, (float) Math.Sign(projectile.velocity.Y) * (1f / 1000f));
        if (num1 != 0)
        {
			int num3 = 16;
			int num4 = 320;
			while (num3 < num4 && !Collision.SolidCollision(projectile.position + new Vector2(0.0f, num1 == -1 ? (float) (projectile.height - num3 - 16) : 0.0f), projectile.width, num3 + 16))
				num3 += 16;
			if (num1 == -1)
			{
				projectile.position.Y += (float) projectile.height;
				projectile.height = num3;
				projectile.position.Y -= (float) num3;
			}
			else
				projectile.height = num3;
		}
			++projectile.ai[1];
        if ((double) projectile.ai[1] >= 60.0)
          projectile.Kill();
        if ((double) projectile.localAI[0] == 0.0)
        {
			projectile.localAI[0] = 1f;
			for (int index1 = 0; (double) index1 < 60.0; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, Type, 0.0f, -2.5f * (float) -num1, 0, new Color(), 1f);
				Main.dust[index2].alpha = 200;
				Main.dust[index2].velocity *= new Vector2(0.3f, 2f);
				Main.dust[index2].velocity.Y += (float) (2 * num1);
				Main.dust[index2].scale += Main.rand.NextFloat();
				Main.dust[index2].position = new Vector2(projectile.Center.X, projectile.Center.Y + (float) projectile.height * 0.5f * (float) -num1);
				Main.dust[index2].customData = (object) num2;
				if (num1 == -1 && Main.rand.Next(4) != 0)
					Main.dust[index2].velocity.Y -= 0.2f;
			}
			Main.PlaySound(SoundID.Item34, projectile.position);
        }
        if (num1 == 1)
        {
			for (int index1 = 0; (double) index1 < 9.0; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, Type, 0.0f, -2.5f * (float) -num1, 0, new Color(), 1f);
				Main.dust[index2].alpha = 200;
				Main.dust[index2].velocity *= new Vector2(0.3f, 2f);
				Main.dust[index2].velocity.Y += (float) (2 * num1);
				Main.dust[index2].scale += Main.rand.NextFloat();
				Main.dust[index2].position = new Vector2(projectile.Center.X, projectile.Center.Y + (float) projectile.height * 0.5f * (float) -num1);
				Main.dust[index2].customData = (object) num2;
				if (num1 == -1 && Main.rand.Next(4) != 0)
					Main.dust[index2].velocity.Y -= 0.2f;
			}
        }
        int Height = (int) ((double) projectile.ai[1] / 60.0 * (double) projectile.height) * 3;
        if (Height > projectile.height)
			Height = projectile.height;
        Vector2 Position = projectile.position + (num1 == -1 ? new Vector2(0.0f, (float) (projectile.height - Height)) : Vector2.Zero);
        Vector2 vector2 = projectile.position + (num1 == -1 ? new Vector2(0.0f, (float) projectile.height) : Vector2.Zero);
        for (int index1 = 0; (double) index1 < 6.0; ++index1)
        {
			if (Main.rand.Next(3) < 2)
			{
				int index2 = Dust.NewDust(Position, projectile.width, Height, Type, 0.0f, 0.0f, 90, new Color(), 2.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].fadeIn = 1f;
				if ((double) Main.dust[index2].velocity.Y > 0.0)
					Main.dust[index2].velocity.Y *= -1f;
				if (Main.rand.Next(6) < 3)
				{
					Main.dust[index2].position.Y = MathHelper.Lerp(Main.dust[index2].position.Y, vector2.Y, 0.5f);
					Main.dust[index2].velocity *= 5f;
					Main.dust[index2].velocity.Y -= 3f;
					Main.dust[index2].position.X = projectile.Center.X;
					Main.dust[index2].noGravity = false;
					Main.dust[index2].noLight = true;
					Main.dust[index2].fadeIn = 0.4f;
					Main.dust[index2].scale *= 0.3f;
				}
				else
					Main.dust[index2].velocity = projectile.DirectionFrom(Main.dust[index2].position) * Main.dust[index2].velocity.Length() * 0.25f;
					Main.dust[index2].velocity.Y *= (float) -num1;
					Main.dust[index2].customData = (object) num2;
			}
        }
        for (int index1 = 0; (double) index1 < 6.0; ++index1)
        {
			if ((double) Main.rand.NextFloat() >= 0.5)
			{
				int index2 = Dust.NewDust(Position, projectile.width, Height, Type, 0.0f, -2.5f * (float) -num1, 0, new Color(), 1f);
				Main.dust[index2].alpha = 200;
				Main.dust[index2].velocity *= new Vector2(0.6f, 1.5f);
				Main.dust[index2].scale += Main.rand.NextFloat();
				if (num1 == -1 && Main.rand.Next(4) != 0)
					Main.dust[index2].velocity.Y -= 0.2f;
				Main.dust[index2].customData = (object) num2;
			}
        }
    }
		
		public override void Kill(int timeLeft)
        {
		}
    }
}