using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class EventideDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.scale *= 0.5f;
			dust.alpha = 200;
			dust.frame = new Rectangle(0, 0, 6, 6);
		}
		
		public override bool Update(Dust dust)
		{
            float num2 = dust.scale * 0.6f;
			Lighting.AddLight((int) ((double) dust.position.X), (int) ((double) dust.position.Y), num2 * 0.3f, num2 * 0.7f, num2 * 0f);
			
			return true;
		}
	}
}