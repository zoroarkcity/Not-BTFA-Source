using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Vanta.Vanta_Magic.Projectiles  
{
	public class Vanta_Magic_Projectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 150;
			projectile.height = 150;
			projectile.penetrate = -1;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			projectile.timeLeft = 10;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Starshine");
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			int Type;
				switch (Main.rand.Next(4))
				{
					case 0:
						Type = 90;
						break;
					case 1:
						Type = 87;
						break;
					case 2:
						Type = 88;
						break;
					case 3:
						Type = 89;
						break;
					default:
						Type = 90;
						break;
				}		
			for (int index2 = 0; index2 < Main.npc.Length; ++index2)
            {
                NPC npc = Main.npc[index2];
				if ((npc.active && !npc.friendly && (npc.damage > 0 && !npc.dontTakeDamage) && (double) Vector2.Distance(player.Center, npc.Center) <= (double) 600f))
				{
					int num23 = 9;	
					for (int index1 = 0; index1 < num23; ++index1)
					{
						Vector2 vector2_3 = (new Vector2((float) npc.width / 4, (float) npc.height) * 0.75f * 0.5f).RotatedBy((double) (index1 - (num23 / 2 - 1)) * 6.28318548202515 / (double) num23, new Vector2()) + npc.Center;
						Vector2 vector2_4 = vector2_3 - npc.Center;
						int gayporn = Dust.NewDust(vector2_3 + vector2_4, 0, 0, Type, vector2_4.X * 2f, vector2_4.Y * 2f, 100, new Color(), 1.4f);
						Main.dust[gayporn].noGravity = true;
						Main.dust[gayporn].noLight = false;
						Main.dust[gayporn].scale = 2f;
						Main.dust[gayporn].velocity = Vector2.Normalize(vector2_4) * 5f;
					}
					for (int index1 = 0; index1 < num23; ++index1)
					{
						Vector2 vector2_3 = (new Vector2((float) npc.width / 8, (float) npc.height) * 0.75f * 0.5f).RotatedBy((double) (index1 - (num23 / 2 - 1)) * 6.28318548202515 / (double) num23, new Vector2()) + npc.Center;
						Vector2 vector2_4 = vector2_3 - npc.Center;
						int gayporn = Dust.NewDust(vector2_3 + vector2_4, 0, 0, Type, vector2_4.X * 2f, vector2_4.Y * 2f, 100, new Color(), 1.4f);
						Main.dust[gayporn].noGravity = true;
						Main.dust[gayporn].noLight = false;
						Main.dust[gayporn].scale = 2f;
						Main.dust[gayporn].velocity = Vector2.Normalize(vector2_4) * 5f;
					}
					if ((npc.active && !npc.friendly && (npc.damage > 0 && !npc.dontTakeDamage) && (double) Vector2.Distance(player.Center, npc.Center) <= (double) 600f))
                    {
						projectile.position.X = npc.position.X;
						projectile.position.Y = npc.position.Y;
						projectile.Damage();
                    }
				}
			}
		}
	}
}	