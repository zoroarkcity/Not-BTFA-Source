using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee
{
	public class ProtectorStab : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 16;
			item.useAnimation = 16;
			item.crit = 16;
			item.useStyle = 3;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 25, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Unstable Gladius");
		  Tooltip.SetDefault("Critical hits boost the defense of you and nearby allies");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/ProtectorStab");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/ProtectorStab"),
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
		}////////////

		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			if (crit == true)
			{
				player.AddBuff(mod.BuffType("Graniteskin"), 8 * 60);
				for (int i = 0; i <= byte.MaxValue; i++)
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
