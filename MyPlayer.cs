using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Items.ItemSets.OldGear;
using ForgottenMemories.Projectiles;
using ForgottenMemories.Buffs;
using ForgottenMemories.Buffs.ChlorophyllBuffs;

namespace ForgottenMemories
{
    public class MyPlayer : ModPlayer
	{
		
		public bool GroundPound;
		public bool Pound;
		public bool AquaPowers;
		public bool isGlitch;
		public bool breakShop;
		public static int rubixCubeSwitcher;
		public bool CosmicPowers;
		public bool hauntedCandle;
		public bool duneBonus;
		public float rangedVelocity;
		public float magicAttackSpeed;
		public bool boneHearts;
		public bool chlorophyllPod;
		
		public override void ResetEffects()
		{
			GroundPound = false;
			AquaPowers = false;
			isGlitch = false;
			CosmicPowers = false;
			hauntedCandle = false;
			duneBonus = false;
			boneHearts = false;
			chlorophyllPod = false;
			magicAttackSpeed = 1f;
			rangedVelocity = 1f;
			rubixCubeSwitcher = 0;
		}
		
		public override void PostUpdate()
	    {

		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
            if (chlorophyllPod) ApplyChlorophyllBuff(player);
        }
		
		public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockBack, bool Crit)
		{
			if (projectile.thrown && Tools.OneIn(5) && !target.immortal && boneHearts)
			{
				int newItem = Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, mod.ItemType("BoneHeart"));
                Main.item[newItem].velocity.Y = Main.rand.NextFloat(-4.0f, 0.2f);
				Main.item[newItem].velocity.X = Main.rand.NextFloat(2f, 6f) * projectile.direction;
				if (Main.netMode == NetmodeID.MultiplayerClient) NetMessage.SendData(MessageID.SyncItem, -1, -1, null, newItem);
			}

            if (chlorophyllPod) ApplyChlorophyllBuff(player);
	
		}

        public void ApplyChlorophyllBuff(Player player)
        {
            if (player.HasBuff(mod.BuffType<ChlorophyllBuffTwo>()))
            {
                player.DelBuff(player.FindBuffIndex(mod.BuffType<ChlorophyllBuffTwo>()));
                player.AddBuff(mod.BuffType<ChlorophyllBuffThree>(), 4 * 60);
            }
            else if (player.HasBuff(mod.BuffType<ChlorophyllBuffOne>()))
            {
                player.DelBuff(player.FindBuffIndex(mod.BuffType<ChlorophyllBuffOne>()));
                player.AddBuff(mod.BuffType<ChlorophyllBuffTwo>(), 4 * 60);
            }
            else if (!player.HasBuff(mod.BuffType<ChlorophyllBuffThree>()))
            {
                player.AddBuff(mod.BuffType<ChlorophyllBuffOne>(), 4 * 60);
            }
        }
		
		
		public override void SetupStartInventory(IList<Item> items)
		{
			if (Tools.OneIn(5))
			{
                Item item = new Item();
                item.SetDefaults(mod.ItemType<OldBlade>()));
				items.RemoveAt(0);
				items.Insert(0, item);
			}
            if (Tools.OneIn(5))
            {
                Item item = new Item();
                item.SetDefaults(mod.ItemType<OldPick>());
				items.RemoveAt(1);
				items.Insert(1, item);
			}
            if (Tools.OneIn(5))
            {
                Item item = new Item();
                item.SetDefaults(mod.ItemType<OldAxe>());
				items.RemoveAt(2);
				items.Insert(2, item);
			}
			
			Item btfadex = new Item();
			btfadex.SetDefaults(mod.ItemType<InGameWiki.Items.BTFADex>());
			btfadex.stack = 1;
			items.Add(btfadex);
		}
		
		public override void PreUpdate() 
		{
			if (GroundPound && player.controlUp && player.velocity.Y > 0)
			{
				player.velocity.Y *= 0.75f;
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType<RedFlames>(), 70, 0f, player.whoAmI);
			}
            if (GroundPound && player.controlDown)
            {
                if (!Pound && player.velocity.Y != 0f)
                {
                    Pound = true;
                    player.velocity.Y = 30f;
                    Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType<RedFlames>(), 70, 0f, player.whoAmI);
                }
                else if (Pound && player.velocity.Y == 0f)
                {
                    Pound = false;
                    Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType<RedFlameBoom>(), 105, 0f, player.whoAmI);
                }
            }
			
			if (AquaPowers && Tools.OneIn(50))
			{
                Vector2 speed = new Vector2(Main.rand.NextFloat(-1.5f, +1.5f), Main.rand.NextFloat(-1.5f, +1.5f));
				Projectile newProj = Projectile.NewProjectileDirect(player.Center, speed, mod.ProjectileType<buble>(), 18, 0f, player.whoAmI);
				newProj.melee = false;
			}
			
			if (CosmicPowers && player.statLife <= player.statLifeMax2 / 2)
			{
				player.AddBuff(mod.BuffType<CosmicBoon>(), 2, false);
			}
		}
		
		public override bool Shoot (Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (item.ranged)
			{
				speedX *= rangedVelocity;
				speedY *= rangedVelocity;
			}
			return true;
		}
		
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (CosmicPowers)
			{
				int amountOfProjectiles = Main.rand.Next(1, 3);
				for (int i = 0; i < amountOfProjectiles; i++)
				{
					float sX = Main.rand.NextFloat(-4, +4);
					float pX = Main.rand.Next(-240, +240);
					int newProj = Projectile.NewProjectile(player.Center.X + pX, player.Center.Y - 500, sX, 5, mod.ProjectileType<CosmirockMeteor>(), 45, 0f, player.whoAmI);
					Main.projectile[newProj].melee = false;
					Main.projectile[newProj].timeLeft = 1000;
				}
			}

			if (duneBonus)
			{
				player.AddBuff(mod.BuffType<DuneWinds>(), 10 * 60);
				
                for (int i = 0; i < 8; i++)
                {
                    Vector2 velocity = new Vector2(10, 0).RotatedBy((Main.rand.Next(45) + i * 45).ToRadians());
                    Dust newDust = Dust.NewDustDirect(player.Center, 0, 0, 32, velocity.X, velocity.Y);
                    newDust.noGravity = true;
                    newDust.scale = 2;
                }
			}
		}
	}
}