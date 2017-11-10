using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class VileCloud1 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(511);
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vile Cloud");
		}
	}
}