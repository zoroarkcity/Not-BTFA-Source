using System;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class ColdShuriken : ModProjectile
	{
		int cap;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
            projectile.aiStyle = 2;
			aiType = ProjectileID.Shuriken;
			projectile.penetrate = -1;
			projectile.thrown = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.friendly = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Shuriken");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(5) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("ColdShuriken"));
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 vector2 = new Vector2(projectile.width/2, projectile.height/2);
			int dust;
			Vector2 newVect = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
			Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
			Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
			Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
			Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
			Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
			Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
			Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
			dust = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect.X, newVect.Y);
			int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect2.X, newVect2.Y);
			int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect3.X, newVect3.Y);
			int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect4.X, newVect4.Y);
			int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect5.X, newVect5.Y);
			int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect6.X, newVect6.Y);
			int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect7.X, newVect7.Y);
			int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BlizzardDust"), newVect8.X, newVect8.Y);
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
		
		public override void AI()
		{
			projectile.rotation += MathHelper.Pi / 60;
			cap--;
		}
	}
}	