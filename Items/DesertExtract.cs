using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Items
{
	public class DesertExtract : GlobalItem
	{

		 public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
			if (Main.rand.Next(700) == 0 && extractType == 3347)
			{
				resultType = mod.ItemType("Fluctuate");
				resultStack = 1;
			}
			if (Main.rand.Next(300) == 0 && extractType == 3347)
			{
				resultType = mod.ItemType("Tourmaline");
				resultStack = 1;
			}
			if (Main.rand.Next(295) == 0 && extractType == 3347)
			{
				resultType = mod.ItemType("Citrine");
				resultStack = 1;
			}
        }
	}
}