using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Melee
{
	public class ProtectorStab : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 16;
			item.useAnimation = 16;
			item.crit = 16;
			item.useStyle = 3;
			item.knockBack = 3;
			item.value = 60000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Protector's Stab");
		  Tooltip.SetDefault("Critical hits boost the defense of you and nearby allies");
		}

		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			if (crit == true)
			{
				player.AddBuff(mod.BuffType("Graniteskin"), 8 * 60);
				for (int i = 0; i <= Main.player.Length; i++)
				{
					Player playerI = Main.player[i];
					if (playerI.team == player.team && playerI.team != 0)
					{
						float num1 = player.Distance(playerI.Center);
						bool flag3 = (double) num1 < 800.0;
						if (flag3)
						{
							playerI.AddBuff(mod.BuffType("Graniteskin"), 8 * 60);
						}
					}
				}
			}
        }
	}
}
