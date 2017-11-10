using Terraria.ModLoader;

namespace ForgottenMemories.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ArteryMask : ModItem
	{
	    public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Arterius Mask");
        Tooltip.SetDefault("");
		}		
		
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.rare = 1;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
            return true;   
        }
            public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
		}
	}
}
