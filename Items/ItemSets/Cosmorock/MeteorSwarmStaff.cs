using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class MeteorSwarmStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 92;
			item.magic = true;

			item.width = 50;
			item.height = 50;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 800000;
			item.rare = 10;
			item.mana = 10;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CosmorockLaser");
			item.shootSpeed = 13f;
			item.noMelee = true;
			Item.staff[item.type] = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Meteor Swarm Staff");
      Tooltip.SetDefault("Showers down defense-lowering meteors and comet shards");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int num8 = 2;
			for (int index = 0; index < num8; ++index)
			{
				Vector2 vector2_1 = new Vector2((float) ((double) player.position.X + (double) player.width * 0.5 + (double) (Main.rand.Next(201) * -player.direction) + ((double) Main.mouseX + (double) Main.screenPosition.X - (double) player.position.X)), player.MountedCenter.Y - 600f);
				vector2_1.X = (float) (((double) vector2_1.X + (double) player.Center.X) / 2.0) + (float) Main.rand.Next(-200, 201);
				vector2_1.Y -= (float) (100 * index);
				float num9 = (float) ((double) Main.mouseX + (double) Main.screenPosition.X - (double) vector2_1.X + (double) Main.rand.Next(-40, 41) * 0.0299999993294477);
				float num10 = (float) Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if ((double) num10 < 0.0)
				num10 *= -1f;
				if ((double) num10 < 20.0)
				num10 = 20f;
				float num11 = (float) Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
				float num12 = item.shootSpeed / num11;
				float num13 = num9 * num12;
				float num14 = num10 * num12;
				float num15 = num13;
				float num16 = num14 + (float) Main.rand.Next(-40, 41) * 0.02f;
				int mememaster = Projectile.NewProjectile(vector2_1.X, vector2_1.Y, num15 * 0.75f, num16 * 0.75f, mod.ProjectileType("CometShard") + Main.rand.Next(2), damage, knockBack, player.whoAmI, 0.0f, (float) (0.5 + Main.rand.NextDouble() * 0.300000011920929));
				Main.projectile[mememaster].timeLeft = 360;
				Main.projectile[mememaster].melee = false;
				Main.projectile[mememaster].ranged = false;
				Main.projectile[mememaster].magic = true;
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 18);
			recipe.AddIngredient(ItemID.MeteorStaff, 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
