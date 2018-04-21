using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	public class SpikeTitan : ModNPC
	{
		//int timer = -300; //starts with initial delay of 380 ticks for first shot, then 80 ticks for every shot after
		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 64;
			npc.damage = 40;
			npc.defense = 25;
			npc.lifeMax = 300;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCHit41;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 14;
			animationType = NPCID.GiantBat;
			npc.lavaImmune = true;
			aiType = NPCID.GiantBat;
			npc.scale = 1.25f;

			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiked Titan");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantBat];
		}

		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 600;
			npc.damage = 80;
		}
		
		public override bool PreNPCLoot()
		{
			for (int i = 0; i < 30; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
				Main.dust[dust].scale = 1.5f;
			}
			
			return false;
		}
		
		public override void AI()
		{
			npc.ai[0]++;
			if (npc.ai[0] == 80f)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction *= 6;

				int damage = npc.damage / 2;
				if (Main.expertMode)
				{
					damage = npc.damage / 4;
				}
				
				if (npc.ai[3] == 1f) //double shot at 5 degree offset
				{
					Projectile.NewProjectile(npc.Center, direction.RotatedBy(0.0872664626), mod.ProjectileType("Ball2"), damage, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center, direction.RotatedBy(-0.0872664626), mod.ProjectileType("Ball2"), damage, 1, Main.myPlayer, 0, 0);
				}
				else
				{
					Projectile.NewProjectile(npc.Center, direction, mod.ProjectileType("Ball2"), damage, 1, Main.myPlayer, 0, 0);
				}

				npc.ai[0] = 0;
			}
		}
	}
}
