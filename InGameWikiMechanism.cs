using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;

namespace ForgottenMemories
{
    public class InGameWikiMechanism : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BTFA Pokedex");
        } 
        public override void SetDefaults()
        {
            projectile.width = 75; 
            projectile.height = 75; 
            projectile.aiStyle = 1;
            projectile.tileCollide = false; 
            aiType = ProjectileID.Bullet;
			projectile.timeLeft = 1;
            projectile.scale = 0f;			
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			{
			    projectile.active = true;
		    }
			return false;
        }
        public override void AI()
        {
			if (Main.LocalPlayer.FindBuffIndex(mod.BuffType("Educating")) > -1)
			{
				projectile.active = true;
			}
			else
			{
				projectile.active = false;
			}
			
            Player player = Main.player[projectile.owner];
			
			if (player == Main.player[Main.myPlayer])
            {
                for (int index2 = 0; index2 < 200; ++index2)
				{
                    NPC npc = Main.npc[index2];
                    if ((double) Vector2.Distance(projectile.Center, npc.Center) <= (double) 13f)
                    {
						if (npc.type == mod.NPCType("AcheronBarrier"))
			            {
				            Main.NewText("Barrier Wisp", 255, 255, 0);
				            Main.NewText("Orbits around Acheron, destroys projectiles. Explodes when Acheron dies.", 255, 255, 255);
							projectile.Kill();
						}
						
						if (npc.type == mod.NPCType("AcheronGhost"))
			            {
				            Main.NewText("Lost Soul", 255, 255, 0);
				            Main.NewText("Tries to dash into the player, explodes when hit.", 255, 255, 255);
							projectile.Kill();
						}
						
						if (npc.type == mod.NPCType("NightlyWisp"))
			            {
				            Main.NewText("Nightly Wisp", 255, 255, 0);
				            Main.NewText("Spawns on the surface during night, despawns when sun rises", 255, 255, 255);
				            Main.NewText("Drop Table", 255, 255, 0);
				            Main.NewText(string.Format("[i:{0}]", mod.ItemType<Items.AaMaterials.DarkEnergy>()), 0, 0, 0);
							projectile.Kill();
						}
						
						if (npc.type == mod.NPCType("DuneWisp"))
			            {
				            Main.NewText("Dune Wisp", 255, 255, 0);
				            Main.NewText("Spawns in the desert after defeating Eye of Cthulhu, creates a tornado upon death", 255, 255, 255);
				            Main.NewText("Drop Table", 255, 255, 0);
				            Main.NewText(string.Format("[i:{0}]", mod.ItemType<Items.AaMaterials.BossEnergy>()), 0, 0, 0);
							projectile.Kill();
						}
						
						if (npc.type == mod.NPCType("UndeadWisp"))
			            {
				            Main.NewText("Undead Wisp", 255, 255, 0);
				            Main.NewText("Spawns in the dungeon, splits upon death", 255, 255, 255);
				            Main.NewText("Drop Table", 255, 255, 0);
				            Main.NewText(string.Format("[i:{0}]", mod.ItemType<Items.AaMaterials.UndeadEnergy>()), 0, 0, 0);
							projectile.Kill();
						}
						
						if (npc.type == mod.NPCType("SoaringWisp"))
			            {
				            Main.NewText("Soaring Wisp", 255, 255, 0);
				            Main.NewText("Spawns in the sky after defeating Eater of Worlds or Brain of Cthulhu", 255, 255, 255);
				            Main.NewText("Drop Table", 255, 255, 0);
				            Main.NewText(string.Format("[i:{0}]", mod.ItemType<Items.AaMaterials.UndeadEnergy>()), 0, 0, 0);
							projectile.Kill();
						}
					}
                }
            }
		}
    }
}