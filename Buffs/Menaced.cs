using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Menaced : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Menaced");
			Description.SetDefault("You are drowning in darkness");
			Main.buffNoTimeDisplay[Type] = true;
			Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<BTFAPlayer>(mod).spookedByArte = true;
		}
	}
}