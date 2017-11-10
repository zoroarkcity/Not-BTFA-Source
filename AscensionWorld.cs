using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;

namespace ForgottenMemories
{
	public class AscensionWorld : ModWorld
	{
        public static Mod mod = ModLoader.GetMod("ForgottenMemories");
		
        public static void DropComet()
        {
        bool flag = true;
            if (Main.netMode == 1)
            {
                return;
            }
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active)
                {
                    flag = false;
                    break;
                }
            }
            int num = 0;
            float num2 = (float)(Main.maxTilesX / 4200);
            int num3 = (int)(400f * num2);
            for (int j = 5; j < Main.maxTilesX - 5; j++)
            {
                int num4 = 5;
                while ((double)num4 < Main.worldSurface)
                {
                   /* if (Main.tile[j, num4].active() && Main.tile[j, num4].type == (ushort)mod.TileType("Cosmodium"))
                    {
                        num++;
                        if (num > num3)
                        {
                            return;
                        }
                    }*/
                    num4++;
                }
            }
            float num5 = 600f;
            while (!flag)
            {
                float num6 = (float)Main.maxTilesX * 0.08f;
                int num7 = Main.rand.Next(150, Main.maxTilesX - 150);
                while ((float)num7 > (float)Main.spawnTileX - num6 && (float)num7 < (float)Main.spawnTileX + num6)
                {
                    num7 = Main.rand.Next(150, Main.maxTilesX - 150);
                }
                int k = (int)(Main.worldSurface * 0.3);
                while (k < Main.maxTilesY)
                {
                    if (Main.tile[num7, k].active() && Main.tileSolid[(int)Main.tile[num7, k].type])
                    {
                        int num8 = 0;
                        int num9 = 15;
                        for (int l = num7 - num9; l < num7 + num9; l++)
                        {
                            for (int m = k - num9; m < k + num9; m++)
                            {
                                if (WorldGen.SolidTile(l, m))
                                {
                                    num8++;
                                    if (Main.tile[l, m].type == 189 || Main.tile[l, m].type == 202)
                                    {
                                        num8 -= 100;
                                    }
                                }
                                else if (Main.tile[l, m].liquid > 0)
                                {
                                    num8--;
                                }
                            }
                        }
                        if ((float)num8 < num5)
                        {
                            num5 -= 0.5f;
                            break;
                        }
                        flag = AscensionWorld.Comet(num7, k);
                        if (flag)
                        {
                            break;
                        }
                        break;
                    }
                    else
                    {
                        k++;
                    }
                }
                if (num5 < 100f)
                {
                    return;
                }
            }
        }

        public static bool Comet(int i, int j)
        {
            if (i < 50 || i > Main.maxTilesX - 50)
            {
                return false;
            }
            if (j < 50 || j > Main.maxTilesY - 50)
            {
                return false;
            }
            int num = 35;
            Rectangle rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);
            for (int k = 0; k < 255; k++)
            {
                if (Main.player[k].active)
                {
                    Rectangle value = new Rectangle((int)(Main.player[k].position.X + (float)(Main.player[k].width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(Main.player[k].position.Y + (float)(Main.player[k].height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                    if (rectangle.Intersects(value))
                    {
                        return false;
                    }
                }
            }
            for (int l = 0; l < 200; l++)
            {
                if (Main.npc[l].active)
                {
                    Rectangle value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);
                    if (rectangle.Intersects(value2))
                    {
                        return false;
                    }
                }
            }
            for (int m = i - num; m < i + num; m++)
            {
                for (int n = j - num; n < j + num; n++)
                {
                    if (Main.tile[m, n].active() && TileID.Sets.BasicChest[(int) Main.tile[m, n].type])
                    {
                        return false;
                    }
                }
            }
           // WorldGen.stopDrops = true;
            num = WorldGen.genRand.Next(17, 23);
            for (int num2 = i - num; num2 < i + num; num2++)
            {
                for (int num3 = j - num; num3 < j + num; num3++)
                {
                    if (num3 > j + Main.rand.Next(-2, 3) - 5)
                    {
                        float num4 = (float)Math.Abs(i - num2);
                        float num5 = (float)Math.Abs(j - num3);
                        float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                        if ((double)num6 < (double)num * 0.9 + (double)Main.rand.Next(-4, 5))
                        {
                            if (!Main.tileSolid[(int)Main.tile[num2, num3].type])
                            {
                                Main.tile[num2, num3].active(false);
                            }
                            Main.tile[num2, num3].type = (ushort)mod.TileType("Cosmodium");
                        }
                    }
                }
            }
            num = WorldGen.genRand.Next(8, 14);
            for (int num7 = i - num; num7 < i + num; num7++)
            {
                for (int num8 = j - num; num8 < j + num; num8++)
                {
                    if (num8 > j + Main.rand.Next(-2, 3) - 4)
                    {
                        float num9 = (float)Math.Abs(i - num7);
                        float num10 = (float)Math.Abs(j - num8);
                        float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                        if ((double)num11 < (double)num * 0.8 + (double)Main.rand.Next(-3, 4))
                        {
                            Main.tile[num7, num8].active(false);
                        }
                    }
                }
            }
            num = WorldGen.genRand.Next(25, 35);
            for (int num12 = i - num; num12 < i + num; num12++)
            {
                for (int num13 = j - num; num13 < j + num; num13++)
                {
                    float num14 = (float)Math.Abs(i - num12);
                    float num15 = (float)Math.Abs(j - num13);
                    float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
                    if ((double)num16 < (double)num * 0.7)
                    {
                        if (Main.tile[num12, num13].type == 5 || Main.tile[num12, num13].type == 32 || Main.tile[num12, num13].type == 352)
                        {
                            WorldGen.KillTile(num12, num13, false, false, false);
                        }
                        Main.tile[num12, num13].liquid = 0;
                    }
                    if (Main.tile[num12, num13].type == (ushort)mod.TileType("Cosmodium"))
                    {
                        if (!WorldGen.SolidTile(num12 - 1, num13) && !WorldGen.SolidTile(num12 + 1, num13) && !WorldGen.SolidTile(num12, num13 - 1) && !WorldGen.SolidTile(num12, num13 + 1))
                        {
                            Main.tile[num12, num13].active(false);
                        }
                        else if ((Main.tile[num12, num13].halfBrick() || Main.tile[num12 - 1, num13].topSlope()) && !WorldGen.SolidTile(num12, num13 + 1))
                        {
                            Main.tile[num12, num13].active(false);
                        }
                    }
                    WorldGen.SquareTileFrame(num12, num13, true);
                    WorldGen.SquareWallFrame(num12, num13, true);
                }
            }
            num = WorldGen.genRand.Next(23, 32);
            for (int num17 = i - num; num17 < i + num; num17++)
            {
                for (int num18 = j - num; num18 < j + num; num18++)
                {
                    if (num18 > j + WorldGen.genRand.Next(-3, 4) - 3 && Main.tile[num17, num18].active() && Main.rand.Next(10) == 0)
                    {
                        float num19 = (float)Math.Abs(i - num17);
                        float num20 = (float)Math.Abs(j - num18);
                        float num21 = (float)Math.Sqrt((double)(num19 * num19 + num20 * num20));
                        if ((double)num21 < (double)num * 0.8)
                        {
                            if (Main.tile[num17, num18].type == 5 || Main.tile[num17, num18].type == 32 || Main.tile[num17, num18].type == 352)
                            {
                                WorldGen.KillTile(num17, num18, false, false, false);
                            }
                            Main.tile[num17, num18].type = (ushort)mod.TileType("Cosmodium");
                            WorldGen.SquareTileFrame(num17, num18, true);
                        }
                    }
                }
            }
            num = WorldGen.genRand.Next(30, 38);
            for (int num22 = i - num; num22 < i + num; num22++)
            {
                for (int num23 = j - num; num23 < j + num; num23++)
                {
                    if (num23 > j + WorldGen.genRand.Next(-2, 3) && Main.tile[num22, num23].active() && Main.rand.Next(20) == 0)
                    {
                        float num24 = (float)Math.Abs(i - num22);
                        float num25 = (float)Math.Abs(j - num23);
                        float num26 = (float)Math.Sqrt((double)(num24 * num24 + num25 * num25));
                        if ((double)num26 < (double)num * 0.85)
                        {
                            if (Main.tile[num22, num23].type == 5 || Main.tile[num22, num23].type == 32 || Main.tile[num22, num23].type == 352)
                            {
                                WorldGen.KillTile(num22, num23, false, false, false);

                            }
                            Main.tile[num22, num23].type = (ushort)mod.TileType("Cosmodium");
                            WorldGen.SquareTileFrame(num22, num23, true);
                        }
                    }
                }
            }
           // WorldGen.stopDrops = false;
            //if (Main.netMode == 0) temporarily may have broke multiplayer because migration guide says nothing on how to fix :(
            //{
                Main.NewText("A strange comet has landed!", 50, 255, 130, false);
            //}
           // else if (Main.netMode == 2)
           // {
           //     NetMessage.SendData(25, -1, -1, "A strange comet has landed!", 255, 50f, 255f, 130f, 0, 0, 0);
           // }
           //if (Main.netMode != 1)
            //{
            //    NetMessage.SendTileSquare(-1, i, j, 40);
            //}
            return true;
        }

    }
}
