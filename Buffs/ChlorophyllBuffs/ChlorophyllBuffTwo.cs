using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs.ChlorophyllBuffs
{
    public class ChlorophyllBuffTwo : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Chlorophyll II");
            Description.SetDefault("Increased life regeneration, movement speed and melee crit chance by 10%");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 2;
            player.moveSpeed *= 1.1f;
            player.meleeCrit += 10;
        }
    }
}