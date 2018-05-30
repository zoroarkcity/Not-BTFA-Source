using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet.Chicken
{
	public class ChickenGiant : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Chicken"); 
			Main.projFrames[projectile.type] = 13;
			Main.projPet[projectile.type] = true;
			projectile.tileCollide = true;
			projectile.width = 25;
			projectile.height = 27;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BabyDino);
			aiType = ProjectileID.BabyDino;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
		    //player.BabyDino = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (Main.player[projectile.owner].dead)
				projectile.Kill();
			if (Main.myPlayer == projectile.owner && modPlayer.Chicken)
			  projectile.timeLeft = 2;
	    }
	}
}