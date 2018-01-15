using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
	public class SoulFountain : ModProjectile
	{
		public int upwards = 0;
		public static int projectileSpawnerTimer = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Fountain");
        }
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = -1;
			projectile.aiStyle = 0;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.scale = 1f;
			Main.projFrames[projectile.type] = 3;
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {         	
			projectile.frameCounter++;
			
			if (Main.rand.Next(10) == 0)
			{
				for (int index2 = 0; index2 < 1; ++index2)
				{
					float x = projectile.position.X;
					float y = projectile.position.Y;
					int index3 = Dust.NewDust(new Vector2(x, y), 1, 1, 20, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index3].alpha = projectile.alpha;
					Main.dust[index3].position.X = x;
					Main.dust[index3].position.Y = y;
					Main.dust[index3].scale = 2f;
					Main.dust[index3].velocity *= 10f;
					Main.dust[index3].noGravity = true;
				}
			}
			
			if (projectile.frameCounter > 8)
			{
			   projectile.frame++;
               projectile.frameCounter = 1;
			}
            if (projectile.frame > 2)
            {
               projectile.frame = 0;
            }
			
			projectile.velocity.X = 0f;
			
			Player player = Main.player[projectile.owner];
			
			upwards++;
			projectileSpawnerTimer++;

			if (Items.ItemSets.Acheron.Styx.switcher == 1)
			{
				Lighting.AddLight(projectile.position, 0.150f, 0.250f, 0.250f);	
				projectile.damage = 80;
				player.armorPenetration = 12;
				if (upwards <= 80)
				{
					projectile.position.Y = projectile.position.Y - 0.25f;
				}
				if (upwards > 81 && upwards < 160)
				{
					projectile.position.Y = projectile.position.Y + 0.25f;
				}
				if (upwards == 160)
				{
					upwards = 0;
				}
				
				if (projectileSpawnerTimer >= 270)
				{
					projectileSpawnerTimer = 0;
					Projectile.NewProjectile(projectile.Center.X - Main.rand.Next(-80, 80), projectile.Center.Y - Main.rand.Next(-80, 80), 0f, 0f, mod.ProjectileType("SoulFountainAlt"), 200, 3f, projectile.owner);
				}
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 2)
			{
				Lighting.AddLight(projectile.position, 0.200f, 0.300f, 0.300f);	
				projectile.damage = 65;
				player.armorPenetration = 8;
				if (upwards <= 80)
				{
					projectile.position.Y = projectile.position.Y - 0.5f;
				}
				if (upwards > 81 && upwards < 160)
				{
					projectile.position.Y = projectile.position.Y + 0.5f;
				}
				if (upwards == 160)
				{
					upwards = 0;
				}
				
				if (projectileSpawnerTimer >= 90)
				{
					projectileSpawnerTimer = 0;
					Projectile.NewProjectile(projectile.Center.X - Main.rand.Next(-80, 80), projectile.Center.Y - Main.rand.Next(-80, 80), 0f, 0f, mod.ProjectileType("SoulFountainAlt"), 150, 3f, projectile.owner);
				}
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 3)
			{
				Lighting.AddLight(projectile.position, 0.250f, 0.350f, 0.350f);	
				projectile.damage = 40;
				player.armorPenetration = 4;
				if (upwards <= 80)
				{
					projectile.position.Y = projectile.position.Y - 0.75f;
				}
				if (upwards > 81 && upwards < 160)
				{
					projectile.position.Y = projectile.position.Y + 0.75f;
				}
				if (upwards == 160)
				{
					upwards = 0;
				}
				
				if (projectileSpawnerTimer >= 30)
				{
					projectileSpawnerTimer = 0;
					Projectile.NewProjectile(projectile.Center.X - Main.rand.Next(-80, 80), projectile.Center.Y - Main.rand.Next(-80, 80), 0f, 0f, mod.ProjectileType("SoulFountainAlt"), 100, 3f, projectile.owner);
				}
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 4)
			{
				Lighting.AddLight(projectile.position, 0.300f, 0.400f, 0.400f);	
				projectile.damage = 25;
				player.armorPenetration = 0;
				if (upwards <= 80)
				{
					projectile.position.Y = projectile.position.Y - 1f;
				}
				if (upwards > 81 && upwards < 160)
				{
					projectile.position.Y = projectile.position.Y + 1f;
				}
				if (upwards == 160)
				{
					upwards = 0;
				}
				
				if (projectileSpawnerTimer >= 10)
				{
					projectileSpawnerTimer = 0;
					Projectile.NewProjectile(projectile.Center.X - Main.rand.Next(-80, 80), projectile.Center.Y - Main.rand.Next(-80, 80), 0f, 0f, mod.ProjectileType("SoulFountainAlt"), 50, 3f, projectile.owner);
				}
			}				
			if (Main.LocalPlayer.FindBuffIndex(mod.BuffType("styxPlaceHolderBuff")) > -1)
			{
				projectile.active = false;
				upwards = 0;
				projectileSpawnerTimer = 0;
			}
        }
		public override void Kill(int timeLeft)
		{
			int index4 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
			Main.gore[index4].velocity *= 0.4f;
			Main.gore[index4].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
			Main.gore[index4].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
			int index5 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
			Main.gore[index5].velocity *= 0.4f;
			Main.gore[index5].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
			Main.gore[index5].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
			if (projectile.owner == Main.myPlayer)
			{
				projectile.penetrate = -1;
				projectile.position.X += (float) (projectile.width / 2);
				projectile.position.Y += (float) (projectile.height / 2);
				projectile.width = 64;
				projectile.height = 64;
				projectile.position.X -= (float) (projectile.width / 2);
				projectile.position.Y -= (float) (projectile.height / 2);
			}
		}
    }
}
