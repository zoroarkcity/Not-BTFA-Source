using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.FaceOfInsanity
{
	public class ExplosiveZitEnemy : ModNPC
	{
        public bool hasSpawned = false;
        public const float gravity = 0.3f;
        public const float halfTime = 60f;
		
		public override void SetDefaults()
		{
			npc.width = 28;
			npc.height = 32;
			npc.friendly = false;
			npc.damage = 40;
			if (Main.expertMode)
			{
				if (TGEMWorld.downedArterius)
					npc.damage = 114;
				else
					npc.damage = 80;
			}
			npc.defense = 0;
			npc.lifeMax = 1;
			npc.aiStyle = -1;
			npc.knockBackResist = 0f;
			npc.value = 0;
			npc.noGravity = true; //i'll use my own damn gravity thank you very much
			npc.alpha = 255;

			npc.buffImmune[BuffID.OnFire] = true;
		}

		/*public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			//npc.damage = 74;
			if (TGEMWorld.downedArterius)
			{
				npc.damage = 400;
			}
		}*/
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosive Zit");
		}

		public override bool PreAI()
		{
			if (!hasSpawned)
			{
				npc.velocity.X = npc.ai[1];
                npc.velocity.Y = npc.ai[2];

				hasSpawned = true;
			}

			return true;
		}

		public override void AI()
		{
			npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;;
			
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(npc.Center + npc.velocity, 0, 0, 170, 0f, 0f);
				Main.dust[dust].scale = 1f;
				Main.dust[dust].noGravity = true;
			}
			if (npc.alpha > 0)
			{
				npc.alpha -= 5;
			}

			if ((npc.velocity.X == 0 || npc.velocity.Y == 0) && npc.ai[0] > halfTime)
			{
				npc.life = 0;
				npc.checkDead();
				/*int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ExplosiveZit"), (int) (npc.damage / 4.11764706), 1, Main.myPlayer, 0, 0);
				Main.projectile[p].netUpdate = true;
				Main.projectile[p].Kill();*/
			}
			npc.ai[0]++;

			npc.velocity.Y += gravity;
		}
		
		public override bool CheckDead()
		{
			int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ExplosiveZit"), (int) (npc.damage / 4.11764706), 1, Main.myPlayer, 0, 0);
			Main.projectile[p].netUpdate = true;
			Main.projectile[p].Kill();

			return true;
		}
		
		/*public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Ichor, 30 * Main.rand.Next(3, 6), false);
		}*/
	}
}