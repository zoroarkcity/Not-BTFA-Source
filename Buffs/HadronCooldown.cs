using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class HadronCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Hadron Cooldown");
			Description.SetDefault("Your missile barrage is reloading");
			Main.debuff[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).hadron = true;
		}
	}
}