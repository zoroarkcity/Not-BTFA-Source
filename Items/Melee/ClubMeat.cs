using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubMeat : ModItem
	{
		public override void SetDefaults()
		{


			item.damage = 66; 
			item.crit = 6;
			item.melee = true;
			item.knockBack = 10; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 56;
			item.useAnimation = 56;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 50000;
			item.rare = 4;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Basher");
			Tooltip.SetDefault("'It chews on your foes' \nMakes enemies bleed out, dealing constant damage");
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Bleeding"), 580, false);
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(target.position, target.width, target.height, 5);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
