using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.ItemSets.Acheron     //The directory for your .cs and .png; Example: Mod Sources/TutorialMOD/Items
{
    public class Thanatos : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 50;     //The damage stat for the Weapon.
            item.melee = true;      //This defines if it does Melee damage and if its effected by Melee increasing Armor/Accessories.
            item.width = 35;   //The size of the width of the hitbox in pixels.
            item.height = 35;  //The size of the height of the hitbox in pixels.          
            item.useTime = 40;   //How fast the Weapon is used.
            item.useAnimation = 20;     //How long the Weapon is used for.
			item.useTurn = true;
			item.scale = 1f;
            item.useStyle = 1;            //The way your Weapon will be used, 1 is the regular sword swing for example
            item.knockBack = 15;  //The knockback stat of your Weapon.
            item.value = Item.sellPrice(0, 9, 0, 0); // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 4;    //The color the title of your Weapon when hovering over it ingame
            item.UseSound = SoundID.Item34;   //The sound played when using your Weapon
			item.shoot = mod.ProjectileType("HomingThanatosPre");
			item.shootSpeed = 0f;
            item.autoReuse = true; //Weather your Weapon will be used again after use while holding down, if false you will need to click again after use to use it again.
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thanatos");
            Tooltip.SetDefault("Releases homing thanatos skulls on swing");
        }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 111);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1f;
			}
		}
    }
}
