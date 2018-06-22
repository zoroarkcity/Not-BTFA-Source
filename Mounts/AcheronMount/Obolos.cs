using Terraria.ModLoader;
using Terraria.ID;
 
namespace ForgottenMemories.Mounts.AcheronMount
{
    public class Obolos : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 300;
            item.rare = 4;
			item.UseSound = SoundID.Item106;
            item.noMelee = true;
            item.mountType = mod.MountType("Obolos_Mount");
        }  
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obolos");
			Tooltip.SetDefault("Summons a rideable Ethereal Boat for you to sail");
		}
    }
}