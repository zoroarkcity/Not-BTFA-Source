using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Magnoliac
{
	public class BeechorangProj : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beech-orang");
        }
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 120;
			projectile.penetrate = -1;
			
			
		}
    }
}
