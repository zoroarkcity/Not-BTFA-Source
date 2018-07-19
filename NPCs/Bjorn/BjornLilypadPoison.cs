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
	public class BjornLilypadPoison : ModNPC
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
            {
                npc.ai[0]++;

                if (npc.ai[0] >= 120f && Main.netMode != 1 && Main.rand.Next(20) == 0)
                {
                    float speedX = Main.rand.Next(-20, 21) * 0.1f;
                    float speedY = Main.rand.Next(-30, -6) * 0.2f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, speedX, speedY, mod.ProjectileType("BjornSpore"), (int)npc.ai[0], 0, Main.myPlayer);
                }
            }

            if (npc.ai[0] >= 480f)
            {
                npc.life = 0;
                npc.checkDead();
                npc.active = false;
            }
		}

        public override bool CheckActive()
        {
            return false;
        }
    }
}
