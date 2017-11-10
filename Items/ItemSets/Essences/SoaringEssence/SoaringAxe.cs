using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;


namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence 
{
public class SoaringAxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 5;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 12;
        item.useAnimation = 15;
        item.useStyle = 1;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.axe = 7;
		item.hammer = 35;
		item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Soaring Hamaxe");
      Tooltip.SetDefault("");
    }
	
	public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SoaringDust"));
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
		}

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}
