using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class Spiderbook : ModItem
	{
		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Bloodspider Sack");
        Tooltip.SetDefault("Shoots an empty blood egg sack");
		}		
        
		public override void SetDefaults()
		{
			item.damage = 15;
			item.magic = true;
			item.channel = true;
	        item.mana = 5;
			item.width = 32;
			item.height = 32;
            item.useAnimation = 22;
            item.useTime = 22;
            item.maxStack = 1;
			item.consumable = false;
            item.useStyle = 5;
            item.autoReuse = true;
            item.noMelee = true;
            item.knockBack = 7f;
            item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 2;
            item.UseSound = SoundID.Item17;
            item.shoot = mod.ProjectileType("Bloodspider");
            item.shootSpeed = 10f;
        }
	}
}
