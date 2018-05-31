using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.Night
{
	public class ArteCute : ModNPC
	{
		public int timer = 0;
		
		public override void SetDefaults()
		{
			npc.width = 42;
			npc.height = 44;
			npc.damage = 64;
			npc.defense = 14;
			npc.lifeMax = 440;
			npc.HitSound = SoundID.NPCHit18;
			npc.DeathSound = SoundID.NPCDeath13;
			npc.value = 440f;
			npc.noTileCollide = false;
			npc.noGravity = true;
			npc.knockBackResist = 0.4f;
			npc.aiStyle = 22;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Accursed Bloodling");
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.spawnTileY < Main.rockLayer && Main.bloodMoon && Main.hardMode ? 0.144f : 0f;
		}

		public void ShootSpinalBolts()
        {
            Player player = Main.player[npc.target];
            Vector2 distance = player.Center - npc.Center;
            
            float gravity = 0.35f;
            float time = 75f;
            
            Vector2 Vel = new Vector2(distance.X / time, distance.Y / time - 0.5f * gravity * time);

			int damage = npc.damage / 4;
            int p = Projectile.NewProjectile(npc.Center + npc.velocity * 5, Vel, mod.ProjectileType("SpinalBoltEvil"), damage, 0, Main.myPlayer, 1f, 1f);

            Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 9);
        }

		public override bool PreAI()
		{
			if (Main.dayTime) //despawn
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				npc.noTileCollide = true;
				//npc.ai[0] = 0;
				//npc.ai[1] = 0;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
				return false;
            }

			timer++;

			if (timer > 480)
			{
				Main.player[npc.target].AddBuff(mod.BuffType("Menaced"), 2);
				
				if (timer == 570)
				{
					timer = 0;
				}
				
				npc.velocity *= 0.97f;
				return false;
			}

			npc.type = 490;
			return true;
		}
		
		public override void AI()
		{
			npc.type = mod.NPCType("ArteCute");
			npc.spriteDirection = npc.direction;

			int x = (int) npc.Center.X / 16;
			int y = (int) npc.Center.Y / 16;

			if (Main.tile[x, y] == null)
			{
				Main.tile[x, y] = new Tile();
			}

			if (Main.tile[x, y].nactive() && Main.tileSolid[(int) Main.tile[x, y].type] || (int) Main.tile[x, y].liquid > 0)
			{
				npc.noTileCollide = true;
			}
			else
			{
				npc.noTileCollide = false;
			}

			Player player = Main.player[npc.target];
			if (player.active && !player.dead)
			{
				if ((timer == 120 || timer == 240 || timer == 360) && Vector2.Distance(player.Center, npc.Center) < 1000)
				{
					ShootSpinalBolts();
				}

				if (player.Center.X > npc.Center.X && npc.velocity.X < 0)
					npc.velocity.X = 0;
				
				if (player.Center.X < npc.Center.X && npc.velocity.X > 0)
					npc.velocity.X = 0;
			}
			
			if (timer == 480) //spooky dash
			{
				Vector2 distance = player.Center - npc.Center;
				distance.Normalize();
				distance *= 24f;
				npc.velocity = distance;
				npc.noTileCollide = true;
				Main.PlaySound(15, (int)npc.Center.X, (int)npc.Center.Y, 2);
			}
		}

		public override void OnHitPlayer (Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 240);
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/ArteCute"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/ArteCute_2"), 1f);
			}
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(5) < 2 && !TGEMWorld.downedArterius) //40%
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodClot"), 1);
			}
			if (Main.rand.Next(20) == 0 && TGEMWorld.downedArterius) //5%
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodClot"), 1);
			}
/*			if (Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Rock"), 1);
			} */
		}
	}
}
