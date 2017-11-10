using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
    public class FourthEye : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 42;
            item.magic = true;
            item.mana = 8;
            item.width = 16;
            item.height = 17;
			item.noUseGraphic = true;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 54000;
            item.rare = 5;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LaserBolt");
            item.shootSpeed = 14f;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("The Fourth Eye");
		  Tooltip.SetDefault("'Predicts the location of enemies and exterminates them'");
		}


        public override void HoldItem(Player player)
        {
            player.AddBuff(BuffID.Hunter, 2);
			
			Vector2 vector2_1 = (Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f);
			if (player.direction != 1)
			  vector2_1.X = ((float) player.bodyFrame.Width - vector2_1.X);
			if ((double) player.gravDir != 1.0)
			  vector2_1.Y = ((float) player.bodyFrame.Height - vector2_1.Y);
			Vector2 vector2_2 = (player.RotatedRelativePoint((player.position + (vector2_1 - (new Vector2((float) (player.bodyFrame.Width - player.width), (float) (player.bodyFrame.Height - 42)) / 2f)))) - player.velocity);
			for (int index = 0; index < 4; ++index)
			{
				Dust dust1 = Main.dust[Dust.NewDust(player.Center, 0, 0, 60, (float) (player.direction * 2), 0.0f, 150, new Color(), 1.3f)];
				dust1.position = vector2_2;
				Dust dust2 = dust1;
				dust2.velocity = Vector2.Zero;
				dust1.noGravity = true;
				dust1.fadeIn = 1f;
				Dust dust3 = dust1;
				Vector2 vector2_4 = (dust3.velocity + player.velocity);
				dust3.velocity = vector2_4;
				if (Main.rand.Next(2) == 0)
				{
					Dust dust4 = dust1;
					Vector2 vector2_5 = (dust4.position + Utils.RandomVector2(Main.rand, -4f, 4f));
					dust4.position = vector2_5;
					dust1.scale += Main.rand.NextFloat();
					if (Main.rand.Next(2) == 0)
						dust1.customData = player.whoAmI;
				}
			}
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.Next(2) == 0)
			{
				type = mod.ProjectileType("CurseBolt");
			}
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThirdEye", 1);
			recipe.AddIngredient(ItemID.BlackLens, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
