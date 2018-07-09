using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Barksteel.Branchwood_Thief
{
    public class Branchwood_Thief : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Branchwood Thief");
			Main.npcFrameCount[npc.type] = 4;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;  
			npc.lifeMax = 50;	 
            npc.defense = 0;  
			npc.value = 500f;
			aiType = 73;
            npc.knockBackResist = 0f;
            npc.width = 28;
            npc.height = 50;
			npc.damage = 30;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.HitSound = 	new Terraria.Audio.LegacySoundStyle(42, 92);
			npc.dontTakeDamage = false;
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(42, 114);
			banner = npc.type;
			bannerItem = mod.ItemType("Branchwood_Thief_Banner");
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;

			Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
			float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
			float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
			float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
			npc.velocity.X = num2 * num4 * 0.45f;
			float distance = 1500f;		
        }
		public override void NPCLoot ()
		{	
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Barksteel"), Main.rand.Next(1, 5));
			}
		}
		public override void OnHitPlayer (Player target, int damage, bool crit)
		{
			Main.PlaySound(new Terraria.Audio.LegacySoundStyle(18, 0));
			int num1 = 0;
			for (int index = 0; index < 59; ++index)
			{
				if (target.inventory[index].type >= 71 && target.inventory[index].type <= 74)
				{
					int number = Item.NewItem((int) target.position.X, (int) target.position.Y, target.width, target.height, target.inventory[index].type, 1, false, 0, false, false);
					int num2 = target.inventory[index].stack / 5;
					if (Main.expertMode)
						num2 = (int) ((double) target.inventory[index].stack * 0.25);
					int num3 = target.inventory[index].stack - num2;
					target.inventory[index].stack -= num3;
					if (target.inventory[index].type == 71)
						num1 += num3;
					if (target.inventory[index].type == 72)
						num1 += num3 * 100;
					if (target.inventory[index].type == 73)
						num1 += num3 * 10000;
					if (target.inventory[index].type == 74)
						num1 += num3 * 1000000;
					if (target.inventory[index].stack <= 0)
						target.inventory[index] = new Item();
					Main.item[number].stack = num3;
					Main.item[number].velocity.Y = (float) Main.rand.Next(-20, 1) * 0.2f;
					Main.item[number].velocity.X = (float) Main.rand.Next(-20, 21) * 0.2f;
					Main.item[number].noGrabDelay = 100;
					if (index == 58)
						Main.mouseItem = target.inventory[index].Clone();
				}
			}
			target.lostCoins = num1;
			target.lostCoinString = Main.ValueToCoins(target.lostCoins);
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			/*if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Branchwood_Thief_Gore"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Branchwood_Thief_Gore_2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Branchwood_Thief_Gore_2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Branchwood_Thief_Gore_3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Branchwood_Thief_Gore_3"), 1f);
			}*/
		}
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			
			Player player = Main.player[npc.target];
			npc.frameCounter++;
			{
				if (npc.frameCounter < 6)
				{
					npc.frame.Y = Frame_1 * frameHeight;
				}
				else if (npc.frameCounter < 12)
				{
					npc.frame.Y = Frame_2 * frameHeight;
				}
				else if (npc.frameCounter < 18)
				{
					npc.frame.Y = Frame_3 * frameHeight;
				}
				else if (npc.frameCounter < 24)
				{
					npc.frame.Y = Frame_4 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
				npc.spriteDirection = npc.direction;
			}
		}
    }
}