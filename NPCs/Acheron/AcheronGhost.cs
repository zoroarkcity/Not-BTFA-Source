using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Acheron
{
	//[AutoloadBossHead]
    public class AcheronGhost : ModNPC
    {
		Vector2 TPLocation;
		public float speedCounter = 13f;

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 1;
            npc.damage = 40;
            npc.defense = 0;
            npc.knockBackResist = 0f;
            npc.width = 98;
            npc.height = 112;
            npc.value = 0;
            npc.lavaImmune = true;
			npc.alpha = 100;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit49;
			npc.DeathSound = SoundID.NPCDeath6;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 1;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
			{
				npc.damage = 60;
			}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Soul");
			Main.npcFrameCount[npc.type] = 6;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
			Texture2D texture2D3 = mod.GetTexture("NPCs/Acheron/AcheronGhost");
			int num156 = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
			int y3 = num156 * (int)npc.frameCounter;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			int arg_5ADA_0 = npc.type;
			int arg_5AE7_0 = npc.type;
			int arg_5AF4_0 = npc.type;
			int num157 = 10;
			int num158 = 2;
			int num159 = 1;
			float value3 = 1f;
			float num160 = 0f;
			
			
			int num161 = num159;
			while (((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157)))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = npc.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Blue, 0.5f);
				color26.A += (byte)(150);
				
				IL_6881:
				num161 += num158;
				continue;
				IL_6899:
				float num164 = (float)(num157 - num161);
				if (num158 < 0)
				{
					num164 = (float)(num159 - num161);
				}
				color26 *= num164 / ((float)NPCID.Sets.TrailCacheLength[npc.type] * 1.5f);
				Vector2 value4 = (npc.oldPos[num161]);
				float num165 = npc.rotation;
				SpriteEffects effects = spriteEffects;
				Main.spriteBatch.Draw(texture2D3, value4 + npc.Size / 2f - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, npc.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = npc.GetAlpha(color25);
			return true;
		}

		public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
			npc.ai[0]++;
			
			if (npc.alpha > 255)
				npc.alpha = 255;
			
			npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, 0.03f);
			if (npc.ai[0] > 30 && Main.rand.Next(10) == 0)
			{
				//Vector2 vector2 = npc.Center;
				//float num5 = player.Center.X - vector2.X;
				//float num6 = player.Center.Y - vector2.Y;
				//float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
				//float num8 = num4 / num7;
				//npc.velocity.X = direction.X * num8;
				//npc.velocity.Y = direction.Y * num8;

				if (Main.expertMode) //gets faster per dash in expert
					speedCounter += 2;

				Vector2 direction = Vector2.Subtract(player.Center, npc.Center);
				float velocity = speedCounter / direction.Length();
				npc.velocity = direction * velocity;
				Main.PlaySound(SoundID.NPCDeath6, npc.position);
				npc.ai[0] = 0;
			}
			
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.2f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		public override void NPCLoot()
		{
			for (int index1 = 0; index1 < 5; ++index1)
			{
				int dust;
				Vector2 newVect = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(npc.Center, 0, 0, 20, newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(npc.Center, 0, 0, 20, newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(npc.Center, 0, 0, 20, newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(npc.Center, 0, 0, 20, newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(npc.Center, 0, 0, 20, newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(npc.Center, 0, 0, 20, newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(npc.Center, 0, 0, 20, newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(npc.Center, 0, 0, 20, newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
				Main.dust[dust].scale = 2;
				Main.dust[dust2].scale = 2;
				Main.dust[dust3].scale = 2;
				Main.dust[dust4].scale = 2;
				Main.dust[dust5].scale = 2;
				Main.dust[dust6].scale = 2;
				Main.dust[dust7].scale = 2;
				Main.dust[dust8].scale = 2;
			}
		}
	}
}
