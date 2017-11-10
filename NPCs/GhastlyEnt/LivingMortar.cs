using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class LivingMortar : ModNPC
	{
		int timer = 0;
		int timer2 = 0;
		bool hasShot = false;
		public override void SetDefaults()
		{
			npc.width = 46;
			npc.height = 44;
			npc.damage = 28;
			npc.defense = 12;
			npc.lifeMax = 80;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 508;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Wood Mortar");
			Main.npcFrameCount[npc.type] = 9;
		}
		
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.TargetClosest(true);
			timer++;
			float distance = 200f;
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
			
			if (timer >= 120 && npc.velocity.Y == 0f && distanceTo < distance && !player.dead)
			{
				Vector2 vel = (player.Center - npc.Center);
				vel.Normalize();
				vel *= 4;
				vel.X *= 2f;
				vel.Y /= 2f;
				Projectile projectile = Main.projectile[Projectile.NewProjectile(npc.Center, vel, mod.ProjectileType("wooball"), (int)(npc.damage/4), 0, Main.myPlayer, 0, 0)];
				projectile.friendly = false;
				projectile.hostile = true;
				hasShot = true;
				timer = 0;
			}
			
			if (hasShot)
			{
				timer2++;
				npc.velocity.Y = 10f;
				npc.velocity.X = 0;
				if (timer2 >= 15)
				{
					hasShot = false;
					timer2 = 0;
				}
			}
		}
		
		public override void FindFrame(int frameHeight)
		{
			int num1 = 1;
			if (npc.velocity.Y == 0.0)
			{
				if (npc.direction == 1)
					npc.spriteDirection = 1;
				if (npc.direction == -1)
					npc.spriteDirection = -1;
			}
			if (hasShot)
			{
				npc.frameCounter += 0.2f;
				npc.frameCounter %= 5; 
				int frame = (int)npc.frameCounter + 4;
				npc.frame.Y = frame * frameHeight;
			}
			else
			{
				npc.frameCounter += 0.25f; 
				npc.frameCounter %= 4; 
				int frame = (int)npc.frameCounter; 
				npc.frame.Y = frame * frameHeight;
			}
		}
		
		public override void NPCLoot()
		{
			
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
