using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
    public class HomingThanatosPre : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homing Thanatos");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;  //Set the hitbox width
            projectile.height = 4;  //Set the hitbox height
            projectile.aiStyle = 0; //How the projectile works
            projectile.tileCollide = true; //Tells the game whether it is hostile to players or not
            projectile.melee = true;   //Tells the game whether it is a ranged projectile or not
            projectile.timeLeft = 1; //The amount of time the projectile is alive for
			projectile.scale = 0f;
			ProjectileID.Sets.Homing[projectile.type] = true;
        }
		public override void Kill(int timeLeft)
		{
			for (int index = 0; index < 1; ++index)
            {
                float SpeedX = (float) (-(double) projectile.velocity.X * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
                float SpeedY = (float) (-(double) projectile.velocity.Y * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
                Projectile.NewProjectile(projectile.position.X + SpeedX, projectile.position.Y + SpeedY, SpeedX, SpeedY, mod.ProjectileType("HomingThanatos"), (int) ((double) projectile.damage), 0.0f, projectile.owner, 0.0f, 0.0f);
            }
		}
    }
}