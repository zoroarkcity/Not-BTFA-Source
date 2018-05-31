using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Sky
{
    public class Infection_Fly : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aerial Aphid");
			Main.npcFrameCount[npc.type] = 6;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 14;  
			npc.lifeMax = 80;	 
            npc.defense = 3;  
			npc.value = 500f;
            npc.knockBackResist = 0.8f;
            npc.width = 60;
            npc.height = 60;
			npc.damage = 30;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.HitSound = 	new Terraria.Audio.LegacySoundStyle(3, 35);
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(4, 21);
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			/*if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Energy_Humanoid_Gore"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Energy_Humanoid_Gore"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Energy_Humanoid_Gore_2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Energy_Humanoid_Gore_2"), 1f); ADD GORES HERE
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Energy_Humanoid_Gore_3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Energy_Humanoid_Gore_4"), 1f);
			}*/
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 75, 2.5f * hitDirection, -2.5f, 0, new Color(), 1f);
					Dust.NewDust(npc.position, npc.width, npc.height, 75, 2.5f * hitDirection, -2.5f, 0, new Color(), 1f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 75, 2.5f * hitDirection, -2.5f, 0, new Color(), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 75, 2.5f * hitDirection, -2.5f, 0, new Color(), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 75, 2.5f * hitDirection, -2.5f, 0, new Color(), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSkyHeight && NPC.downedBoss2 ? 0.04f : 0f;
		}
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoaringEnergy"), Main.rand.Next(2, 7));
			if(Main.rand.Next(12) == 0 && !Main.hardMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Valhalla"));
			}
			if(Main.rand.Next(33) == 0 && Main.hardMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Valhalla"));
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			BTFAUtility.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Sky/Infection_Fly"));
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Infection_Fly"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Infection_Fly_2"), 1f);
			}
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			npc.life = 0;
			npc.lifeMax = 0;
			Main.PlaySound(new Terraria.Audio.LegacySoundStyle(4, 21));
			player.AddBuff(BuffID.CursedInferno, 60*3);
		}
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			const int Frame_5 = 4;
			const int Frame_6 = 5;
			
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