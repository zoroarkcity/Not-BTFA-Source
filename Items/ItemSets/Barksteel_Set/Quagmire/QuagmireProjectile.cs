using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Quagmire
{
    public class QuagmireProjectile : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quagmire Provider");
        } 
        public override void SetDefaults()
        {
            projectile.width = 90;  
            projectile.height = 90;
            projectile.aiStyle = 1; 
            projectile.tileCollide = false; 
            aiType = ProjectileID.Bullet;
			projectile.timeLeft = 1;
            projectile.scale = 0f;			
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		 public override bool OnTileCollide(Vector2 oldVelocity)
        {
			{
			    projectile.active = true;
		    }
			return false;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
			
			if (player == Main.player[projectile.owner] && player.GetModPlayer<WhirlingWorldsPlayer>().Quagmire)
            {
                for (int index2 = 0; index2 < 200; ++index2)
				{
                    NPC npc = Main.npc[index2];
                    if ((double) Vector2.Distance(projectile.position, npc.Center) <= (double) 20f)
                    {
						npc.AddBuff(mod.BuffType("Targetted"), 1200);
						player.AddBuff(mod.BuffType("CounterTargetted"), 1200);
						projectile.Kill();
                    }
                }
            }
		}
    }
}