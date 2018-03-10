using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.InfoA
{
	
	public class Info : GlobalProjectile
	{
		public bool Paradox = false;
		public bool Cosmodium = false;
		public bool Shroom = false;
		public bool Flamethrower = false;
		public bool Titanium = false;
		public bool Planetary = false;
		public bool Split = false;
		public bool wtf = false;
		public bool BlightedBow = false;
		public bool FrostCrystal = false;
		public bool Blight = false;
		public bool SnowSplit = false;
		public bool NotSummon = false;
		public bool Curse = false;
		public bool Water = false;
		public bool WaterKatana = false;
		public bool firedFromNeedler = false;
		
		public override bool InstancePerEntity {get{return true;}}
		
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (Flamethrower == true)
			{
				target.immune[projectile.owner] = 5;
			}
			
			if (Water && crit)
			{
				Vector2 Source = (Main.player[projectile.owner].Center);
				Vector2 vector2 = (projectile.DirectionFrom(Source) * 6f);
				int Damage2 = (int) ((double) projectile.damage * 1.5);
				Projectile.NewProjectile((float) Source.X, (float) Source.Y, (float) vector2.X, (float) vector2.Y, mod.ProjectileType("WaterBeam"), Damage2, 0.0f, projectile.owner, 0.0f, 0.0f);
			}
			
			if (Blight && crit)
			{
				Vector2 Source = (Main.player[projectile.owner].Center);
				Vector2 vector2 = (projectile.DirectionFrom(Source) * 6f);
				int Damage2 = (int) ((double) projectile.damage * 1.5);
				Projectile.NewProjectile((float) Source.X, (float) Source.Y, (float) vector2.X, (float) vector2.Y, mod.ProjectileType("BlightBeam"), Damage2, 0.0f, projectile.owner, 0.0f, 0.0f);
			}
			
			if (Curse == true && target.life < 1)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector2 = projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
					int proj = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, vector2.X, vector2.Y, projectile.type, projectile.damage, 5f, projectile.owner);
					Projectile memes = Main.projectile[proj];
					memes.magic = true;
					memes.melee = false;
					memes.GetGlobalProjectile<Info>(mod).Curse = true;
				}
				
				int num = Main.rand.Next(10, 21);
				for (int index = 0; index < num; ++index)
				{
					Vector2 vector2 = new Vector2((float) Main.rand.Next(-100, 101), (float) Main.rand.Next(-100, 101));
					vector2.Normalize();
					vector2 = (vector2 * (float) Main.rand.Next(10, 201) * 0.01f);
					Projectile.NewProjectile((float) projectile.Center.X, (float) projectile.Center.Y, (float) vector2.X, (float) vector2.Y, mod.ProjectileType("VileCloud1") + Main.rand.Next(3), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
				}
			}
			
			if (SnowSplit == true || FrostCrystal == true)
			{
				target.AddBuff(BuffID.Frostburn, 180);
			}
			
			if (Main.rand.Next(4) != 0 && Paradox == true)
			{
				int z = Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X * 100f, projectile.Center.Y + projectile.velocity.Y * 100f, projectile.velocity.X * -1, projectile.velocity.Y * -1, projectile.type, projectile.damage * 3 / 4, 0f, projectile.owner, 0f, 0f);
				Main.projectile[z].GetGlobalProjectile<Info>(mod).Paradox = true;
				Main.projectile[z].tileCollide = false;
				Main.projectile[z].penetrate = 1;
			}
			if (BlightedBow == true)
			{
				target.AddBuff(mod.BuffType("BlightFlame"), 360, false);
			}
			
			if (Main.rand.Next(2) == 0 && Planetary == true)
			{
				Player player = Main.player[projectile.owner];
				Vector2 newMove = projectile.Center - player.Center;
				float memes = newMove.X * 15f;
				float memes2 = newMove.Y * 15f;
				memes += (float)Main.rand.Next(-40, 41) * 0.1f;
				memes2 += (float)Main.rand.Next(-40, 41) * 0.1f;
				int z = Projectile.NewProjectile(player.Center.X, player.Center.Y, memes, memes2, projectile.type, projectile.damage, 0f, projectile.owner, 0f, 0f);
				if(Main.rand.Next(15) == 0)
				{
					Main.projectile[z].GetGlobalProjectile<Info>(mod).Planetary = true;
				}
			}

			if (firedFromNeedler && Main.rand.Next(3) == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					Player player = Main.player[projectile.owner];
					Vector2 distance = Vector2.Subtract(target.Center, player.Center);
					double angle = Math.Atan2(distance.Y, distance.X);
					Vector2 velocity = new Vector2(10, 0).RotatedBy(angle);
					velocity.X += (float) Main.rand.Next(-60, 61) * 0.03f;
					velocity.Y += (float) Main.rand.Next(-60, 61) * 0.03f;
					Projectile.NewProjectile(player.Center.X, player.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("laserbeamNeedle"), projectile.damage / 3, projectile.knockBack / 2, projectile.owner);
				}
			}
		}
		
		public override void Kill(Projectile projectile, int timeLeft)
		{
			
			if (Split == true && projectile.timeLeft == 0)
			{
				Vector2 origVect = new Vector2(projectile.velocity.X, projectile.velocity.Y);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 30);
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / 30);
				Vector2 newVect4 = origVect.RotatedBy(-System.Math.PI / 60);
				Vector2 newVect5 = origVect.RotatedBy(System.Math.PI / 60);
				int ok1 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, origVect.X, origVect.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok2 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect2.X, newVect2.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok3 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect3.X, newVect3.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok4 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect4.X, newVect4.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok5 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect5.X, newVect5.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				Main.projectile[ok1].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok2].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok3].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok4].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok5].GetGlobalProjectile<Info>(mod).wtf = true;
			}
			
			if (SnowSplit == true)
			{
				Vector2 origVect = new Vector2(-projectile.velocity.X / 2, -projectile.velocity.Y / 2);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / Main.rand.Next(30));
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / Main.rand.Next(30));
				if (Main.rand.Next(2) == 0)
				{
					int ok1 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, origVect.X, origVect.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				}
				int ok2 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect2.X, newVect2.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok3 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect3.X, newVect3.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
			}
			
			if (Cosmodium == true)
			{
				int amountOfProjectiles = Main.rand.Next(2, 4);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					int B = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("CosmodiumBolt2"), projectile.damage, 5f, projectile.owner);
					Main.projectile[B].magic = false;
					Main.projectile[B].ranged = true;
				}
			}
			
			if (Titanium == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 4);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 126, 15, 5f, projectile.owner);
				}
			}

			if (Shroom == true)
			{
				for (int i = 0; i < 3; ++i)
				{
					float sX = (float)Main.rand.Next(-30, 31) * 0.2f;
					float sY = (float)Main.rand.Next(-30, 31) * 0.2f;
					int B = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("ShroomCloud"), projectile.damage, 5f, projectile.owner);
					Main.projectile[B].magic = false;
					Main.projectile[B].ranged = true;
				}
			}
		}
		
		public override void AI(Projectile projectile)
		{
			if (NotSummon == true)
			{
				ProjectileID.Sets.MinionShot[projectile.type] = false;
				ProjectileID.Sets.SentryShot[projectile.type] = false;
			}
			
			if (BlightedBow == true)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center, 0, 0, 173, 0f, 0f); 
				Main.dust[dust].scale = 1.2f;
				Main.dust[dust].noGravity = true;
			}
			
			if (wtf == true && projectile.velocity.X == 0 && projectile.velocity.Y == 0)
			{
				projectile.Kill();
			}
		}
	}
}
