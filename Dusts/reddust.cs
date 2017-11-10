using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class reddust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale = 1f;
			dust.frame = new Rectangle(0, 0, 10, 10);
		}
	}
}