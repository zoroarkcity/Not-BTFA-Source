using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class BlizzardDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.5f;
			dust.frame = new Rectangle(0, 0, 6, 6);
			dust.noLight = true;
		}
		
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity / 4;
			dust.rotation += dust.velocity.X / 8;
			dust.scale -= 0.03f;
			if (dust.scale < 0.2f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}