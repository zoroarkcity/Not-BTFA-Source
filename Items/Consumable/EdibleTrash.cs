using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
	public class EdibleTrash : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Edible Trash");
			Tooltip.SetDefault("Has a chance to inflict poison for 20 seconds");
		}

		public override void SetDefaults()
		{
			item.buffType = BuffID.WellFed;
			item.width = 20;
			item.height = 10;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.buffTime = 54000;
			item.UseSound = SoundID.Item2;
			item.useTime = 10;
			item.useAnimation = 10;
			item.consumable = true;
			item.value = 1000;
			item.rare = -1;
			item.maxStack = 999;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0 && Main.rand.Next(3) == 0)
			{
				player.AddBuff(20, 600, true);
			}
		}
	}
}
