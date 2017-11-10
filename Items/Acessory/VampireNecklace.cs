using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class VampireNecklace : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

        item.value = 100000;
        item.rare = 5;
		item.expert = true;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vampire Necklace");
      Tooltip.SetDefault("Gives you a chance to steal life on enemy hit, increased armor penetration");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).lifesteal = true;
		player.armorPenetration += 8;
	}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "BloodHeart");
        recipe.AddIngredient(ItemID.SharkToothNecklace);
		recipe.AddIngredient(ItemID.SoulofMight, 10);
		recipe.AddIngredient(ItemID.SoulofFright, 10);
		recipe.AddIngredient(ItemID.SoulofSight, 10);
        recipe.AddTile(114);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
