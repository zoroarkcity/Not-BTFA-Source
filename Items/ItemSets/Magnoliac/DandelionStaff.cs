using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Chat;
 
namespace ForgottenMemories.Items.ItemSets.Magnoliac        //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class dandelionstaff : ModItem
    {
		public override void SetDefaults()
		{

			item.damage = 20;
			item.noMelee = true;
			item.noUseGraphic = false;
			item.magic = true;
			item.scale = 1f;
			item.width = 40;
			item.height = 40;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 3.15f;

			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.rare = 2;
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shootSpeed = 7f;
			item.mana = 8;
			item.shoot = mod.ProjectileType("DandelionStaffProj");
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Verdure");
            Tooltip.SetDefault("Casts a damaging poison ball.");
        }
    }
}
