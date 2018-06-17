using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Bjorn
{
	[AutoloadBossHead]
    public class Bjorn : ModNPC
    {
        public override void SetDefaults()
        {
			npc.aiStyle = 26;
			aiType = 508;
			npc.width = 30;
			npc.height = 40;
			npc.damage = 5;
            npc.defense = 0;
            npc.knockBackResist = 0f;
            npc.value = 0;
            npc.boss = true;
			npc.lifeMax = 120;
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
			bossBag = mod.ItemType("MegaTreeBag");
            music = MusicID.Boss1;
			npc.npcSlots = 5;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bjorn");
			Main.npcFrameCount[npc.type] = 4;
        }
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.LesserHealingPotion; //Applies to Bosses regardless of world difficulty- pre hm is always lesser, hm is always greater   
		}		
		public override void AI()
		{
			Player player = Main.player[npc.target];
			
			Vector2 newMove = npc.Center - player.Center;
			float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
			
			if (!player.active || player.dead || distanceTo >= 1000)
            {
                npc.TargetClosest(false);
				
				if (npc.timeLeft > 60)
				{
					npc.timeLeft = 60;
				}
            }
		}
		
		public override void FindFrame(int frameHeight)
		{
			if (npc.velocity.Y == 0.0)
			{
				if (npc.direction == 1)
					npc.spriteDirection = 1;
				if (npc.direction == -1)
					npc.spriteDirection = -1;
				
				npc.frameCounter += 0.25f; 
				npc.frameCounter %= 4; 
				int frame = (int)npc.frameCounter; 
				npc.frame.Y = frame * frameHeight;
			}
		}
		
		public override void NPCLoot()
		{
			TGEMWorld.downedGhastlyEnt = true;

			if (Main.expertMode)
			{
                npc.DropBossBags();
			}
			else
			{
			    switch (Main.rand.Next(6))
			    {
				    case 0: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Fist_of_the_Hallow_Ent")));
					    break;
				    case 1: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ForestBlast")));
					    break;
				    case 2: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("LeafScythe")));
					    break;
				    case 3: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("LivingTreeSword")));
					    break;
				    case 4: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("WoodChipper")));
					    break;
				    case 5: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("TreeStaff")));
					    break;
				    default:
					    break;
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ForestEnergy")), Main.rand.Next(22, 35));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("BlossomBranch")), Main.rand.Next(5, 10));
			    TGEMWorld.TryForBossMask(npc.Center, npc.type);
				}
			}
			if (Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Tadpole_Egg")));
			}
		}
    }
}
