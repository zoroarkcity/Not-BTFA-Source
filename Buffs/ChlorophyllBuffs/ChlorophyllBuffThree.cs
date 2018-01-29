using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs.ChlorophyllBuffs
{
    public class ChlorophyllBuffThree : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Chlorophyll III");
            Description.SetDefault("Increased life regeneration, movement speed and melee crit chance by 15%");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 3;
            player.moveSpeed *= 1.15f;
            player.meleeCrit += 15;
        }
    }
}