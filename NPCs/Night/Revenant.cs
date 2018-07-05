using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Night
{
    public class Revenant : ModNPC
    {
		int projectileTimer;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Revenant");
			Main.npcFrameCount[npc.type] = 6;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 0;  
			npc.lifeMax = 60;	 
            npc.defense = 3;  
			npc.value = 90f;
            npc.knockBackResist = 0.75f;
            npc.width = 44;
			npc.noGravity = true;
            npc.height = 62;
			npc.damage = 0;
            npc.noTileCollide = false;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.HitSound = SoundID.NPCHit54;
			npc.dontTakeDamage = false;
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = -npc.direction;
			if (npc.active && player.active && npc.life < npc.lifeMax)
			{
				npc.aiStyle = 22;
				npc.damage = 15;
				
				projectileTimer++;
				int runeDelay = (Main.expertMode) ? 90 : 120;
				if (projectileTimer >= runeDelay)
				{
					npc.netUpdate = true;
					Projectile rune = Main.projectile[Projectile.NewProjectile(npc.Center, Vector2.Zero, mod.ProjectileType("Rune"), (int)(npc.damage/3), 1f, npc.target, npc.whoAmI, 0f)];
					rune.position += new Vector2(0, 75).RotatedByRandom(2 * MathHelper.Pi);
					rune.netUpdate = true;
					projectileTimer = 0;
				}
			}
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime && !spawnInfo.invasion && !spawnInfo.sky && !Main.eclipse && !spawnInfo.player.ZoneDesert && !spawnInfo.player.ZoneJungle ? 0.07f : 0f;
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
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkEnergy"), Main.rand.Next(3, 6));
			if(Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NightlyBoomerang"));
			}
			if(Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Silk, Main.rand.Next(1, 3));
			}
		}
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			const int Frame_5 = 4;
			const int Frame_6 = 5;
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
			else if (npc.frameCounter < 28)
			{
				npc.frame.Y = Frame_5 * frameHeight;
			}
			else if (npc.frameCounter < 32)
			{
				npc.frame.Y = Frame_6 * frameHeight;
			}
			else
			{
				npc.frameCounter = 0;
			}
			
		}
    }
}