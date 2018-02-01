using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ForgottenMemories;

namespace ForgottenMemories.Items
{
	public class ManaShard : GlobalItem
	{
		public override bool OnPickup(Item item, Player player)
		{
			if (item.type == 184 && ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).ManaShard == true)
			{
				player.AddBuff(mod.BuffType("ManaBoost"), 360);
				Main.PlaySound(7, (int) player.position.X, (int) player.position.Y, 1, 1f, 0.0f);
                player.statMana = player.statMana + 150;
                if (Main.myPlayer == player.whoAmI)
					player.ManaEffect(150);
                if (player.statMana > player.statManaMax2)
					player.statMana = player.statManaMax2;
                //Main.item[number] = new Item();
                if (Main.netMode == 1)
					NetMessage.SendData(21, -1, -1, (NetworkText) null, item.whoAmI, 0.0f, 0.0f, 0.0f, 0, 0, 0);
				return false;
			}
			return base.OnPickup(item, player);
		}
	}
}