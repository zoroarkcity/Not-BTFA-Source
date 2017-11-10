using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories
{
	public class GlobalNPC1 : GlobalNPC
	{
		int DagNum = 0;
		public bool BlightCelled = false;
		public bool BloodLeech = false;
		public bool MarbleArrow = false;
		public bool Necro = false;
		
		public override void ResetEffects(NPC npc)
        {
            DagNum = 0;
			BlightCelled = false;
			BloodLeech = false;
			MarbleArrow = false;
			Necro = false;
        } 
		
		public override bool InstancePerEntity {get{return true;}}
		
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.GetModPlayer<MyPlayer>(mod).isGlitch)
			{
				spawnRate = (int)(spawnRate * 50f);
				maxSpawns = (int)(maxSpawns * 50f);
			}
		}
		
		public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
			if (npc.FindBuffIndex(mod.BuffType("BlightFlame")) >= 0)
			{
				if (damage < 10)
				{
					damage = 10;
				}
			}
			
			if (npc.FindBuffIndex(mod.BuffType("TitanCrush")) >= 0)
			{
				if (damage < 20)
				{
					damage = 20;
				}
			}
			
			if (npc.FindBuffIndex(mod.BuffType("Frostburn2")) >= 0)
			{
				if (damage < 10)
				{
					damage = 10;
				}
			}
			
			if (npc.FindBuffIndex(mod.BuffType("Bleeding")) >= 0)
			{
				if (damage < 4)
				{
					damage = 4;
				}
			}
			
			if (BlightCelled == true)
			{
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				int num = 0;
				for (int index = 0; index < 1000; ++index)
				{
				  if (Main.projectile[index].active && Main.projectile[index].type == mod.ProjectileType("BlightOrbShoot") && ((double) Main.projectile[index].ai[0] == 1.0 && (double) Main.projectile[index].ai[1] == (double) npc.whoAmI))
					++num;
				}
				npc.lifeRegen -= num * 4 * 5;
				if (damage < num * 5)
					damage = num * 5;
			}
			
			if (BloodLeech == true)
			{
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				int num = 0;
				DagNum = num;
				for (int index = 0; index < 1000; ++index)
				{
				  if (Main.projectile[index].active && Main.projectile[index].type == mod.ProjectileType("BloodLeech") && ((double) Main.projectile[index].ai[0] == 1.0 && (double) Main.projectile[index].ai[1] == (double) npc.whoAmI))
					++num;
				}
				npc.lifeRegen -= num * 4 * 3;
				if (damage < num * 3)
					damage = num * 3;
			}
			
			if (MarbleArrow == true)
			{
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				int num = 0;
				for (int index = 0; index < 1000; ++index)
				{
				  if (Main.projectile[index].active && Main.projectile[index].type == mod.ProjectileType("MarbleArrow") && ((double) Main.projectile[index].ai[0] == 1.0 && (double) Main.projectile[index].ai[1] == (double) npc.whoAmI))
					++num;
				}
				npc.lifeRegen -= num * 4 * 5;
				if (damage < num * 5)
					damage = num * 5;
			}
			
			if (Necro == true)
			{
				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				int num = 0;
				for (int index = 0; index < 1000; ++index)
				{
				  if (Main.projectile[index].active && Main.projectile[index].type == mod.ProjectileType("NecroDagger") && ((double) Main.projectile[index].ai[0] == 1.0 && (double) Main.projectile[index].ai[1] == (double) npc.whoAmI))
					++num;
					npc.AddBuff(mod.BuffType("NecroDagger"), 180, false);
				}
				npc.lifeRegen -= num * 4 * 3;
				if (damage < num * 3)
					damage = num * 3;
			}
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot) // add items to npc shops
		{
			if (type == 19) // arms dealer
			{
				if (NPC.downedBoss2) // check if EoW/BoC is defeated
				{
					shop.item[nextSlot].SetDefaults(mod.ItemType("psychic_pistol")); // sell psychic pistol
					nextSlot++;
				}
				if (NPC.downedAncientCultist)
				{
					shop.item[nextSlot].SetDefaults(mod.ItemType("VengeanceBullet"));
					nextSlot++;
				}
				
				for (int i = 0; i < 200; i++)
				{
					Player player = Main.player[i];
					if (player.HasItem(mod.ItemType("AncientLauncher")))
					{
						shop.item[nextSlot].SetDefaults(771);
						nextSlot++;
					}
				}
			}
		}
		
		public override void NPCLoot(NPC npc)
		{
			if (BloodLeech == true)
			{
				for (int i = 0; i <= DagNum; i++)
				{
					int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("BloodBoom"), 50, 0f, Main.player[npc.target].whoAmI, 0f, 0f);
					Main.projectile[p].melee = false;
					Main.projectile[p].thrown = true;
					Main.projectile[p].usesLocalNPCImmunity = true;
					Main.projectile[p].localNPCHitCooldown = 10;
				}
			}
		}
	}
}
