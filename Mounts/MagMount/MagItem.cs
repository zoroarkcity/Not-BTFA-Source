using Terraria.ModLoader;
using Terraria.ID;
 
namespace ForgottenMemories.Mounts.MagMount
{
    public class MagItem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 300;
            item.rare = 3;
			item.UseSound = SoundID.Item66;
            item.noMelee = true;
            item.mountType = mod.MountType("Mag_Mount");
        }  
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suspicious Looking Acorn");
			Tooltip.SetDefault("Summons a rideable Acorn Bomber that drops explosive acorns");
		}
    }
}