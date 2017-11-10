using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.TileItems
{
    public class CryotineOreItem : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 16; 
			item.height = 14;
            item.maxStack = 999;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 6000;
            item.rare = 2;
			item.consumable = true;
			item.autoReuse = true;
            item.createTile = mod.TileType("CryotineOre");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Ore");
      Tooltip.SetDefault("");
    }

    }
}
