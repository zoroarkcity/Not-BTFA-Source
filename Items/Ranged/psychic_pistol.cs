using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class psychic_pistol : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.ranged = true;

			item.width = 50;
			item.height = 50;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 70000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 11f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Psychic Pistol");
			Tooltip.SetDefault("Fires an additional bullet at the closest enemy");
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 move = Vector2.Zero;
			float distance = 1000f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Collision.CanHitLine(player.Center, 0, 0, Main.npc[k].Center, 0, 0) && Main.npc[k].type != 488)
				{
					Vector2 newMove = Main.npc[k].Center - player.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						newMove.Normalize();
						move = newMove * 11;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				Projectile.NewProjectile(position.X, position.Y, move.X, move.Y, type, damage, knockBack, player.whoAmI);
			}
			
			return true;
		}
	}
}
