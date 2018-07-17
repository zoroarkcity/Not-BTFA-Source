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

namespace ForgottenMemories
{
	public class WhirlingWorldsPlayer : ModPlayer
    {
		public bool hasProjectile = false;	
		public bool hasProjectile2 = false;	
		public bool hasProjectile3 = false;	
		public bool hasProjectile4 = false;	
		public bool Quagmire = false;	
		public bool energazerHelm = false;	
		public bool energazerVisor = false;	
		public int liberMortisCount = 1;		
		public int navitasOrbisCounter = 1;	
		public int SerratedDaggerProjectileCount = 0;	
		public int StaticShivProjectileCount = 0;	
		public int EncrestedWandProjectileCount = 1;	
	
		public override void OnEnterWorld (Player player)
		{
			SerratedDaggerProjectileCount = 0;
			EncrestedWandProjectileCount = 1;
			liberMortisCount = 1;
		}	
		public override float UseTimeMultiplier (Item item)
        {
			if (energazerHelm && Main.LocalPlayer.FindBuffIndex(mod.BuffType("Phantom_Reap_Buff")) > -1 && player.HeldItem.type == mod.ItemType("Phantom_Reap"))
			{
				return 2.1f;
			}
			if (energazerVisor)
			{
				return 0.9f;
			}
			if (energazerHelm)
			{
				return 1.1f;
			}
			if (energazerVisor && Main.LocalPlayer.FindBuffIndex(mod.BuffType("Phantom_Reap_Buff")) > -1 && player.HeldItem.type == mod.ItemType("Phantom_Reap"))
			{
				return 1.9f;
			}
			if (Main.LocalPlayer.FindBuffIndex(mod.BuffType("Phantom_Reap_Buff")) > -1 && player.HeldItem.type == mod.ItemType("Phantom_Reap"))
			{
				return 2f;
			}
            return 1f;			
		}
	}
}