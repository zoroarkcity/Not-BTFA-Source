using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Filicid
{
	public class FilicidCellRange : ModProjectile
	{
		int index1 = 999;
		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 5;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 360;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Filicid Cell");
		}
		
		public override void AI()
		{
			int num1 = 63;
			if ((double) projectile.ai[0] == 0.0)
			{
				int index = (int) projectile.ai[1];
				if (!Main.npc[index].CanBeChasedBy((object) projectile, true))
				{
					projectile.Kill();
					return;
				}
				double rotation = (double) projectile.velocity.ToRotation();
				Vector2 vector2 = Main.npc[index].Center - projectile.Center;
				if (vector2 != Vector2.Zero)
				{
					vector2.Normalize();
					vector2 *= 14f;
				}
				float num2 = 5f;
				projectile.velocity = (projectile.velocity * (num2 - 1f) + vector2) / num2;
			}
			
			if ((double) projectile.ai[0] == 1.0)
			{
				projectile.ignoreWater = true;
				projectile.tileCollide = false;
				int num2 = 15;
				if (projectile.type == 636)
					num2 = 5 * projectile.MaxUpdates;
				bool flag1 = false;
				bool flag2 = false;
				++projectile.localAI[0];
				if ((double) projectile.localAI[0] % 30.0 == 0.0)
					flag2 = true;
				int index = (int) projectile.ai[1];
				if ((double) projectile.localAI[0] >= (double) (60 * num2))
					flag1 = true;
				else if (index < 0 || index >= 200)
					flag1 = true;
				else if (Main.npc[index].active && !Main.npc[index].dontTakeDamage)
				{
					projectile.Center = Main.npc[index].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[index].gfxOffY;
					if (flag2)
						Main.npc[index].HitEffect(0, 1.0);
				}
				else
					flag1 = true;
				if (flag1)
					projectile.Kill();
			}
			Lighting.AddLight(projectile.Center, 0.5f, 0.0f, 0f);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("FilicidCell"), 900, false);
			
			projectile.ai[0] = 1f;
			for (int i = 0; i <= 200; i++)
			{
				if (Main.npc[i] == target)
				{
					index1 = i;
					projectile.ai[1] = (float) index1;
				}
			}
			projectile.velocity = (target.Center - projectile.Center) * 0.75f;
			projectile.netUpdate = true;
			
			projectile.damage = 0;
			int length = 10;
			Point[] pointArray = new Point[length];
			int num2 = 0;
			for (int x = 0; x < 1000; ++x)
			{
				if (x != projectile.whoAmI && Main.projectile[x].active && (Main.projectile[x].owner == Main.myPlayer && Main.projectile[x].type == projectile.type) && ((double) Main.projectile[x].ai[0] == 1.0 && (double) Main.projectile[x].ai[1] == (double) index1))
				{
					pointArray[num2++] = new Point(x, Main.projectile[x].timeLeft);
					if (num2 >= pointArray.Length)
						break;
				}
			}
			if (num2 >= pointArray.Length)
			{
				int index2 = 0;
				for (int index3 = 1; index3 < pointArray.Length; ++index3)
				{
					if (pointArray[index3].Y < pointArray[index2].Y)
						index2 = index3;
				}
				Main.projectile[pointArray[index2].X].Kill();
			}
		}
	}
}