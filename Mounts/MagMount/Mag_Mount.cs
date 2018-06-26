using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Mounts.MagMount
{
    public class Mag_Mount : ModMountData
    {
        public override void SetDefaults()
        {
			Player player = Main.player[Main.myPlayer];
            mountData.buff = mod.BuffType("MagBuff");
            mountData.spawnDust = 39;
            mountData.spawnDustNoGravity = true;
            mountData.heightBoost = 32;
            mountData.flightTimeMax = 320;
            mountData.fatigueMax = 160;
            mountData.fallDamage = 0.0f;
            mountData.usesHover = true;
            mountData.runSpeed = 4f;
            mountData.dashSpeed = 4f;
            mountData.acceleration = 0.5f;
            mountData.jumpHeight = 10;
            mountData.jumpSpeed = 6f;
            mountData.blockExtraJumps = true;
            mountData.bodyFrame = 0;
            mountData.totalFrames = 1;           
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 16;
            }
			mountData.playerYOffsets = array;
            mountData.xOffset = -4;                    
            mountData.yOffset = 33;  
            mountData.playerHeadOffset = 18;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 0;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 1;
            mountData.runningFrameDelay = 0;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 1;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 0;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 0;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = 1;
            mountData.swimFrameDelay = 0;
            mountData.swimFrameStart = 0;
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