using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs.ChlorophyllBuffs
{
    public class ChlorophyllBuffOne : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Chlorophyll I");
			Description.SetDefault("Increased life regeneration, movement speed and melee crit chance by 5%");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 1;
            player.moveSpeed *= 1.05f;
            player.meleeCrit += 5;
        }
    }
}