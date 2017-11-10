using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.TileItems
{
    public class BlightOreItem : ModItem
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
            item.value = 4000;
            item.rare = 4;
			item.consumable = true;
			item.autoReuse = true;
            item.createTile = mod.TileType("BlightOre");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blightstone Ore");
      Tooltip.SetDefault("");
    }

    }
}
