using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Desert
{
    public class Tornado : ModNPC
    {
		int projectileTimer;
		int ai;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Spirit");
			Main.npcFrameCount[npc.type] = 4;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 22;  
			npc.lifeMax = 130;	 
            npc.defense = 8;  
			npc.value = 100f;
            npc.knockBackResist = 0.75f;
            npc.width = 48;
			npc.noGravity = true;
            npc.height = 80;
			npc.damage = 15;
            npc.noTileCollide = false;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.HitSound = SoundID.NPCHit37;
			npc.dontTakeDamage = false;
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = -npc.direction;
			ai++;
			if (ai >= 180)
			{
				npc.aiStyle = 0;  
				projectileTimer++;
				npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, 0.15f);
				int TornadoDelay = (Main.expertMode) ? 40 : 60;
				if (projectileTimer >= TornadoDelay)
				{
					npc.netUpdate = true;
					Vector2 Vel = new Vector2(0, 3).RotatedByRandom(MathHelper.ToRadians(360));
					int p = Projectile.NewProjectile(npc.Center, Vel, mod.ProjectileType("DuneTornado"), (int)(npc.damage/2), 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Main.projectile[p].netUpdate = true;
					projectileTimer = 0;
				}
				if (ai > 300)
				{
					ai = 0;
					npc.netUpdate = true;
				}
			}
			else
			{
				npc.aiStyle = 22;  
			}
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSandstorm && NPC.downedBoss1 && !spawnInfo.invasion ? 0.08f : 0f;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			/*if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Desert_Totem"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Desert_Totem_2"), 1f);
			}*/
		}
		public override void NPCLoot ()
		{
			//if (Main.rand.Next(5) == 0) 
			//	Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, 658, (int)(npc.damage/6), 1f, npc.target, 0f, 0f);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BossEnergy"), Main.rand.Next(5, 9));
		}
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			Player player = Main.player[npc.target];
			
			
			npc.frameCounter++;
			if (npc.frameCounter < 6)
			{
				npc.frame.Y = Frame_1 * frameHeight;
			}
			else if (npc.frameCounter < 12)
			{
				npc.frame.Y = Frame_2 * frameHeight;
			}
			else if (npc.frameCounter < 18)
			{
				npc.frame.Y = Frame_3 * frameHeight;
			}
			else if (npc.frameCounter < 24)
			{
				npc.frame.Y = Frame_4 * frameHeight;
			}
			else
			{
				npc.frameCounter = 0;
			}
		}
    }
}