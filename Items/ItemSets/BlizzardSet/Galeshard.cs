using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.ItemSets.BlizzardSet
{
	public class Galeshard : ModItem
	{
		public override void SetDefaults()
		{
			item.rare = 0;
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

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
			if (!Main.raining)
			{
			item.rare = 0;
			}
        }
    }
}
