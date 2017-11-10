using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class ShroomCloud : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(511);
			projectile.friendly = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Cloud");
		}
	}
}