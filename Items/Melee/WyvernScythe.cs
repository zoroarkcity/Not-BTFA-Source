using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee
{
	public class WyvernScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 74;
			item.melee = true;
			item.width = 58;
			item.height = 52;

			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6.5f;
			item.value = 138000;
			item.rare = 6;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.shoot = 85;
			item.shootSpeed = 9f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wyvern Scythe");
      Tooltip.SetDefault("Creates short-ranged fire breath that ignores tiles");
    }

		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int amountOfProjectiles = Main.rand.Next(2, 4);
			for (int i = 0; i < amountOfProjectiles; i++)
			{
				float spX = speedX;
				float spY = speedY;
				spX += (float)Main.rand.Next(-40, 41) * 0.1f;
				spY += (float)Main.rand.Next(-40, 41) * 0.1f;
				int p = Projectile.NewProjectile(position.X, position.Y, spX, spY, 85, damage, knockBack, player.whoAmI);
				Main.projectile[p].tileCollide = false;
				Main.projectile[p].timeLeft = 25;
				Main.projectile[p].ranged = false;
				Main.projectile[p].melee = true;
			}
			return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFlight, 15);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
