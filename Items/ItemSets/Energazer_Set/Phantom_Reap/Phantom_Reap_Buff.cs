using System.Collections.Generic;
using Terraria;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Energazer_Set.Phantom_Reap
{
    public class Phantom_Reap_Buff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false; 
            Main.pvpBuff[Type] = false; 
            Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Soul Absorber");
			Description.SetDefault("Your attack and movement speed is increased");
        }
		public override void Update(Player player, ref int buffIndex)
        {
			player.moveSpeed = player.moveSpeed * 2f;
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				Vector2 position = player.Center;
				dust = Main.dust[Terraria.Dust.NewDust(position, player.width, player.height, 111, 0f, 10f, 150, new Color(255,255,255), 1.052632f)];
				dust.noGravity = true;
				dust.noLight = true;
			}
        }
    }
}