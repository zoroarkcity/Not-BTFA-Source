using Terraria.ModLoader;

namespace ForgottenMemories.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ExoticBouquet : ModItem
	{
	    public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Exotic Boquet");
        Tooltip.SetDefault("'A collection of assorted jungle plants'");
		}		
		
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.rare = 2;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
            return true;   
        }
            public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
		}
	}
}
