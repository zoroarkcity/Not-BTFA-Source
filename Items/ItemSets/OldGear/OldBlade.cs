using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.OldGear
{
	public class OldBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 8;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.useTime = 22;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 10;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ancient Blade");
      Tooltip.SetDefault("");
    }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 11);
				Main.dust[dust2].scale = 1.2f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}
}
