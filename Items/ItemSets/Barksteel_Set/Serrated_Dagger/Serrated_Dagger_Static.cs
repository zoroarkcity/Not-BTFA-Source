using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Serrated_Dagger
{
    public class Serrated_Dagger_Static : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Serrated Dagger");
        } 
        public override void SetDefaults()
        {
            projectile.width = 1;  //Set the hitbox width
            projectile.height = 4;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
			aiType = 1;
			projectile.thrown = true;
			projectile.friendly = true;
            projectile.tileCollide = true; //Tells the game whether it is hostile to players or not
			projectile.timeLeft = 600;
			projectile.penetrate = 3;
            projectile.scale = 1f;				
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
			
			projectile.velocity.X = 0f;
			
			if (projectile.timeLeft >= 599)
			{
				projectile.velocity.Y = 5;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			player.GetModPlayer<WhirlingWorldsPlayer>().SerratedDaggerProjectileCount = 0;
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