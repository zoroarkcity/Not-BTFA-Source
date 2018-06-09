using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.GhastlyEnt.Boss.Projectiles
{
    public class Projectile_Portal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Portal");
        } 
        public override void SetDefaults()
        {
            projectile.width = 228;
            projectile.height = 228;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {    
			Player player = Main.LocalPlayer;
			projectile.rotation += 0.05f;
			if (projectile.timeLeft == 100 || projectile.timeLeft == 50)
			{
				Vector2 vector8 = new Vector2(projectile.position.X + (projectile.width / 2), projectile.position.Y + (projectile.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * 10f) * -1), (float)((Math.Sin(rotation) * 10f) * -1), mod.ProjectileType("Homing_Life_Stealer"), 20, 0f, 0);
			}
		}
		public override void Kill(int timeLeft)
        {
			Player player = Main.LocalPlayer;
			bool flag = WorldGen.SolidTile(Framing.GetTileSafely((int) projectile.position.X / 16, (int) projectile.position.Y / 16));
			for (int index = 0; index < 4; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 163, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 4; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 163, 0.0f, 0.0f, 0, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  if (flag)
				Main.dust[index2].noLight = true;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 163, 0.0f, 0.0f, 100, new Color(), 1.5f);
			  Main.dust[index3].velocity *= 2f;
			  Main.dust[index3].noGravity = true;
			  if (flag)
				Main.dust[index3].noLight = true;
			}
			Vector2 perturbedSpeed = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(60));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Cursed_Fireball"), 20, 2f, 0);
			Vector2 perturbedSpeed2 = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(120));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, mod.ProjectileType("Cursed_Fireball"), 20, 2f, 0);
			Vector2 perturbedSpeed3 = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(180));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, mod.ProjectileType("Cursed_Fireball"), 20, 2f, 0);
			Vector2 perturbedSpeed4 = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(240));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed4.X, perturbedSpeed4.Y, mod.ProjectileType("Cursed_Fireball"), 20, 2f, 0);
			Vector2 perturbedSpeed5 = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(300));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed5.X, perturbedSpeed5.Y, mod.ProjectileType("Cursed_Fireball"), 20, 2f, 0);
			Vector2 perturbedSpeed6 = new Vector2(10f, 10f).RotatedBy(MathHelper.ToRadians(360));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed6.X, perturbedSpeed6.Y, mod.ProjectileType("Cursed_Fireball"), 20, 2f, 0);
        }
    }
}