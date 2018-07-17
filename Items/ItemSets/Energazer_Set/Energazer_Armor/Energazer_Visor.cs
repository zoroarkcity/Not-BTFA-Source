using System.Collections.Generic;
using Terraria;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Energazer_Set.Energazer_Armor
{
	[AutoloadEquip(EquipType.Head)]
	
    public class Energazer_Visor : ModItem
    {
		protected bool hasTheVisual = false;
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.value = 12000;
            item.rare = 2;
            item.defense = 9;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energazer Galeati");
			Tooltip.SetDefault("10% decreased weapon haste\n5% increased magic damage");
			//WhirlingWorldsGlowmask.AddGlowMask(item.type, "WhirlingWorlds/Items/Sets/Energazer_Set/Energazer_Armor/Energazer_Visor_Glow");
		}
        public override void UpdateEquip(Player player)
        {
			player.GetModPlayer<WhirlingWorldsPlayer>().energazerVisor = true;
			player.magicDamage += 0.05f;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("Energazer_Chestplate") && legs.type == mod.ItemType("Energazer_Leggings");
        }
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMaskColor = Color.White;
        }
        public override void UpdateArmorSet(Player player)
        {
			player.setBonus = ("Enemies within 10 block range deal 15% decreased damage");
			for(int k = 0; k < Main.projectile.Length; k++)
			{
				int type2 = Main.projectile[k].type;
				if(type2 != mod.ProjectileType("Energy_Armor_Visual") && !Main.projectile[k].active)
				{
					hasTheVisual = false;
				}
				else if(type2 == mod.ProjectileType("Energy_Armor_Visual") && Main.projectile[k].active)
				{
					hasTheVisual = true;
					break;
				}
			}
			
				if(!hasTheVisual)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Energy_Armor_Visual"), 0, 0, player.whoAmI);
				}
        }
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = drawAltHair = false;  
        }
		public override bool DrawHead()
        {
            return false;   
        }
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Energy_Remnant", 5);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
