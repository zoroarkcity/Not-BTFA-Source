using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class PermafrostStaff : ModItem
	{
		public override void SetDefaults()
		{
		item.CloneDefaults(ItemID.QueenSpiderStaff); 

			item.damage = 24;  
			item.mana = 15;   
			item.width = 40;
			item.height = 40;
			item.value = 16800;
			ProjectileID.Sets.TurretFeature[item.shoot] = true;
            item.rare = 2;
            item.knockBack = 2f;
			item.UseSound = SoundID.Item25;
            item.shoot = mod.ProjectileType("IceCrystal");
			item.shootSpeed = 0f;
			ProjectileID.Sets.MinionTargettingFeature[item.shoot] = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Permafrost Stave");
		  Tooltip.SetDefault("Summons a stationary Ice crystal");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}


		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int Damage, ref float knockBack)
		{
			//int num3 = sItem.type == 3571 ? 1 : (sItem.type == 3569 ? 1 : 0);
            int i1 = (int) ((double) Main.mouseX + Main.screenPosition.X) / 16;
            int j = (int) ((double) Main.mouseY + Main.screenPosition.Y) / 16;
            if ((double) player.gravDir == -1.0)
                j = (int) (Main.screenPosition.Y + (double) Main.screenHeight - (double) Main.mouseY) / 16;
            //if (num3 == 0)
            //{
            //    while (j < Main.maxTilesY - 10 && Main.tile[i1, j] != null && (!WorldGen.SolidTile2(i1, j) && Main.tile[i1 - 1, j] != null) && (!WorldGen.SolidTile2(i1 - 1, j) && Main.tile[i1 + 1, j] != null && !WorldGen.SolidTile2(i1 + 1, j)))
            //      ++j;
            //    --j;
            //}
            Projectile.NewProjectile((float) Main.mouseX + (float) Main.screenPosition.X, (float) (j * 16 - 24), 0.0f, 15f, type, Damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            player.UpdateMaxTurrets();
			return false;
        }
	}
}
