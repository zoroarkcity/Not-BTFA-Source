using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Magnoliac.Projectiles
{
    public class ExpertMagnoliac : ModProjectile
    {
		public static int Rand = 0;
		public static float BaseHeight = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flying Feather");
        }
        public override void SetDefaults()
        {
            projectile.width = 18;  //Set the hitbox width
            projectile.height = 28;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
            projectile.hostile = true; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = false; //Tells the game whether it is hostile to players or not
            projectile.timeLeft = 600; //The amount of time the projectile is alive for
			projectile.extraUpdates = 1;
			projectile.scale = 1f;	
        }
        public override void AI()
        {
			projectile.ai[1]++;
            for (int index1 = 0; index1 < 1; ++index1)
            {
				projectile.rotation += 3.1f;	
			}
			if (projectile.ai[1] == 10)
			{
				projectile.ai[1] = 0;
			}
			if (projectile.timeLeft == 599)
			{
				BaseHeight = projectile.position.Y;
			}
			if (projectile.timeLeft >= 300 && projectile.position.Y > BaseHeight - 100)
			{
				projectile.velocity.Y = - 5f;
			}
			if (projectile.timeLeft >= 300 && projectile.position.Y == BaseHeight - 100)
			{
				projectile.velocity.Y = 0;
				projectile.velocity.X = 0;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0.3f);
			}
			return true;
		}
		public override void PostAI()
        {
            for (int num46 = projectile.oldPos.Length - 1; num46 > 0; num46--)
            {
                projectile.oldPos[num46] = projectile.oldPos[num46 - 1];
            }
            projectile.oldPos[0] = projectile.position;
        }
    }
}