using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Mounts.AcheronMount
{
    public class Obolos_Mount : ModMountData
    {
        public override void SetDefaults()
        {
			Player player = Main.player[Main.myPlayer];
            mountData.spawnDust = 160;
            mountData.buff = mod.BuffType("Obolos_Buff");
            mountData.heightBoost = 10;         
            mountData.fallDamage = 0f;
            mountData.runSpeed = 4.3f;
            mountData.dashSpeed = 4.3f;
            mountData.flightTimeMax = 500;
            mountData.fatigueMax = 400;
            mountData.jumpHeight = 10;
            mountData.acceleration = 0.12f;
            mountData.jumpSpeed = 4f;
            mountData.blockExtraJumps = true;
            mountData.totalFrames = 14;           
			mountData.usesHover = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 16;
            }
			mountData.playerYOffsets = array;
            mountData.xOffset = -26;                    
            mountData.yOffset = -4;          
            mountData.bodyFrame = 0;          
            mountData.playerHeadOffset = 22;        
            mountData.standingFrameCount = 6;
            mountData.standingFrameDelay = 5;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 8;
            mountData.runningFrameDelay = 20;
            mountData.runningFrameStart = 6;
            mountData.flyingFrameCount = 8;
            mountData.flyingFrameDelay = 5;
            mountData.flyingFrameStart = 6;
            mountData.inAirFrameCount = 8;
            mountData.inAirFrameDelay = 5;
            mountData.inAirFrameStart = 6;
            mountData.idleFrameCount = 6;
            mountData.idleFrameDelay = 5;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.frontTexture.Width;
                mountData.textureHeight = mountData.frontTexture.Height;
            }
        }
 
        /*public override void UpdateEffects(Player player)
        {
            if (Math.Abs(player.velocity.X) > 4f)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, mod.DustType("DustName"));
            }
        }*/
    }
}