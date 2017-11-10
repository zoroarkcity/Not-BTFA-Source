using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
    public class BloodSlime : ModProjectile
	{
		int TrailCounter = 0;
    	public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(ProjectileID.BabySlime);
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.aiStyle = 26;
			aiType = 266;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Blood");
			Main.projFrames[projectile.type] = 6;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			if (player.dead)
			{
				modPlayer.BloodSlime = false;
			}
			if (modPlayer.BloodSlime)
			{
				projectile.timeLeft = 2;
			}
			
			TrailCounter++;
			if (TrailCounter >= 15)
			{
				Vector2 velVect = new Vector2(projectile.velocity.X / 2, projectile.velocity.Y / 2);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-25, 25)));
				
				int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velVect2.X, velVect2.Y, mod.ProjectileType("BloodTrail"), projectile.damage, projectile.knockBack, projectile.owner);
				ProjectileID.Sets.MinionShot[Main.projectile[p].type] = true;
				TrailCounter = 0;
			}
			
			Lighting.AddLight(projectile.Center, 0.5f, 0.2f, 0f);
		}
    }
}
