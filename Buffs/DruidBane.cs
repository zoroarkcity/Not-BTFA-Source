using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class DruidBane : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Druidic Bane");
			Description.SetDefault("Losing life rapidly and lowered stats");
			Main.buffNoTimeDisplay[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen -= 20;
			
			player.magicDamage -= 0.1f;
			player.meleeDamage -= 0.1f;
			player.rangedDamage -= 0.1f;
			player.minionDamage -= 0.1f;
			player.thrownDamage -= 0.1f;
			player.moveSpeed -= 0.35f;
			player.endurance -= 0.1f;
			
			if (Main.rand.Next(5) == 0)
			{
				int num5 = Dust.NewDust(player.position, player.width, player.height, 163, 0f, 0f, 163, default(Color), 0.5f);
				Main.dust[num5].noGravity = true;
				Main.dust[num5].velocity *= 0.75f;
				Main.dust[num5].fadeIn = 1.3f;
				Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
				vector.Normalize();
				vector *= (float)Main.rand.Next(50, 100) * 0.04f;
				Main.dust[num5].velocity = vector;
				vector.Normalize();
				vector *= 34f;
				Main.dust[num5].position = player.Center - vector;
			}
		}
	}
}