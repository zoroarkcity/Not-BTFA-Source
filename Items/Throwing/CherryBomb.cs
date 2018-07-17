using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Throwing
{
	public class CherryBomb : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 72;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.width = 22;
			item.height = 22;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("CherryBomb");
			item.knockBack = 1;
			item.scale = 1f;
			item.value = 25;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.maxStack = 999;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cherry Bomb");
      Tooltip.SetDefault("'Doesn't go down very well in a cherry pie'");
    }

	}}
