using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Bjorn
{
	public class BjornLichen : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 14;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 240;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lichen");
		}
	}
}