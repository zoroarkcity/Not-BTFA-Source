using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ForgottenMemories
{
	public class MyPlayer : ModPlayer
	{
		
		public bool GroundPound;
		public bool Pound;
		public bool AquaPowers;
		public bool isGlitch;
		public bool breakShop;
		public static int rubixCubeSwitcher;
		public bool CosmicPowers;
		public bool hauntedCandle;
		public bool duneBonus;
		public float rangedVelocity;
		public float magicAttackSpeed;
		public bool boneHearts;
		public bool chlorophyllPod;
		public bool chlorophyllPodStage1;
		public bool chlorophyllPodStage2;
		public bool chlorophyllPodStage3;
		
		public override void ResetEffects()
		{
			GroundPound = false;
			AquaPowers = false;
			isGlitch = false;
			CosmicPowers = false;
			hauntedCandle = false;
			duneBonus = false;
			boneHearts = false;
			chlorophyllPod = false;
			chlorophyllPodStage1 = false;
			chlorophyllPodStage2 = false;
			chlorophyllPodStage3 = false;
			magicAttackSpeed = 1f;
			rangedVelocity = 1f;
			rubixCubeSwitcher = 0;
		}
		
		public override void PostUpdate()
	    {
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (chlorophyllPod)
			{
			    player.lifeRegen = ((player.lifeRegen/100)*5) + player.lifeRegen;
				player.moveSpeed = (player.moveSpeed*0.05f) + player.moveSpeed;		
				player.meleeCrit = player.meleeCrit + 5;
				chlorophyllPodStage1 = true;
				chlorophyllPodStage2 = false;
				chlorophyllPodStage3 = false;
			}
			if (chlorophyllPod && chlorophyllPodStage1)
			{
				player.lifeRegen = ((player.lifeRegen/100)*10) + player.lifeRegen;
				player.moveSpeed = (player.moveSpeed*0.1f) + player.moveSpeed;		
				player.meleeCrit = player.meleeCrit + 10;
				chlorophyllPodStage1 = false;
				chlorophyllPodStage2 = true;
				chlorophyllPodStage3 = false;
			}
			if (chlorophyllPodStage2 && chlorophyllPod)
			{
				player.lifeRegen = ((player.lifeRegen/100)*15) + player.lifeRegen;
				player.moveSpeed = (player.moveSpeed*0.15f) + player.moveSpeed;		
				player.meleeCrit = player.meleeCrit + 15;
				chlorophyllPodStage1 = false;
				chlorophyllPodStage2 = false;
				chlorophyllPodStage3 = true;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockBack, bool Crit)
		{
			if (projectile.thrown == true && Main.rand.Next(5) == 0 && !target.immortal && boneHearts)
			{
				int number = Item.NewItem((int) target.position.X, (int) target.position.Y, target.width, target.height, mod.ItemType("BoneHeart"), 1, false, 0, false, false);
				Main.item[number].velocity.Y = (float)((double) Main.rand.Next(-20, 1) * 0.200000002980232);
				Main.item[number].velocity.X = (float)((double) Main.rand.Next(10, 31) * 0.200000002980232 * (double) projectile.direction);
				if (Main.netMode == 1)
					NetMessage.SendData(21, -1, -1, (NetworkText) null, number, 0.0f, 0.0f, 0.0f, 0, 0, 0);
			}
			if (chlorophyllPod)
			{
			    player.AddBuff(mod.BuffType("ChlorophyllBuffOne"), 4 * 60);
			}
			if (Main.LocalPlayer.FindBuffIndex(mod.BuffType("ChlorophyllBuffOne")) > -1 && chlorophyllPod)
			{
				player.AddBuff(mod.BuffType("ChlorophyllBuffOne"), 4 * 60);
				chlorophyllPodStage2 = true;
			}
			else 
			{
				chlorophyllPodStage2 = false;
			}
			if (Main.LocalPlayer.FindBuffIndex(mod.BuffType("ChlorophyllBuffOne")) > -1 && chlorophyllPodStage2 && chlorophyllPod)
			{
				chlorophyllPodStage3 = true;
			}
			else
			{
				chlorophyllPodStage3 = false;
			}
		}
		
		
		public override void SetupStartInventory(IList<Item> items)
		{
			Item item = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item.SetDefaults(mod.ItemType("OldBlade"));
				items.RemoveAt(0);
				items.Insert(0, item);
			}
			
			
			Item item2 = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item2.SetDefaults(mod.ItemType("OldPick"));
				items.RemoveAt(1);
				items.Insert(1, item2);
			}
			
			
			Item item3 = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item3.SetDefaults(mod.ItemType("OldAxe"));
				items.RemoveAt(2);
				items.Insert(2, item3);
			}
			
			Item btfadex = new Item();
			btfadex.SetDefaults(mod.ItemType("BTFADex"));
			btfadex.stack = 1;
			items.Add(btfadex);
		}
		
		public override void PreUpdate() 
		{
			if (GroundPound == true && player.controlUp && player.velocity.Y > 0)
			{
				player.velocity.Y *= 0.75f;
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlames"), 70, 0f, player.whoAmI, 0f, 0f);
			}
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlames"), 70, 0f, player.whoAmI, 0f, 0f);
				player.velocity.Y = 30f;
			}
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Pound = true;
			}
			
			if (GroundPound && Pound && player.controlDown)
			{
				if (player.velocity.Y == 0f)
				{
					Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlameBoom"), 105, 0f, player.whoAmI, 0f, 0f);
					Pound = false;
				}
				
			}
			
			if (AquaPowers == true && Main.rand.Next(50) == 0)
			{
				float spX = (float)Main.rand.Next(-30, 30) * 0.05f;
				float spY = (float)Main.rand.Next(-30, 30) * 0.05f;
				int projectile2 = Projectile.NewProjectile(player.Center.X, player.Center.Y, spX, spY, mod.ProjectileType("buble"), 18, 0f, player.whoAmI, 0f, 0f);
				Main.projectile[projectile2].melee = false;
			}
			
			if (CosmicPowers == true && player.statLife <= (int)(player.statLifeMax2 / 2))
			{
				player.AddBuff(mod.BuffType("CosmicBoon"), 2, false);
			}
		}
		
		public override bool Shoot (Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (item.ranged == true)
			{
				speedX *= rangedVelocity;
				speedY *= rangedVelocity;
			}
			return true;
		}
		
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (CosmicPowers == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 3);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-40, 40) * 0.1f;
					float pX = (float)Main.rand.Next(-120, 120) * 2;
					int projectile = Projectile.NewProjectile(player.Center.X + pX, player.Center.Y - 500, sX, 5, mod.ProjectileType("CosmirockMeteor"), 45, 0f, player.whoAmI, 0f, 0f);
					Main.projectile[projectile].melee = false;
					Main.projectile[projectile].timeLeft = 1000;
				}
			}
			if (duneBonus == true)
			{
				player.AddBuff(mod.BuffType("DuneWinds"), 10 * 60);
				
				int dust;
				Vector2 newVect = new Vector2 (10, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(player.Center, 0, 0, 32, newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(player.Center, 0, 0, 32, newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(player.Center, 0, 0, 32, newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(player.Center, 0, 0, 32, newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(player.Center, 0, 0, 32, newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(player.Center, 0, 0, 32, newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(player.Center, 0, 0, 32, newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(player.Center, 0, 0, 32, newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
				Main.dust[dust].scale = 2;
				Main.dust[dust2].scale = 2;
				Main.dust[dust3].scale = 2;
				Main.dust[dust4].scale = 2;
				Main.dust[dust5].scale = 2;
				Main.dust[dust6].scale = 2;
				Main.dust[dust7].scale = 2;
				Main.dust[dust8].scale = 2;
			}
		}
	}
}