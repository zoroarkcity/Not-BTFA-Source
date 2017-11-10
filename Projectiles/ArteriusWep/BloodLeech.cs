using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class BloodLeech : ModProjectile
	{
		int index1 = 999;
		public override void SetDefaults()
		{
			projectile.width = 15;
			projectile.height = 23;
			//projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.thrown = true;
			projectile.timeLeft = 360;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Leech");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(4) == 0 && projectile.noDropItem == false)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BloodLeech"));
        	}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); //create a sound
		}
		
		public override void AI()
		{
			int num1 = 25;
			if ((double) projectile.ai[0] == 0.0)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] >= 45f)
				{
					float num984 = 0.98f;
					float num985 = 0.35f;
					if (projectile.type == 636)
					{
						num984 = 0.995f;
						num985 = 0.15f;
					}
					projectile.ai[1] = 45f;
					projectile.velocity.X = projectile.velocity.X * num984;
					projectile.velocity.Y = projectile.velocity.Y + num985;
				}
				projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
			}
			
			if ((double) projectile.ai[0] == 1.0)
			{
				projectile.ignoreWater = true;
				projectile.tileCollide = false;
				int num2 = 15;
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
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BloodLeech"), 900, false);
			
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
			int length = 7;
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