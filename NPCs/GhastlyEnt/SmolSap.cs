using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class SmolSap : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 20;
			npc.damage = 30;
			npc.defense = 6;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 0f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.BlueSlime;
		}
		
		public override void NPCLoot()
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 64);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}		
			
		}
		
		public override void AI()
		{
            npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			
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
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sap Slime");
			Main.npcFrameCount[npc.type] = 2;
			animationType = NPCID.BlueSlime;
		}
	}
}
