using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet.Chicken
{
	public class Chicken : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Giant Chicken");
			Description.SetDefault("It smells");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<BTFAPlayer>(mod).Chicken = true;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("ChickenGiant")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("ChickenGiant"), 0, 0f, player.whoAmI, 0f, 0f);
			}

		}
	}
}