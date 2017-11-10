using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence
{
    public class NightlyDaggerP : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(3);
            projectile.width = 9;
            projectile.height = 9;
            projectile.penetrate = 1;
            aiType = 3;
            projectile.ignoreWater = true;
            projectile.timeLeft = 6000;
        }
		
		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Nightly Dagger");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 65, 0f, 0f);
			}
		}


			public override void Kill(int timeLeft)
			{
				int num = Main.rand.Next(3, 7);
				for (int index1 = 0; index1 < num; ++index1)
				{
					int index2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 65, 0f, 0f);
					Dust dust = Main.dust[index2];
					Main.dust[index2].noGravity = true;
				}
				Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			}
        }

        public class NightlyDagger : ModItem
		{

            public override void SetDefaults()
            {
                item.CloneDefaults(ItemID.Shuriken);
				item.shoot = mod.ProjectileType("NightlyDaggerP");
				item.damage = 11;
				item.autoReuse = true;
				item.useTime = 17;
				item.useAnimation = 17;
				item.rare = 1;
				item.maxStack = 999;
				
			}
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nightly Dagger");
      Tooltip.SetDefault("");
    }


            public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DarkEnergy", 1);
			recipe.AddIngredient(ItemID.Silk, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
        }
    }
