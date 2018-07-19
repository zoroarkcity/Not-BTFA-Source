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
	public class BjornLilypad : ModNPC
    {
        public override void SetDefaults()
        {
			npc.width = 20;
			npc.height = 20;
			npc.damage = 0;
            npc.knockBackResist = 0f;
            npc.dontTakeDamage = true;
            npc.lifeMax = 1;
            //npc.DeathSound = SoundID.NPCDeath10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lily Pad");
        }

        public override void AI()
		{
            if (npc.velocity == Vector2.Zero)
                npc.ai[0]++;

            if (npc.ai[0] >= 120f)
            {
                npc.life = 0;
                npc.checkDead();
                npc.active = false;
            }
		}

        public override bool CheckDead()
        {
            if (Main.netMode != 1) //spawn froggos
            {
                int cap = Main.expertMode ? 3 : 2;
                for (int i = 0; i < cap; i++)
                {
                    int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SlimeSpiked); //placeholder for frog, presumably slime AI
                    if (n < 200)
                    {
                        Main.npc[n].velocity.X = (float)Main.rand.Next(-15, 16) * 0.4f;
                        Main.npc[n].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.4f;
                        if (Main.netMode == 2)
                            NetMessage.SendData(23, -1, -1, null, n, 0f, 0f, 0f, 0, 0, 0);
                    }
                }
            }

            return true;
        }

        public override bool CheckActive()
        {
            return false;
        }
    }
}
