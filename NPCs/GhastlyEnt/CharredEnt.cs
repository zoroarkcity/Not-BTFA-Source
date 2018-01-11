using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class CharredEnt : ModNPC
	{
		int ai;
		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 40;
			npc.damage = 38;
			npc.defense = 18;
			npc.lifeMax = 80;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 31;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charred Ent");
			Main.npcFrameCount[npc.type] = 4;
		}
		
		public override void AI()
        {
			Player player = Main.player[npc.target];
			ai++;
			if (ai >= 20 + Main.rand.Next(-5, 5))
			{
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, 326 + Main.rand.Next(3), (int)(npc.damage / 2), 1, Main.myPlayer, 0, 0);
				npc.netUpdate = true;
				ai = 0;
			}
			
			Vector2 newMove = npc.Center - player.Center;
			float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
			
			if (!player.active || player.dead || distanceTo >= 1000)
            {
                npc.TargetClosest(false);
				
				if (npc.timeLeft > 60)
				{
					npc.timeLeft = 60;
				}
            }
			
			if (npc.position.X > player.position.X)
			{
				npc.spriteDirection = -1;
			}
			if (npc.position.X < player.position.X)
			{
				npc.spriteDirection = 1;
			}
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.12f;
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CharredEnt/CharredEntGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CharredEnt/CharredEntGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CharredEnt/CharredEntGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CharredEnt/CharredEntGore4"), 1f);
			
			for (int m = 0; m <= 5; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
			}
			
			for (int m = 0; m <= 10; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 191);
			}
					
			if(Main.rand.Next(20) == 0)
			{
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingTwig"));
			}
		}
	}
}
