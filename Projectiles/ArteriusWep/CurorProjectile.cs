using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class CurorProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 19;
			projectile.scale = 1.4f;
			projectile.penetrate = -1;

			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Curor");
		}

		public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{
				Main.player[Main.myPlayer].AddBuff(BuffID.SoulDrain, 299);
			}
		}

		public float movementFactor // Change this value to alter how fast the spear moves
		{
			get { return projectile.ai[0]; }
			set { projectile.ai[0] = value; }
		}

		public override void AI() //YALL MIND IF I MMMMMMMMM PLAGIARIZE EXAMPLEMOD
		{
			Player projOwner = Main.player[projectile.owner];
			
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
				{
					movementFactor = 3.4f; // Make sure the spear moves forward when initially thrown out
					projectile.netUpdate = true; // Make sure to netUpdate this spear
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
				{
					movementFactor -= 2.4f;
				}
				else // Otherwise, increase the movement factor
				{
					movementFactor += 2.1f;
				}
			}
			
			projectile.position += projectile.velocity * movementFactor;
			
			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}
			
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
		}
	}
}	