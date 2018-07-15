using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Encrested_Wand    
{
	public class Encrested_Wand_Projectile_Alt : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.width = 4;
            projectile.height = 4;
            projectile.aiStyle = 1;
			aiType = ProjectileID.WoodenArrowFriendly;
            projectile.penetrate = -1;
		}
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Encrested Barrier");
        } 

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			projectile.velocity.Y = 20f;
		}
		
		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 36, 0f, 0f, mod.ProjectileType("Encrested_Wand_Projectile"), 10, 10f, 0);
			
		}
	}
}