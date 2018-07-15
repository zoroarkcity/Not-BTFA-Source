using System.Collections.Generic;
using Terraria;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Barksteel_Smash 
{
    public class TribesmanTag : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true; 
            Main.pvpBuff[Type] = false; 
            Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Tribesman's Tag");
			Description.SetDefault("Damage inflicted gets tripled");
        }
		
        public override void Update(NPC npc, ref int buffIndex)
        {
                for (int index1 = 0; index1 < 1; ++index1)
                {
                    int index2 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X * 2f, (float) ((double) npc.position.Y - 2.0 - (double) npc.velocity.Y * 2.0)), npc.width, npc.height, 90, 0.0f, 0.0f, 100, new Color(), 2f);
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].velocity.X -= npc.velocity.X * 0.5f;
                    Main.dust[index2].velocity.Y = 0f;
                    Main.dust[index2].scale = 1f;
                }
			
			int type = mod.BuffType("TribesmanTag");
            float num1 = 200f;
            for (int index2 = 0; index2 < 200; ++index2)
            {
				if (npc.FindBuffIndex(mod.BuffType("TribesmanTag")) > -1)
				{
					NPC target = Main.npc[index2];
					if (npc.active && !npc.friendly && (npc.damage > 0 && !npc.dontTakeDamage) && (!npc.buffImmune[type] && (double) Vector2.Distance(target.Center, npc.Center) <= (double) num1) && Main.rand.Next(400) == 0)
					{
						target.AddBuff(31, 180, false);
					}
				}
            }
        }
    }
}