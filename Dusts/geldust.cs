using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class geldust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.scale *= 1.5f;
			dust.frame = new Rectangle(0, 0, 10, 10);
		}
	}
}