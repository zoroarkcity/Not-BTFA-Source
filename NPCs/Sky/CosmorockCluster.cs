using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Sky
{
	public class CosmorockCluster : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 68;
			npc.height = 66;
			npc.damage = 30;
			npc.defense = 20;
			npc.lifeMax = 800;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.noGravity = true;
			npc.value = 100;
			npc.knockBackResist = 0f;
			banner = npc.type;
			bannerItem = mod.ItemType("CosmoRockClusterBannerItem");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmorock Cluster");
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 1000;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSkyHeight && TGEMWorld.downedTitanRock && !spawnInfo.invasion ? 0.05f : 0f;
		}
		
		public override void NPCLoot()
		{
			for (int m = 0; m <= 10; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 15);
			}
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpaceRockFragment"), Main.rand.Next(4, 12));	
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CosmorockCluster/CosmorockClusterGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CosmorockCluster/CosmorockClusterGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CosmorockCluster/CosmorockClusterGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CosmorockCluster/CosmorockClusterGore4"), 1f);
		}
				
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			npc.ai[0]++;
			
			if (npc.ai[0] >= 30 && npc.ai[1] < 3)
			{
				
				Main.PlaySound(SoundID.Item9, (int)npc.position.X, (int)npc.position.Y);
				
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 4f, direction.Y * 4f, mod.ProjectileType("CosmirockMeteor"), npc.damage / 4, 1, Main.myPlayer, 0, 0);
				Main.projectile[p].friendly = false;
				Main.projectile[p].hostile = true;
				Main.projectile[p].extraUpdates = 1;
				Main.projectile[p].timeLeft = 10000;
				
				Vector2 vector2_4 = npc.velocity - ((direction / 3f) * 5f);
				npc.velocity = vector2_4;
				npc.netUpdate = true;
				
				npc.ai[1]++;
				npc.ai[0] = 0;
			}
			
			else
			{
				npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, 0.08f);
			}
			
			if (npc.ai[1] >= 3)
			{
				int A = Main.rand.Next(-250, 250) * 2;
				int B = Main.rand.Next(-100, 100) - 300;
				Vector2 telep = new Vector2(player.Center.X + A, player.Center.Y + B);
				npc.Center = telep;
				for (int m = 0; m < 1; m++)
				{
					Main.PlaySound(SoundID.Item105, (int)npc.position.X, (int)npc.position.Y);
					int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("CosmosBoom"), npc.damage / 4, 1, Main.myPlayer, 1, 0);
					Main.projectile[p].friendly = false;
					Main.projectile[p].hostile = true;
					Main.projectile[p].scale = 2f;
				}
				npc.ai[1] = 0;
				
				npc.ai[0] = 0;
			}
			if (npc.position.X > player.position.X)
			{
				npc.spriteDirection = -1;
			}
			if (npc.position.X < player.position.X)
			{
				npc.spriteDirection = 1;
			}
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = -20;
				npc.ai[0] = 0;
			}
		}
	}
}
