using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Woodlice : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Woodlouse");
			Description.SetDefault("It decimates your rivals!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("WoodlouseMinion")] > 0)
			{
				modPlayer.WoodlouseMinion = true;
			}
			if (!modPlayer.WoodlouseMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}