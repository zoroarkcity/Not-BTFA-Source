using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Projectiles.Magnoliac
{
    public class DandelionStaffProj : ModProjectile
    {
		int amountofBounces = 10000;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DandelionStaffProj");
        } 
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.aiStyle = 1;
			projectile.extraUpdates = 1;
            projectile.magic = true;
			projectile.penetrate = 3;
			projectile.damage = 10;
			projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;	
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 360, false);
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}
		public bool isStickingToTarget
		{
			get { return projectile.ai[0] == 1f; }
			set { projectile.ai[0] = value ? 1f : 0f; }
		}
		public float targetWhoAmI
		{
			get { return projectile.ai[1]; }
			set { projectile.ai[1] = value; }
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit,
			ref int hitDirection)
		{
			// If you'd use the example above, you'd do: isStickingToTarget = 1f;
			// and: targetWhoAmI = (float)target.whoAmI;
			isStickingToTarget = true; // we are sticking to a target
			targetWhoAmI = (float)target.whoAmI; // Set the target whoAmI
			projectile.velocity =
				(target.Center - projectile.Center) *
				0.75f; // Change velocity based on delta center of targets (difference between entity centers)
			projectile.netUpdate = true; // netUpdate this javelin
			target.AddBuff(169, 900); // Adds the Penetrated debuff, a very small DoT

			projectile.damage = 0; // Makes sure the sticking javelins do not deal damage anymore

			// The following code handles the javelin sticking to the enemy hit.
			int maxStickingJavelins = 6; // This is the max. amount of javelins being able to attach
			Point[] stickingJavelins = new Point[maxStickingJavelins]; // The point array holding for sticking javelins
			int javelinIndex = 0; // The javelin index
			for (int i = 0; i < Main.maxProjectiles; i++) // Loop all projectiles
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI // Make sure the looped projectile is not the current javelin
				    && currentProjectile.active // Make sure the projectile is active
				    && currentProjectile.owner == Main.myPlayer // Make sure the projectile's owner is the client's player
				    && currentProjectile.type == projectile.type // Make sure the projectile is of the same type as this javelin
				    && currentProjectile.ai[0] == 1f // Make sure ai0 state is set to 1f (set earlier in ModifyHitNPC)
				    && currentProjectile.ai[1] == (float)target.whoAmI
				) // Make sure ai1 is set to the target whoAmI (set earlier in ModifyHitNPC)
				{
					stickingJavelins[javelinIndex++] =
						new Point(i, currentProjectile.timeLeft); // Add the current projectile's index and timeleft to the point array
					if (javelinIndex >= stickingJavelins.Length
					) // If the javelin's index is bigger than or equal to the point array's length, break
					{
						break;
					}
				}
			}
			// Here we loop the other javelins if new javelin needs to take an older javelin's place.
			if (javelinIndex >= stickingJavelins.Length)
			{
				int oldJavelinIndex = 0;
				// Loop our point array
				for (int i = 1; i < stickingJavelins.Length; i++)
				{
					// Remove the already existing javelin if it's timeLeft value (which is the Y value in our point array) is smaller than the new javelin's timeLeft
					if (stickingJavelins[i].Y < stickingJavelins[oldJavelinIndex].Y)
					{
						oldJavelinIndex = i; // Remember the index of the removed javelin
					}
				}
				// Remember that the X value in our point array was equal to the index of that javelin, so it's used here to kill it.
				Main.projectile[stickingJavelins[oldJavelinIndex].X].Kill();
			}
		}
        public override void AI()
        {    
		    if (Main.rand.Next(3) == 0)
            {
                int index = Dust.NewDust(projectile.Center, 8, 8, 159, 0.0f, 0.0f, 0, new Color(), 1f);
                Main.dust[index].position = projectile.Center;
                Main.dust[index].velocity *= 0.2f;
                Main.dust[index].noGravity = true;
                Main.dust[index].scale = 2f;
            }
			if (isStickingToTarget)
			{
				projectile.ignoreWater = true; // Make sure the projectile ignores water
				projectile.tileCollide = false; // Make sure the projectile doesn't collide with tiles anymore
				int aiFactor = 15; // Change this factor to change the 'lifetime' of this sticking javelin
				bool killProj = false; // if true, kill projectile at the end
				bool hitEffect = false; // if true, perform a hit effect
				projectile.localAI[0] += 1f;
				// Every 30 ticks, the javelin will perform a hit effect
				hitEffect = projectile.localAI[0] % 30f == 0f;
				int projTargetIndex = (int)targetWhoAmI;
				if (projectile.localAI[0] >= (float)(60 * aiFactor)// If it's time for this javelin to die, kill it
				    || (projTargetIndex < 0 || projTargetIndex >= 200)) // If the index is past its limits, kill it
				{
					killProj = true;
				}
				else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) // If the target is active and can take damage
				{
					// Set the projectile's position relative to the target's center
					projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
					if (hitEffect) // Perform a hit effect here
					{
						Main.npc[projTargetIndex].HitEffect(0, 1.0);
					}
				}
				else // Otherwise, kill the projectile
				{
					killProj = true;
				}

				if (killProj) // Kill the projectile
				{
					projectile.Kill();
				}
			}
		}
		public override void Kill(int timeLeft)
        {
            for(int i=0; i<13; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 159);
				Main.dust[dust].velocity /= 3f;  //this modify the velocity of the first dust
				Main.dust[dust].scale = 1.3f;  //this modify the scale of the first dust
				Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;
            }
        }
    }
}