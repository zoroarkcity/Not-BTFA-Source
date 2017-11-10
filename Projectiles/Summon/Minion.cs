using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Summon
{
	//copy-pasted from examplemod
	public abstract class Minion : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
			Behavior();
		}

		public abstract void CheckActive();

		public abstract void Behavior();
	}
}