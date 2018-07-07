using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.ItemSets.BlizzardSet
{
	public class Galeshard : ModItem
	{
		int timeLeft = 600;
		public override void SetDefaults()
		{


			item.rare = 1;
            item.width = item.height = 38;
            item.maxStack = 999;
            ItemID.Sets.ItemNoGravity[item.type] = true;
           // ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Blizzard Shard");
		  Tooltip.SetDefault("'As icy as death's stare'");
		  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
		}

        
		
		public override void PostUpdate()
		{
			if (!Main.raining)
			{
				timeLeft--;
				if (timeLeft < 0)
				{
					item.TurnToAir();
					for (int i = 0; i < 15; i++)
					{
						Dust.NewDust(item.position, item.width, item.height, mod.DustType("BlizzardDust"), 0, 0);
					}
				}
			}
		}
    }
}
