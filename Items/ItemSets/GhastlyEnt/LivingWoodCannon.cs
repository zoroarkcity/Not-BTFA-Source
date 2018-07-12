using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt {
public class LivingWoodCannon : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 33;
        item.ranged = true;
        item.width = 34;
        item.height = 26;
        item.useTime = 12;
        item.useAnimation = 36;
		item.reuseDelay = 55;
		item.UseSound = SoundID.Item38;
        item.useStyle = 5;
        item.knockBack = 3;
        item.value = 27000;
        item.rare = 3;
        item.autoReuse = true;

        item.shoot = mod.ProjectileType("wooballF"); 
		item.shootSpeed = 11f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Living Wood Cannon");
      Tooltip.SetDefault("Fires explosive seeds \nDoes not consume ammo");
    }
	
	public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, -2);
		}
}}
