using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Acheron
{
	public class AcheronMirror : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.WormholePotion);
			item.maxStack = 1;
			item.UseSound = SoundID.Item33;
			item.rare = 4;
		    item.consumable = false;
			item.UseSound = SoundID.Item125;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Eldritch Mirror");
      Tooltip.SetDefault("Teleports you to a party member \nClick their head on the fullscreen minimap \nNot consumable");
    }
	}
}
