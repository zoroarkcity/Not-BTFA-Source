using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt 
{
	public class ForestBlast : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 49;
			item.useAnimation = 49;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 27000;
			item.rare = 7;
			item.UseSound = SoundID.Item117;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LeafnadoFriendly");
			item.shootSpeed = 13f;
			item.mana = 15;

			item.noMelee = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Efflorescence");
		  Tooltip.SetDefault("Creates ghastly branches near your cursor's position");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int index = 0; index < 3; index++)
			{
				Vector2 Pos = new Vector2(0, 100).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 31))) + Main.MouseWorld;
				Vector2 Vel = Main.MouseWorld - Pos;
				Vel.Normalize();
				int p = Projectile.NewProjectile(Pos.X, Pos.Y, 0, 0, mod.ProjectileType("BranchBodyFriendly"), damage, knockBack, player.whoAmI, 0, 0);
				
				Main.projectile[p].rotation = (float) Math.Atan2((double) Vel.Y, (double) Vel.X) + 1.57f;
				Main.projectile[p].netUpdate = true;
			}
			return false;
		}
	}
}
