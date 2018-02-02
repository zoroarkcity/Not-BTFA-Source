using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.FaceOfInsanity
{
	public class PinkEye : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 20;
			npc.damage = 35;
			npc.defense = 10;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 0f;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.knockBackResist = 0f;
			//npc.aiStyle = 14;
			//aiType = NPCID.GiantBat;
		}
		
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Eye");
			Main.npcFrameCount[npc.type] = 5;
			//animationType = NPCID.GiantBat;
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.2f;
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public override void AI()
		{
			npc.ai[0]++;
			Player target = Main.player[npc.target];
			Vector2 vector = target.Center - npc.Center;
			vector.Normalize();
			npc.rotation = vector.ToRotation();
			if (npc.direction == -1)
				npc.rotation += MathHelper.Pi;
			
			npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, 0.05f);
			
			if (npc.ai[0] <= 180 && npc.ai[0] % 60 == 0)
			{
				float num4 = 10f;
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
				float num5 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
				float num6 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
				float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
				float num8 = num4 / num7;
				npc.velocity.X = num5 * num8;
				npc.velocity.Y = num6 * num8;
			}
			
			if (npc.ai[0] > 180)
			{
				int p = Projectile.NewProjectile(npc.Center, vector * 10, mod.ProjectileType("BrimstoneSmall"), npc.damage / 2, 0, npc.target, 0, 0);
				Main.projectile[p].netUpdate = true;
				npc.netUpdate = true;
				npc.ai[0] = 0;
			}
			
			
			
			if (Main.dayTime) //despawn
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				npc.ai[0] = 0;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
            }
		}
	}
}
