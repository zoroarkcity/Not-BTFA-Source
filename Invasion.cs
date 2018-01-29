using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Utilities;
using ForgottenMemories;

namespace ForgottenMemories
{
    public class CustomInvasion //Credit goes to Sin Costan for making this guide: https://forums.terraria.org/index.php?threads/tutorial-custom-invasion.57771/
    {
		public static Mod mod = ModLoader.GetMod("ForgottenMemories");
		
		public static int[] invaders = {
            mod.NPCType("TreeMan"),
			mod.NPCType("BorealTreeMan"),
			mod.NPCType("PalmTreeMan"),
			mod.NPCType("RichMahoganyTreeMan"),
			mod.NPCType("PineFlyer"),
			mod.NPCType("CharredEnt"),
			mod.NPCType("LivingMortar"),
			mod.NPCType("TreeWitch")
        };
		
		public static int[] hmInvaders = {
            mod.NPCType("RedwoodRam"),
			mod.NPCType("RottenEnt"),
			mod.NPCType("BlossomBomber")
        };
		
		public static void StartCustomInvasion()
        {
            if (Main.invasionType != 0 && Main.invasionSize == 0)
            {
                Main.invasionType = 0;
            }
   
            if (Main.invasionType == 0)
            {
                int numPlayers = 0;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
                    {
                        numPlayers++;
                    }
                }
                if (numPlayers > 0)
                {
                    Main.invasionType = -1;
                    TGEMWorld.forestInvasionUp = true;
                    Main.invasionSize = 100 * numPlayers;
                    Main.invasionSizeStart = Main.invasionSize;
                    Main.invasionProgress = 0;
                    Main.invasionProgressIcon = 0 + 3;
                    Main.invasionProgressWave = 0;
                    Main.invasionProgressMax = Main.invasionSizeStart;
                    Main.invasionWarn = 3600;
                    Main.invasionX = Main.spawnTileX;
                }
            }
        }
		
		public static void CustomInvasionWarning()
        {
            String text = "";
            if (Main.invasionX == (double)Main.spawnTileX)
            {
               // text = "Hostile trees spring up from the ground!";
            }
            if(Main.invasionSize <= 0)
            {
                text = "The woodland terrors retreat to their roots!.";
            }
            if (Main.netMode == 0)
            {
                Main.NewText(text, 175, 75, 255, false);
                return;
            }
            if (Main.netMode == 2)
            {
                NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral(text), 255, 175f, 75f, 255f, 0, 0, 0);
            }
        }
		
        public static void UpdateCustomInvasion()
        {
            if(TGEMWorld.forestInvasionUp)
            {
                if(Main.invasionSize <= 0)
                {
                    TGEMWorld.forestInvasionUp = false;
					TGEMWorld.downedForestInvasion = true;
                    CustomInvasionWarning();
                    Main.invasionType = 0;
                    Main.invasionDelay = 0;
                }
       
                if (Main.invasionX == (double)Main.spawnTileX)
                {
                    return;
                }
       
                float moveRate = (float)Main.dayRate;
       
                if (Main.invasionX > (double)Main.spawnTileX)
                {
                    Main.invasionX -= (double)moveRate;
           
                    if (Main.invasionX <= (double)Main.spawnTileX)
                    {
                        Main.invasionX = (double)Main.spawnTileX;
                        CustomInvasionWarning();
                    }
                    else
                    {
                        Main.invasionWarn--;
                    }
                }
                else
                {
                    if (Main.invasionX < (double)Main.spawnTileX)
                    {
                        Main.invasionX += (double)moveRate;
                        if (Main.invasionX >= (double)Main.spawnTileX)
                        {
                            Main.invasionX = (double)Main.spawnTileX;
                            CustomInvasionWarning();
                        }
                        else
                        {
                            Main.invasionWarn--;
                        }
                    }
                }
            }
        }
		
		public static void CheckCustomInvasionProgress()
        {
            if (Main.invasionProgressMode != 2)
            {
                Main.invasionProgressNearInvasion = false;
                return;
            }
   
            bool flag = false;
            Player player = Main.player[Main.myPlayer];
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            int num = 5000;
            int icon = 0;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active)
                {
                    icon = 0;
                    int type = Main.npc[i].type;
                    for(int n = 0; n < invaders.Length; n++)
                    {
                        if(type == invaders[n])
                        {
                            Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
                            if (rectangle.Intersects(value))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            ProgressBar.invasionProgressNearInvasion = flag;
            int progressMax3 = 1;
   
            if (TGEMWorld.forestInvasionUp)
            {
                progressMax3 = Main.invasionSizeStart;
            }
   
            if(TGEMWorld.forestInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                ProgressBar.ReportCustomInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, icon, 0);
            }
   
            foreach(Player p in Main.player)
            {
                NetMessage.SendData(78, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, (float)Main.invasionSizeStart, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
            }
        }
		
		
    }
}