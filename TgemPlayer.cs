using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
    public class TgemPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool Servant = false;
		public bool cryotine1 = false;
		public bool BlightFlameRing = false;
		public bool EaterMinion = false;
		public bool BlightstoneDragon = false;
		public bool BlightFlameProj;
		int BlightCounter = 0;
		public bool WoodlouseMinion = false;
		public bool CreeperMinion = false;
		public bool BlightConserve = false;
		public bool ShadowflameSpirit = false;
		public bool BloodSlime = false;
        public static bool hasProjectile;
		public bool slimeGuard = false;
		public bool BlightOrb = false;
		public bool ChaoticSet = false;
		public bool stardustCrown = false;
		public bool ghastlywood = false;

        public override void ResetEffects()
        {
			BlightstoneDragon = false;
			BlightFlameRing = false;
			BlightFlameProj = false;
			BloodSlime = false;
			BlightOrb = false;
            Servant = false;
			cryotine1 = false;
            WoodlouseMinion = false;
			CreeperMinion = false;
			ShadowflameSpirit = false;
			EaterMinion = false;
			slimeGuard = false;
			BlightConserve = false;
			ChaoticSet = false;
			stardustCrown = false;
			ghastlywood = false;
		}
		
		public override void PreUpdate()
		{
			if (player.ownedProjectileCounts[mod.ProjectileType("SlimeGuard")] < 1 && slimeGuard == true)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("SlimeGuard"), 15, 1f, player.whoAmI, 0f, 0f);
			}	
			
			if (player.ownedProjectileCounts[mod.ProjectileType("BlightOrb")] < 1 && BlightOrb == true)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("BlightOrb"), 45, 1f, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("BlightOrb2"), 95, 1f, player.whoAmI, 0f, 0f);
			}
			
			if (player.ownedProjectileCounts[mod.ProjectileType("BlightFireOrbit")] < 12 && BlightFlameRing == true)
			{
				Vector2 Ring = new Vector2(150, 0).RotatedBy(MathHelper.ToRadians(player.ownedProjectileCounts[mod.ProjectileType("BlightFireOrbit")] * 30));
				int p = Projectile.NewProjectile((player.position.X + Ring.X), (player.position.Y + Ring.Y), 0f, 0f, mod.ProjectileType("BlightFireOrbit"), 0, 0f, player.whoAmI, 0f, 0f);
				Main.projectile[p].position += new Vector2 (Main.projectile[p].width/4, Main.projectile[p].height/4);
			}
			
			if (player.ownedProjectileCounts[mod.ProjectileType("BlightLaserOrbit")] < 1 && BlightFlameRing == true)
			{
				BlightCounter++;
				if (BlightCounter >= 180)
				{
					int p = Projectile.NewProjectile((player.position.X + 150), (player.position.Y), 0f, 0f, mod.ProjectileType("BlightLaserOrbit"), 120, 0f, player.whoAmI, 0f, 0f);
					Main.projectile[p].position += new Vector2 (Main.projectile[p].width/2, Main.projectile[p].height/2);
					BlightCounter = 0;
				}
			}
		}
		
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (ChaoticSet == true)
			{
				for (int i = 0; i < 7; ++i)
				{
					float sX = (float)Main.rand.Next(-40, 40) * 0.15f;
					float sY = (float)Main.rand.Next(-120, 0) * 0.15f;
					int projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, 280, 90, 5f, player.whoAmI);
					Main.projectile[projectile].timeLeft = 120;
					Main.projectile[projectile].magic = false;
				}
			}
		}
		
		public override void UpdateBadLifeRegen()
		{
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2 * 0.75))
			{
				player.lifeRegen += 2;
				player.AddBuff (105, 1, false);
			}
			
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2/2))
			{
				player.lifeRegen += 6;
			}
			
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2 * 0.25))
			{
				player.lifeRegen += 4;
			}
				
		}
		
		public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (stardustCrown == true)
			{
				if (ProjectileID.Sets.SentryShot[projectile.type])
				{
					target.AddBuff(mod.BuffType("StardustInferno"), 1800, false);
				}
			}
			
			if (BlightFlameProj == true && (projectile.thrown == true || projectile.ranged == true) && Main.rand.Next(5) == 0)
			{
				int p = Projectile.NewProjectile (target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BlightBoomRange"), damage, knockback, player.whoAmI);
			}
			
			if (ghastlywood == true && projectile.magic == true && crit == true)
			{
				Player player = Main.player[projectile.owner];
				Vector2 mouse = Main.MouseWorld;
				Vector2 newMove = mouse - player.Center;
				newMove.Normalize();
				float memes = newMove.X * 3f;
				float memes2 = newMove.Y * 3f;
				memes += (float)Main.rand.Next(-40, 41) * 0.003f;
				memes2 += (float)Main.rand.Next(-40, 41) * 0.003f;
				int z = Projectile.NewProjectile(player.Center.X, player.Center.Y, memes, memes2, 206, projectile.damage, 0f, projectile.owner, 0f, 0f);
			}
		}
		
		public override bool ConsumeAmmo(Item weapon, Item ammo)
		{
			if (BlightConserve == true && Main.rand.Next(4) == 0)
			{
				return false;
			}
			
			return true;
		}
    }
}