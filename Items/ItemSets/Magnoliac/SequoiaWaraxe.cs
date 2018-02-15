using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Magnoliac
{
    public class SequoiaWaraxe : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 30;
            item.melee = true;
            item.width = 20;
            item.height = 12;
            item.useTime = 12;
            item.useAnimation = 37;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 50000;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
			item.axe = 24;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Walnut Waraxe");
            Tooltip.SetDefault("Creates an upwards facing vine upon critical striking an enemy");
        }
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	    {
		    if (crit)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, -10f, 7, item.damage, 3f, player.whoAmI);
            }		
		}
    }
}
