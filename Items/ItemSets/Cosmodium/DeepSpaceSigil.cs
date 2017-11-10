using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;
namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class DeepSpaceSigil : ModItem
	{
		public override void SetDefaults()
		{	


            item.width = 24;
            item.height = 28;
            item.value = 50000;
            item.rare = 11;
            item.useStyle = 1;
            item.useTime = 80;
            item.useAnimation = 80;
            item.UseSound = SoundID.Item119;
            item.useTurn = true;
            item.autoReuse = false;
            item.consumable = true;
            item.maxStack = 999;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Deep space sigil");
      Tooltip.SetDefault("'A lot of cosmic energy is fluxuating inside'");
    }

        public override bool UseItem(Player player)
        {
            AscensionWorld.DropComet();
            return true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 3);
			recipe.AddIngredient(ItemID.FragmentVortex, 3);
			recipe.AddIngredient(ItemID.FragmentSolar, 3);
			recipe.AddIngredient(ItemID.FragmentStardust, 3);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(null, "SpaceRockFragment", 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
