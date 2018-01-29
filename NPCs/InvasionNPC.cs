using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ForgottenMemories;

namespace ForgottenMemories.NPCs
{
    public class InvasionNPC : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary< int, float > pool, NPCSpawnInfo spawnInfo)
        {
            if(TGEMWorld.forestInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                pool.Clear();
				
                foreach(int i in CustomInvasion.invaders)
                {
                    pool.Add(i, 1f);
                }
				
				if (Main.hardMode)
				{
					foreach(int i in CustomInvasion.hmInvaders)
					{
						pool.Add(i, 1f);
					}
				}
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if(TGEMWorld.forestInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                spawnRate = 50; 
                maxSpawns = 50; 
            }
        }

        public override void PostAI(NPC npc)
        {
            if(TGEMWorld.forestInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                npc.timeLeft = 1000;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if(TGEMWorld.forestInvasionUp)
            {
                foreach(int invader in CustomInvasion.invaders)
                {
                    if(npc.type == invader)
                    {
                        Main.invasionSize -= 2;
						if (Main.rand.Next(3) == 0)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ForestEnergy"), 1); 
						}
                    }
					if(npc.type == mod.NPCType("MagnoliacSecondStage") && !Main.hardMode)
					{
						Player player = Main.player[npc.target];
						Main.invasionSize -= 1000;
						player.GetModPlayer<TgemPlayer>().MagnoliacBool = false;
					}
					if(npc.type == mod.NPCType("MagnoliacSecondStage") && Main.hardMode)
					{
						Player player = Main.player[npc.target];
						player.GetModPlayer<TgemPlayer>().MagnoliacBool = false;
					}
					if(npc.type == mod.NPCType("GhastlyEnt") && Main.hardMode)
					{
						Player player = Main.player[npc.target];
						player.GetModPlayer<TgemPlayer>().GentBool = false;
						Main.invasionSize -= 1000;
					}
                }
            }
        }
    }
}
