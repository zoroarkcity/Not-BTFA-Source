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
    public class AcheronBarrier : ModNPC
    {
		Vector2 Location;
		Vector2 Location2;
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 9999;
            npc.damage = 0;
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
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barrier Wisp");
			Main.npcFrameCount[npc.type] = 6;
		}
		
		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection )		
		{
			if (!projectile.minion)
				projectile.penetrate = 0;
			
			damage = 0;
			npc.life++;
		}
		
		public override bool? DrawHealthBar(byte hbPos, ref float scale, ref Vector2 Pos)
		{
			return false;
		}
		
        public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = Main.npc[(int)npc.ai[1]].spriteDirection;
            Player player = Main.player[npc.target];
			npc.ai[2]++;
			
			if (npc.ai[0] == 0)
			{
				Location = npc.Center - Main.npc[(int)npc.ai[1]].Center;
				Location2 = npc.Center - Main.npc[(int)npc.ai[1]].Center;
				npc.ai[0]++;
			}
			else
			{
				Location2 = Location.RotatedBy((MathHelper.Pi / 180));
				Location = Location2;
				npc.Center = Location + Main.npc[(int)npc.ai[1]].Center;
			}
			
			if (!NPC.AnyNPCs(mod.NPCType("Acheron")))
			{
				npc.life = 0;
				NPCLoot();
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
