using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Dusts
{
	public class BigUndeadDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 0.8f;
			dust.frame = new Rectangle(0, 0, 13, 13);
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
			else
			{
				float strength = dust.scale / 2f;
				Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.3f, 0.1f, 0f);
			}
			return false;
		}
	}
}