﻿using System;
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
	public class Crabapples : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hyperactive");
			Description.SetDefault("I'm not buying you that drink again: its bad for you");
			Main.buffNoTimeDisplay[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
            player.noFallDmg = true;
            player.statLifeMax2 = 9999999;
            player.statManaMax2 = 9999999;
			player.lifeRegen = 999999;
            player.manaCost = 0f;
            player.maxMinions = 999999;
		}
	}
}