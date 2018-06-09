using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.GhastlyEnt.Boss.Projectiles
{
    public class Teleportation_Rift : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teleportation Portal");
        } 
        public override void SetDefaults()
        {
            projectile.width = 374;
            projectile.height = 378;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {    
			projectile.rotation += 0.05f;
			if (projectile.timeLeft == 100)
			{
				Vector2 perturbedSpeed = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(60));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Homing_Life_Stealer"), 20, 2f, 0);
			}
			if (projectile.timeLeft == 80)
			{
				Vector2 perturbedSpeed = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(120));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Homing_Life_Stealer"), 20, 2f, 0);
			}
			if (projectile.timeLeft == 60)
			{
				Vector2 perturbedSpeed = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(180));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Homing_Life_Stealer"), 20, 2f, 0);
			}
			if (projectile.timeLeft == 40)
			{
				Vector2 perturbedSpeed = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(240));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Homing_Life_Stealer"), 20, 2f, 0);
			}
			if (projectile.timeLeft == 20)
			{
				Vector2 perturbedSpeed = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(300));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Homing_Life_Stealer"), 20, 2f, 0);
			}
			if (projectile.timeLeft == 1)
			{
				Vector2 perturbedSpeed = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(360));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Homing_Life_Stealer"), 20, 2f, 0);
			}
		}
    }
}