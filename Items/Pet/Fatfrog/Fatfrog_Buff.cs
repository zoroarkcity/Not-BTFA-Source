using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet.Fatfrog
{
	public class Fatfrog_Buff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fatfrog");
			Description.SetDefault("An overweight frog is following you, seems chill...");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<BTFAPlayer>(mod).Frog = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Fatfrog")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Fatfrog"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}