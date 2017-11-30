
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class ItemTweaks : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.Acorn:
					item.ranged = true;
					item.ammo = item.type;
					item.consumable = true;
					item.maxStack = 999;
					break;
			}
		}
	}
}
