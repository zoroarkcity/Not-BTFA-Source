using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class FireDevil : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = (int) sbyte.MaxValue;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			//projectile.timeLeft = 60;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Whirl");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 240, false);
			++projectile.localAI[0];
		}

        public override void AI()
        {
			float num1 = 140f;
			if (projectile.soundDelay == 0)
			{
				projectile.soundDelay = -1;
				Main.PlaySound(SoundID.Item82, projectile.Center);
			}
			projectile.ai[0] += 1f;
			if ((double) projectile.ai[0] >= (double) num1)
				projectile.Kill();
			if (projectile.localAI[0] >= 30.0)
			{
				projectile.damage = 0;
				if ((double) projectile.ai[0] < (double) num1 - 120.0)
				{
					float num2 = projectile.ai[0] % 60f;
					projectile.ai[0] = num1 - 120f + num2;
					projectile.netUpdate = true;
				}
			}
			float num3 = 15f;
			float num4 = 15f;
			Point tileCoordinates = projectile.Center.ToTileCoordinates();
			int topY;
			int bottomY;
			Collision.ExpandVertically((int) tileCoordinates.X, (int) tileCoordinates.Y, out topY, out bottomY, (int) num3, (int) num4);
			++topY;
			int num5 = bottomY - 1;
			Vector2 vector2_1 = ((new Vector2((float) tileCoordinates.X , (float) topY) * 16f) + new Vector2(8f, 8f));
			Vector2 vector2_2 = ((new Vector2((float) tileCoordinates.X, (float) num5) * 16f) + new Vector2(8f, 8f));
			Vector2 vector2_3 = Vector2.Lerp(vector2_1, vector2_2, 0.5f);
			Vector2 vector2_4 = new Vector2(0f, vector2_2.Y - vector2_1.Y);
			vector2_4.X = (vector2_4.Y * 0.200000002980232f);
			projectile.width = (int) (vector2_4.X * 0.649999976158142);
			projectile.height = (int) vector2_4.Y;
			projectile.Center = vector2_3;
			if (projectile.owner == Main.myPlayer)
			{
				bool flag = false;
				Vector2 center = Main.player[projectile.owner].Center;
				Vector2 top = Main.player[projectile.owner].Top;
				float num2 = 0.0f;
				while ((double) num2 < 1.0)
				{
					Vector2 Position1 = Vector2.Lerp(vector2_1, vector2_2, num2);
					if (Collision.CanHitLine(Position1, 0, 0, center, 0, 0) || Collision.CanHitLine(Position1, 0, 0, top, 0, 0))
					{
						flag = true;
						break;
					}
					num2 += 0.05f;
				}
				if (!flag && (double) projectile.ai[0] < (double) num1 - 120.0)
				{
					float num6 = projectile.ai[0] % 60f;
					projectile.ai[0] = num1 - 120f + num6;
					projectile.netUpdate = true;
				}
			}
			if ((double) projectile.ai[0] >= (double) num1 - 120.0)
				return;
			if (projectile.ai[0] <= 80)
			{
				for (int index = 0; index < 1; ++index)
				{
					float num2 = -0.5f;
					float num6 = 0.9f;
					float num7 = Main.rand.NextFloat();
					Vector2 vector2_5 = new Vector2(MathHelper.Lerp(0.1f, 1f, Main.rand.NextFloat()), MathHelper.Lerp(num2, num6, num7));
					vector2_5.X = vector2_5.X * MathHelper.Lerp(2.2f, 0.6f, num7);
					vector2_5.X = vector2_5.X * -1f;
					Vector2 vector2_6 = new Vector2(6f, 10f);
					Vector2 Position = ((vector2_3 + ((vector2_4 * vector2_5) * 0.5f)) + vector2_6);
					Dust dust = Main.dust[Dust.NewDust(Position, 0, 0, 6, 0.0f, 0.0f, 0, new Color(), 1f)];
					dust.position = Position;
					dust.customData = (object) (vector2_3 + vector2_6);
					dust.fadeIn = 1f;
					dust.noGravity = true;
					dust.scale = 0.3f;
					if (vector2_5.X > -1.20000004768372)
						dust.velocity.X =  (1f + Main.rand.NextFloat());
					dust.velocity.Y = (float)((double) Main.rand.NextFloat() * -0.5 - 1.0);
				}
			}
        }
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			float num3 = 140f;
			float num4 = 15f;
			float num5 = 15f;
			float num6 = projectile.ai[0];
			float num7 = MathHelper.Clamp(num6 / 30f, 0.0f, 1f);
			if ((double) num6 > (double) num3 - 60.0)
				num7 = MathHelper.Lerp(1f, 0.0f, (float) (((double) num6 - ((double) num3 - 60.0)) / 60.0));
			Point tileCoordinates = projectile.Center.ToTileCoordinates();
			int topY;
			int bottomY;
			Collision.ExpandVertically((int) tileCoordinates.X, (int) tileCoordinates.Y, out topY, out bottomY, (int) num4, (int) num5);
			int num8 = topY + 1;
			--bottomY;
			float num9 = 0.2f;
			Vector2 vector2_1 = ((new Vector2((float) tileCoordinates.X, (float) num8) * 16f) + new Vector2(8f));
			Vector2 vector2_2 = ((new Vector2((float) tileCoordinates.X, (float) bottomY) * 16f) + new Vector2(8f));
			Vector2.Lerp(vector2_1, vector2_2, 0.5f);
			Vector2 vector2_3 = new Vector2(0f, vector2_2.Y - vector2_1.Y);
			vector2_3.X = (vector2_3.Y * num9);
			Vector2 vector2_4 = new Vector2((float) (vector2_1.X - vector2_3.X / 2.0), (float) vector2_1.Y);
			Texture2D tex = Main.projectileTexture[projectile.type];
			Microsoft.Xna.Framework.Rectangle r = tex.Frame(1, 1, 0, 0);
			Vector2 vector2_5 = (r.Size() / 2f);
			float num10 = -0.06283186f * num6;
			Vector2 spinningpoint = Vector2.UnitY.RotatedBy((double) num6 * 0.100000001490116);
			float num11 = 0.0f;
			float num12 = 5.1f;
			Microsoft.Xna.Framework.Color color2 = new Color(255, 135, 56);
			float y = (float) (int) vector2_2.Y;
			while ((double) y > (double) (int) vector2_1.Y)
			{
				num11 += num12;
				float num13 = num11 / (float) vector2_3.Y;
				float num14 = (float) ((double) num11 * 6.28318548202515 / -20.0);
				float num15 = num13 - 0.15f;
				Vector2 vector2_6 = spinningpoint.RotatedBy((double) num14);
				Vector2 vector2_7 = new Vector2(0.0f, num13 + 1f);
				vector2_7.X = (vector2_7.Y * num9);
				Microsoft.Xna.Framework.Color color3 = Microsoft.Xna.Framework.Color.Lerp(Microsoft.Xna.Framework.Color.Transparent, color2, num13 * 2f);
				if ((double) num13 > 0.5)
					color3 = Microsoft.Xna.Framework.Color.Lerp(Microsoft.Xna.Framework.Color.Transparent, color2, (float) (2.0 - (double) num13 * 2.0));
				color3.A *= (byte)0.5f;
				color3 = (color3 * num7);
				vector2_6 = (vector2_6 * (vector2_7 * 100f));
				vector2_6.Y = 0;
				vector2_6.X = 0;
				vector2_6 = (vector2_6 + (new Vector2((float) vector2_2.X, y) - Main.screenPosition));
				Main.spriteBatch.Draw(tex, vector2_6, new Microsoft.Xna.Framework.Rectangle?(r), color3, num10 + num14, vector2_5, 1f + num15, (SpriteEffects) 0, 0.0f);
				y -= num12;
			}
			return false;
		}
    }       
}
