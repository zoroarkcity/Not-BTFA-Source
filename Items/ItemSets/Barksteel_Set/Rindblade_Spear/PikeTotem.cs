using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Rindblade_Spear
{
    public class PikeTotem : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pike");
        } 
        public override void SetDefaults()
        {
            projectile.width = 14;  //Set the hitbox width
            projectile.height = 14;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
			aiType = 1;
            projectile.tileCollide = true; //Tells the game whether it is hostile to players or not
			projectile.timeLeft = 1800000;
			projectile.penetrate = 1000;
			projectile.damage = 0;
            projectile.scale = 1f;	
			Main.projFrames[projectile.type] = 4;			
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
            Player player = Main.player[Main.myPlayer];

			Lighting.AddLight(projectile.position, 0.255f, 0.069f, 0f);			
			
			projectile.velocity.X = 0f;
			
			projectile.frameCounter++;
			
			if (projectile.frameCounter > 8)
			{
			   projectile.frame++;
               projectile.frameCounter = 1;
			}
            if (projectile.frame > 3)
            {
               projectile.frame = 0;
            }
			
            int type = mod.BuffType("ZombieNoAggro");
            float num1 = 400f;
            float num2 = 20f;
			if (player == Main.player[projectile.owner])
            {
                for (int index2 = 0; index2 < 1; ++index2)
				{
                    if (player.active && (double) Vector2.Distance(projectile.Center, player.Center) <= (double) num1)
                    {
                        player.statDefense += 8;
                    }
                }
				
            }
			if (player == Main.player[projectile.owner])
            {
                if (player.active && (double) Vector2.Distance(projectile.Center, player.Center) <= (double) num2)
                {
					Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("Rindblade_Spear"));
                    projectile.Kill();
                }
			}
			if (projectile.timeLeft >= 1799999)
			{
				projectile.velocity.Y = 1;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
			Vector2 usePos = projectile.position;	
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); 
			usePos += rotVector * 16f;

			for (int i = 0; i < 20; i++)
			{	
				int dustIndex = Dust.NewDust(usePos, projectile.width, projectile.height, 8, 0f, 0f, 0, default(Color), 1f);
				Dust currentDust = Main.dust[dustIndex];
				currentDust.position = (currentDust.position + projectile.Center) / 2f;
				currentDust.velocity += rotVector * 2f;
				currentDust.velocity *= 0.5f;
				currentDust.noGravity = true;
				usePos -= rotVector * 8f;
			}
		}
    }
}