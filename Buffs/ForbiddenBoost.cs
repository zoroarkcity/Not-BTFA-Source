using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class ForbiddenBoost : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Forbidden Boon");
			Description.SetDefault("Power at a cost");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
			player.lifeRegen = 0;
			player.lifeRegen -= 8;
			player.manaRegen *= 2;
			player.magicDamage += 0.10f;
			player.endurance -= 0.3f;
		}
	}
}