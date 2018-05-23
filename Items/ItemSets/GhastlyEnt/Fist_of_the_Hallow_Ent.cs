using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class Fist_of_the_Hallow_Ent : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fist of the Hollow Ent");
			Tooltip.SetDefault("Left-click to lob an explosive ball that will explode into cursed flames on impact\nRight-click to cast a cursed flameball that will leave cursed flame trails");
        }
		public override void SetDefaults()
		{
			item.damage = 60;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.ranged = true;
			item.value = 50000;
			item.width = 20;
			item.height = 20;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 2.15f;
			item.expert = true;
			item.UseSound = SoundID.Item45;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("Ball_of_the_Hallow_Ent");
		}
	
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
			item.noMelee = true;
			item.noUseGraphic = true;
			item.ranged = true;
			item.width = 1;
			item.height = 1;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 5.15f;
			item.expert = true;
			item.UseSound = SoundID.Item45;
			item.autoReuse = true;
			item.shootSpeed = 13f;
			item.shoot = mod.ProjectileType("Fireball_of_the_Hallow_Ent");
			}
			else
			{
			item.noMelee = true;
			item.noUseGraphic = true;
			item.ranged = true;
			item.width = 1;
			item.height = 1;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 2.15f;
			item.expert = true;
			item.UseSound = SoundID.Item45;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("Ball_of_the_Hallow_Ent");
			}	
			return base.CanUseItem(player);
		}
		public override void HoldItem (Player player)	
		{
			Vector2 vector2_1 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;
			if (player.direction != 1)
				vector2_1.X = (float) player.bodyFrame.Width - vector2_1.X;
			if ((double) player.gravDir != 1.0)
				vector2_1.Y = (float) player.bodyFrame.Height - vector2_1.Y;
			vector2_1 -= new Vector2((float) (player.bodyFrame.Width - player.width), (float) (player.bodyFrame.Height - 42)) / 2f;
			Vector2 vector2_2 = player.RotatedRelativePoint(player.position + vector2_1, true) - player.velocity;
			for (int index = 0; index < 4; ++index)
			{
				Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, 75, (float) (player.direction * 2), 0.0f, 150, new Color(), 1f)];
				dust.position = vector2_2;
				dust.velocity *= 0.0f;
				dust.noGravity = true;
				dust.fadeIn = 1f;
				dust.velocity += player.velocity;
				if (Main.rand.Next(2) == 0)
					dust.position += Utils.RandomVector2(Main.rand, -4f, 4f);
					dust.scale = 1f;
					if (Main.rand.Next(2) == 0)
						dust.customData = (object) player;
			}
		}
		
		public override void GetWeaponDamage(Player player, ref int damage)
		{
			damage = (int)((damage / player.rangedDamage)* player.thrownDamage);
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit = (crit - player.rangedCrit)+ player.thrownCrit;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " throwing " + damageWord;
			}
		}
		
		public override void UseStyle(Player player)
        {
            float cosRot = (float)Math.Cos(player.itemRotation - 0.78f * player.direction * player.gravDir);
            float sinRot = (float)Math.Sin(player.itemRotation - 0.78f * player.direction * player.gravDir);
            for (int i = 0; i < 1; i++)
            {
                float length = (item.width * 1.2f - i * item.width/9) * item.scale + 16; //length to base + arm displacement
                int dust = Dust.NewDust(new Vector2((float)(player.itemLocation.X + length * cosRot * player.direction),(float)(player.itemLocation.Y + length * sinRot * player.direction)), 0, 0, 75,player.velocity.X * 0.9f,player.velocity.Y * 0.9f, 100, Color.Transparent, 1f);
                Main.dust[dust].velocity *= 0.3f;
				Main.dust[dust].scale = 1f;
                Main.dust[dust].noGravity = true;
            }
        }
	}
}
