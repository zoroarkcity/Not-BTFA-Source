using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.Summon
{
	public class MechanicsHammer : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.QueenSpiderStaff); 
			ProjectileID.Sets.TurretFeature[item.shoot] = true;	
			item.damage = 20;  
			item.mana = 13;   
			item.width = 40;
			item.height = 40;
			item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
			item.rare = 3;
			item.knockBack = 2.5f;
			item.UseSound = SoundID.Item25;


			item.shoot = mod.ProjectileType("MechanicalTurret");
			item.shootSpeed = 0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanics Hammer");
			Tooltip.SetDefault("Summons a stationary Turret");
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
