using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Bjorn
{
	public class BjornPygmy : ModNPC
    {
        int spearTimer = -1;

        public override void SetDefaults()
        {
			npc.aiStyle = 26;
			aiType = 508;
			npc.width = 18;
			npc.height = 18;
			npc.damage = 10;
            npc.defense = 4;
            npc.knockBackResist = 0.5f;
			npc.lifeMax = 30;
            //npc.HitSound = SoundID.NPCHit7;
            //npc.DeathSound = SoundID.NPCDeath10;
		}

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pygmy");
			Main.npcFrameCount[npc.type] = 4;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(spearTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            spearTimer = reader.ReadInt32();
        }

        public override void AI()
		{
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			
			Vector2 newMove = npc.Center - player.Center;
			if (!player.active || player.dead || newMove.Length() >= 3000)
            {
                npc.TargetClosest(false);
				
				if (npc.timeLeft > 60)
				{
					npc.timeLeft = 60;
				}
            }

            if (spearTimer <= 0)
            {
                if (spearTimer == 0 && Main.netMode != 1)
                {
                    Vector2 distance = player.Center - npc.Center;

                    float gravity = 0.1f;
                    float time = 90f;

                    Vector2 Vel = new Vector2(distance.X / time, distance.Y / time - 0.5f * gravity * time);

                    int damage = (int)(npc.damage / 4.11764706);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Vel.X, Vel.Y, mod.ProjectileType("BjornPygmySpear"), damage, 0, Main.myPlayer);
                }

                spearTimer = Main.rand.Next(60, 181);

                npc.TargetClosest(false);
                npc.netUpdate = true;
            }
            spearTimer--;
        }

		public override void FindFrame(int frameHeight)
		{
			if (npc.velocity.Y == 0.0)
			{
				if (npc.direction == 1)
					npc.spriteDirection = 1;
				if (npc.direction == -1)
					npc.spriteDirection = -1;
				
				npc.frameCounter += 0.25f; 
				npc.frameCounter %= 4; 
				int frame = (int)npc.frameCounter; 
				npc.frame.Y = frame * frameHeight;
			}
		}
    }
}
