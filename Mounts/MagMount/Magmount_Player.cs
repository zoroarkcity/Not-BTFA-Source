using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace ForgottenMemories.Mounts.MagMount
{
	public class Magmount_Player : ModPlayer
    {
		protected bool hasProjectile = false;
		public override void PostUpdate()
		{
			if (player.HasBuff(mod.BuffType("MagBuff")) && (Main.rand.Next(50)==0))
			{
			   Main.PlaySound(SoundID.Item17, 0);
		       Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 10f, mod.ProjectileType("MountAcorn"), 30, 0f, player.whoAmI, 0f, 0f);			   
			}
		}
	}
	
}