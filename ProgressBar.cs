using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using System;
using System.IO;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.UI;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories
{
    public class ProgressBar
    {
		public static Mod mod = ModLoader.GetMod("ForgottenMemories");
		public static bool invasionProgressNearInvasion = false;
		public static int invasionProgressMode = 2;
		public static int invasionProgress = 0;
		public static int invasionProgressMax = 0;
		public static int invasionProgressIcon = 0;
		public static int invasionProgressWave = 0;
		public static int invasionProgressDisplayLeft = 0;
		public static float invasionProgressAlpha = 0f;
		
		public static void ReportCustomInvasionProgress(int progress, int progressMax, int icon, int progressWave)
		{
			invasionProgress = progress;
			invasionProgressMax = progressMax;
			invasionProgressIcon = icon;
			invasionProgressWave = progressWave;
			invasionProgressDisplayLeft = 160;
		}

		public static void DrawCustomInvasionProgress()
		{
			if (invasionProgress == -1)
			{
				return;
			}
			if (invasionProgressMode == 2 && invasionProgressNearInvasion && invasionProgressDisplayLeft < 160)
			{
				invasionProgressDisplayLeft = 160;
			}
			if (!Main.gamePaused && invasionProgressDisplayLeft > 0)
			{
				invasionProgressDisplayLeft--;
			}
			if (invasionProgressDisplayLeft > 0)
			{
				invasionProgressAlpha += 0.05f;
			}
			else
			{
				invasionProgressAlpha -= 0.05f;
			}
			if (invasionProgressAlpha < 0f)
			{
				invasionProgressAlpha = 0f;
			}
			if (invasionProgressAlpha > 1f)
			{
				invasionProgressAlpha = 1f;
			}
			if (invasionProgressAlpha <= 0f)
			{
				return;
			}
			float num = 0.5f + invasionProgressAlpha * 0.5f;
			Texture2D texture2D = mod.GetTexture("TreeIcon");
			string text = " Forest's Army";
			Color c = new Color(104, 255, 167) * 0.5f;
			/*if (Main.invasionProgressIcon == 1)
			{
				texture2D = Main.extraTexture[8];
				text = Lang.inter[83].Value;
				c = new Microsoft.Xna.Framework.Color(64, 109, 164) * 0.5f;
			}
			else if (Main.invasionProgressIcon == 2)
			{
				texture2D = Main.extraTexture[12];
				text = Lang.inter[84].Value;
				c = new Microsoft.Xna.Framework.Color(112, 86, 114) * 0.5f;
			}
			else if (Main.invasionProgressIcon == 3)
			{
				texture2D = Main.extraTexture[79];
				text = Language.GetTextValue("DungeonDefenders2.InvasionProgressTitle");
				c = new Microsoft.Xna.Framework.Color(88, 0, 160) * 0.5f;
			}
			else if (Main.invasionProgressIcon == 7)
			{
				texture2D = Main.extraTexture[10];
				text = Lang.inter[85].Value;
				c = new Microsoft.Xna.Framework.Color(165, 160, 155) * 0.5f;
			}
			else if (Main.invasionProgressIcon == 6)
			{
				texture2D = Main.extraTexture[11];
				text = Lang.inter[86].Value;
				c = new Microsoft.Xna.Framework.Color(148, 122, 72) * 0.5f;
			}
			else if (Main.invasionProgressIcon == 5)
			{
				texture2D = Main.extraTexture[7];
				text = Lang.inter[87].Value;
				c = new Microsoft.Xna.Framework.Color(173, 135, 140) * 0.5f;
			}
			else if (Main.invasionProgressIcon == 4)
			{
				texture2D = Main.extraTexture[9];
				text = Lang.inter[88].Value;
				c = new Microsoft.Xna.Framework.Color(94, 72, 131) * 0.5f;
			}*/
			if (invasionProgressWave > 0)
			{
				int num2 = (int)(200f * num);
				int num3 = (int)(45f * num);
				Vector2 vector = new Vector2((float)(Main.screenWidth - 120), (float)(Main.screenHeight - 40));
				Microsoft.Xna.Framework.Rectangle r = new Microsoft.Xna.Framework.Rectangle((int)vector.X - num2 / 2, (int)vector.Y - num3 / 2, num2, num3);
				Utils.DrawInvBG(Main.spriteBatch, r, new Microsoft.Xna.Framework.Color(63, 65, 151, 255) * 0.785f);
				string text2;
				if (invasionProgressMax == 0)
				{
					text2 = Language.GetTextValue("Game.InvasionPoints", invasionProgress);
				}
				else
				{
					text2 = (int)((float)Main.invasionProgress * 100f / (float)Main.invasionProgressMax) + "%";
				}
				text2 = Language.GetTextValue("Game.WaveMessage", invasionProgressWave, text2);
				Texture2D texture2D2 = Main.colorBarTexture;
				Texture2D texture2D3 = Main.colorBlipTexture;
				float num4 = MathHelper.Clamp((float)invasionProgress / (float)invasionProgressMax, 0f, 1f);
				if (Main.invasionProgressMax == 0)
				{
					num4 = 1f;
				}
				float num5 = 169f * num;
				float num6 = 8f * num;
				Vector2 vector2 = vector + Vector2.UnitY * num6 + Vector2.UnitX * 1f;
				Utils.DrawBorderString(Main.spriteBatch, text2, vector2, Microsoft.Xna.Framework.Color.White * invasionProgressAlpha, num, 0.5f, 1f, -1);
				Main.spriteBatch.Draw(texture2D2, vector, null, Microsoft.Xna.Framework.Color.White * invasionProgressAlpha, 0f, new Vector2((float)(texture2D2.Width / 2), 0f), num, SpriteEffects.None, 0f);
				vector2 += Vector2.UnitX * (num4 - 0.5f) * num5;
				Main.spriteBatch.Draw(Main.magicPixel, vector2, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 1, 1)), new Microsoft.Xna.Framework.Color(255, 241, 51) * invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(num5 * num4, num6), SpriteEffects.None, 0f);
				Main.spriteBatch.Draw(Main.magicPixel, vector2, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 1, 1)), new Microsoft.Xna.Framework.Color(255, 165, 0, 127) * invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(2f, num6), SpriteEffects.None, 0f);
				Main.spriteBatch.Draw(Main.magicPixel, vector2, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 1, 1)), Microsoft.Xna.Framework.Color.Black * invasionProgressAlpha, 0f, new Vector2(0f, 0.5f), new Vector2(num5 * (1f - num4), num6), SpriteEffects.None, 0f);
			}
			else
			{
				int num7 = (int)(200f * num);
				int num8 = (int)(45f * num);
				Vector2 vector3 = new Vector2((float)(Main.screenWidth - 120), (float)(Main.screenHeight - 40));
				Microsoft.Xna.Framework.Rectangle r2 = new Microsoft.Xna.Framework.Rectangle((int)vector3.X - num7 / 2, (int)vector3.Y - num8 / 2, num7, num8);
				Utils.DrawInvBG(Main.spriteBatch, r2, new Microsoft.Xna.Framework.Color(63, 65, 151, 255) * 0.785f);
				string text3;
				if (invasionProgressMax == 0)
				{
					text3 = invasionProgress.ToString();
				}
				else
				{
					text3 = ((int)((float)invasionProgress * 100f / (float)invasionProgressMax)).ToString() + "%";
				}
				text3 = Language.GetTextValue("Game.WaveCleared", text3);
				Texture2D texture2D4 = Main.colorBarTexture;
				Texture2D texture2D5 = Main.colorBlipTexture;
				if (invasionProgressMax != 0)
				{
					Main.spriteBatch.Draw(texture2D4, vector3, null, Microsoft.Xna.Framework.Color.White * invasionProgressAlpha, 0f, new Vector2((float)(texture2D4.Width / 2), 0f), num, SpriteEffects.None, 0f);
					float num9 = MathHelper.Clamp((float)invasionProgress / (float)invasionProgressMax, 0f, 1f);
					Vector2 vector4 = Main.fontMouseText.MeasureString(text3);
					float num10 = num;
					if (vector4.Y > 22f)
					{
						num10 *= 22f / vector4.Y;
					}
					float num11 = 169f * num;
					float num12 = 8f * num;
					Vector2 vector5 = vector3 + Vector2.UnitY * num12 + Vector2.UnitX * 1f;
					Utils.DrawBorderString(Main.spriteBatch, text3, vector5 + new Vector2(0f, -4f), Microsoft.Xna.Framework.Color.White * invasionProgressAlpha, num10, 0.5f, 1f, -1);
					vector5 += Vector2.UnitX * (num9 - 0.5f) * num11;
					Main.spriteBatch.Draw(Main.magicPixel, vector5, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 1, 1)), new Microsoft.Xna.Framework.Color(255, 241, 51) * invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(num11 * num9, num12), SpriteEffects.None, 0f);
					Main.spriteBatch.Draw(Main.magicPixel, vector5, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 1, 1)), new Microsoft.Xna.Framework.Color(255, 165, 0, 127) * invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(2f, num12), SpriteEffects.None, 0f);
					Main.spriteBatch.Draw(Main.magicPixel, vector5, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 1, 1)), Microsoft.Xna.Framework.Color.Black * invasionProgressAlpha, 0f, new Vector2(0f, 0.5f), new Vector2(num11 * (1f - num9), num12), SpriteEffects.None, 0f);
				}
			}
			Vector2 vector6 = Main.fontMouseText.MeasureString(text);
			float num13 = 120f;
			if (vector6.X > 200f)
			{
				num13 += vector6.X - 200f;
			}
			Vector2 center = new Vector2((float)Main.screenWidth - num13, (float)(Main.screenHeight - 80));
			Microsoft.Xna.Framework.Rectangle r3 = Utils.CenteredRectangle(center, (vector6 + new Vector2((float)(texture2D.Width + 12), 6f)) * num);
			Utils.DrawInvBG(Main.spriteBatch, r3, c);
			Main.spriteBatch.Draw(texture2D, r3.Left() + Vector2.UnitX * num * 8f, null, Microsoft.Xna.Framework.Color.White * invasionProgressAlpha, 0f, new Vector2(0f, (float)(texture2D.Height / 2)), num * 0.8f, SpriteEffects.None, 0f);
			Utils.DrawBorderString(Main.spriteBatch, text, r3.Right() + Vector2.UnitX * num * -22f, Microsoft.Xna.Framework.Color.White * invasionProgressAlpha, num * 0.9f, 1f, 0.4f, -1);
		}
    }
}