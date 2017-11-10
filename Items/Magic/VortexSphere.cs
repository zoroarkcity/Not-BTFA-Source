using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Magic 
{
	public class VortexSphere : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 126;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 500000;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;

			item.shoot = mod.ProjectileType("LightningSphere");
			item.shootSpeed = 5f;
			item.mana = 45;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Lightning Sphere");
      Tooltip.SetDefault("Summons an orb of electricity that shoots lightning at nearby enemies");
    }

	}
}
