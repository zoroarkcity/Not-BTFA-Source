using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	[AutoloadEquip(EquipType.Head)]
	public class AquaticAHelm : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 50000;
			item.rare = 3;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aquatic Helmet");
			Tooltip.SetDefault("7% increased melee damage, increased life by 25");
		}
		
		public override bool DrawHead()	
		{
			return false;
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AquaticChestplate") && legs.type == mod.ItemType("AquaticGreaves");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.07f;
			player.statLifeMax2 += 25;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Passively creates bubbles";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).AquaPowers = true;
			if ((double) Math.Abs(player.velocity.X) + (double) Math.Abs(player.velocity.Y) > 1.0 && !player.rocketFrame)
            		{
                		for (int index1 = 0; index1 < 1; ++index1)
                		{
                   			 int index2 = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, (float) ((double) player.position.Y - 2.0 - (double) player.velocity.Y * 2.0)), player.width, player.height, 33, 0.0f, 0.0f, 100, new Color(), 2f);
                   			 Main.dust[index2].noGravity = true;
                    			 Main.dust[index2].noLight = true;
                   			 Main.dust[index2].velocity.X -= player.velocity.X * 0.5f;
                   			 Main.dust[index2].velocity.Y = 0f;
                   			 Main.dust[index2].scale = 1f;
                		}
            		}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 7);
			recipe.AddIngredient(ItemID.SharkFin, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
