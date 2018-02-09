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
    public class AcheronDeath : ModNPC
    {
		Vector2 TPLocation;
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 1;
            npc.damage = 0;
            npc.defense = 0;
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 112;
			npc.dontTakeDamage = true;
            npc.value = 100000;
            npc.lavaImmune = true;
			npc.alpha = 0;
            npc.noTileCollide = true;
            npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
            music = MusicID.Boss3;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acheron");
			Main.npcFrameCount[npc.type] = 6;
		}

        public override void AI()
        {
			npc.velocity = Vector2.Zero;
			
			npc.alpha += 1;
			if (npc.alpha >= 255)
			{
				npc.life = 0;
				NPCLoot();
			}
			
			for (int i = 0; i < 8; i++)
			{
				Vector2 velocity = new Vector2(Main.rand.Next(4, 8), 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45) + i * 45));
				Dust newDust = Dust.NewDustDirect(npc.Center, 0, 0, 20, velocity.X, velocity.Y);
				newDust.noGravity = true;
				newDust.fadeIn = 0.2f;
				newDust.scale = 2;
			}
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.1f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public override void NPCLoot()
		{
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			TGEMWorld.downedAcheron = true;
			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("AcheronBag")));
			}
			else
			{
				switch (Main.rand.Next(6))
				{
					case 0: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Thanatos")));
						break;
					case 1: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Styx")));
						break;
					case 2:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("AcheronStaff")));
						break;
					case 3:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("MacabreGrimoire")));
						break;
					case 4:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Cerberus")));
						break;
					case 5:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("HadesHand")));
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("LostSoul")), Main.rand.Next(100, 151));
						break;
					default:
						break;
				}
				
				if (Main.rand.Next(6) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("BansheeLure")));
			}
		}
	}
}
