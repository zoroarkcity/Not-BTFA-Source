using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class BloodDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.scale *= 0.5f;
			dust.frame = new Rectangle(0, 0, 10, 10);
		}
		
		public override bool Update(Dust dust)
		{
            float num2 = dust.scale * 0.6f;
			
			Lighting.AddLight((int) ((double) dust.position.X), (int) ((double) dust.position.Y), num2 * 1.68f, num2 * 0.08f, num2 * 0.67f);
			
			return true;
		}
	}
}