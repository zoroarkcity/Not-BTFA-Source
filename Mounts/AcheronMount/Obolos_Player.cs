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

namespace ForgottenMemories.Mounts.AcheronMount
{
	public class Obolos_Player : ModPlayer
    {
		protected bool hasProjectile = false;
		public override void PostUpdate()
		{
			if (player.HasBuff(mod.BuffType("Obolos_Buff")))
			{
				//idk what to do here
			}
		}
	}
	
}