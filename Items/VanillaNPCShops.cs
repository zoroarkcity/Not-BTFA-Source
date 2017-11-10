using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items
{
    public class VanillaNPCShops : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {	
				case NPCID.WitchDoctor:
                {				
			        if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.WormholePotion);
                        nextSlot++;
                    }
				    break;
				}
				
				case NPCID.SkeletonMerchant:
                {				
			        if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType("BoneFungus"));
                        nextSlot++;
                    }
				    break;
                }
            }
        }
    }
}