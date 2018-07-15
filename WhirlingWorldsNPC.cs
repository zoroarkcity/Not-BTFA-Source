using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace ForgottenMemories
{
    public class WhirlingWorldsNPC : GlobalNPC
    {
		public bool serratedTag = false;
		public bool chainLightning = false;
	
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}			
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.name == "DogeVlogsAndGames")
			{
				spawnRate = 0;
				maxSpawns = 0;
			}
		}
        public override void NPCLoot(NPC npc)
        {
			Player player = Main.player[npc.target];
			{			
			if (player.HeldItem.type == mod.ItemType("Phantom_Reap") && Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Phantom"));
			}
			
			if (npc.FindBuffIndex(mod.BuffType("Targetted")) < 0 && player.GetModPlayer<WhirlingWorldsPlayer>().Quagmire)
			{
				player.AddBuff(mod.BuffType("CounterTargetted"), 1800);
			}
			if (npc.FindBuffIndex(mod.BuffType("Targetted")) > -1 && player.GetModPlayer<WhirlingWorldsPlayer>().Quagmire)
			{
				player.ClearBuff(mod.BuffType("CounterTargetted"));
			}
			}
		}
		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			if (npc.FindBuffIndex(mod.BuffType("Targetted")) > -1 && player.GetModPlayer<WhirlingWorldsPlayer>().Quagmire)
			{
				damage = damage + damage;
			}
		}	
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[npc.target];
			if (npc.FindBuffIndex(mod.BuffType("Targetted")) > -1 && player.GetModPlayer<WhirlingWorldsPlayer>().Quagmire)
			{
				damage = damage + damage;
			}
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
			if (serratedTag) 
            {
                npc.lifeRegen -= 15;    
                damage = 6;  
            }
        }		
		public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
		{
			Player player = Main.LocalPlayer;
			if (npc.FindBuffIndex(mod.BuffType("Targetted")) > -1 && player.GetModPlayer<WhirlingWorldsPlayer>().Quagmire)
			{
				spriteBatch.Draw(mod.GetTexture("Items/Sets/Barksteel_Set/Quagmire/TargetDot"), npc.position - Main.screenPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
		}
    }
}  