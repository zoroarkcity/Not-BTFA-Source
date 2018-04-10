using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Hematohidrosis : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hematohidrosis");
			Description.SetDefault("Your blood is seeping away");
			Main.debuff[Type] = true;
            //Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = true;
		}
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (Main.rand.Next(10) == 0)
            {
                Vector2 position = npc.position + new Vector2(Main.rand.Next(npc.width), Main.rand.Next(npc.height));
				int p = Projectile.NewProjectile(position.X, position.Y, 0, 0, mod.ProjectileType("SeepingBlood"), 20, 0, Main.myPlayer, npc.whoAmI);
				Main.projectile[p].scale = 0.5f + (float) Main.rand.Next(76) / 100;
            }
            Lighting.AddLight(npc.position, 0.5f, 0, 0);
        }
	}
}
