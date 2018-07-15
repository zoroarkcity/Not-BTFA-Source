using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria;
using Terraria.ID;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using ReLogic.Graphics;
using Terraria.GameContent.UI;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Encrested_Wand    
{
	public class Encrested_Wand_Projectile : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.width = 4;
            projectile.height = 100;
			projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.magic = true;
			projectile.damage = 1;
			projectile.penetrate = -1;
		}
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Encrested Barrier");
        } 
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			projectile.active = false;
			return true;
        }
        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			
			for(int i = 0; i < Main.npc.Length; i++)
			{
				NPC npc = Main.npc[i];
				if (npc.active && player.active && !npc.friendly && npc.damage >= 1 && (double) Vector2.Distance(projectile.Center, npc.Center) <= (double) 250f)
				{
					projectile.damage = npc.height / 3;
					projectile.width = npc.width / 2;
				}
			}
			
			float num = (float) (projectile.width * projectile.height) * 0.0045f;
            for (int index1 = 0; (double) index1 < (double) num; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0.0f, 0.0f, 100, new Color(), 1f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.5f;
				Main.dust[index2].velocity.Y -= 0.5f;
				Main.dust[index2].scale = 1.4f;
				Main.dust[index2].position.X += 6f;
				Main.dust[index2].position.Y -= 2f;
			}
		}
		public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item122, projectile.position);
			int index4 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
			Main.gore[index4].velocity *= 0.4f;
			Main.gore[index4].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
			Main.gore[index4].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
			int index5 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
			Main.gore[index5].velocity *= 0.4f;
			Main.gore[index5].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
			Main.gore[index5].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
			
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("Red_Explosion_Invisible"), 0, 0f, projectile.owner, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("Red_Explosion_Invisible_2"), 0, 0f, projectile.owner, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("Red_Explosion_Invisible_3"), 0, 0f, projectile.owner, 0.0f);
		}
	}
}