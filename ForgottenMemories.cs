using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ReLogic.Graphics;
using Terraria.UI;
using System;

namespace ForgottenMemories
{
	public class ForgottenMemories : Mod 
	{
        internal static ForgottenMemories instance;
        internal bool songsLoaded = false;
        
        public ForgottenMemories()
        {
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadBackgrounds = true,
				AutoloadSounds = true,
				AutoloadGores = true
			};
		}
		
		public static ModHotKey InGameWikiHotkey;
		
        public override void Load()
        {
			InGameWikiHotkey = RegisterHotKey("In-Game Wiki Hotkey", "f");

			/*if (!Main.dedServ)
			{
				Filters.Scene["ForgottenMemories:SpookedByArte"] = new Filter(new ScreenShaderData("FilterBloodMoon"), EffectPriority.Medium);
				SkyManager.Instance["ForgottenMemories:SpookedByArte"] = new BloodSky();
			}*/

            instance = this;
        }

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			if (TGEMWorld.forestInvasionUp)
			{
				int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
				LegacyGameInterfaceLayer CustomProgress = new LegacyGameInterfaceLayer("ForgottenMemories: ProgressLayer",
				delegate
				{
					ProgressBar.DrawCustomInvasionProgress();
                    return true;
				},
				InterfaceScaleType.UI);
				layers.Insert(index, CustomProgress);
			}
		}
		
		public override void UpdateMusic(ref int music)
        {
            if (Main.invasionX == Main.spawnTileX && TGEMWorld.forestInvasionUp)
            {
                music = MusicID.Boss3;
			}
        }
		
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Iron Bar" + Lang.GetItemNameValue(ItemType("Iron Bar")), new int[]
			{
				22,
				704
			});
			RecipeGroup.RegisterGroup("AnyIron", group);
			
			RecipeGroup wood = new RecipeGroup (() => Lang.misc[37] + (" Wood"), new int[]
			{
				9,
				620,
				619,
				911,
				621,
				2503,
				2504,
				2260,
				1729
			});
			RecipeGroup.RegisterGroup("AnyWood", wood);
		}
		
		public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                // To include a description JK MEME TAG:
				bossChecklist.Call("AddBossWithInfo", "Acheron", 5.999f, (Func<bool>)(() => TGEMWorld.downedAcheron), "Use a [i:" + ItemType("Unstable_Wisp") + "] in the Underworld");
				bossChecklist.Call("AddBossWithInfo", "Magnoliac", 5.100000001f, (Func<bool>)(() => TGEMWorld.downedMag), "Summon the forest's army using [i:" + ItemType("AncientLog") + "] or use a [i:" + ItemType("MagnoliacSummoner") + "]");
				bossChecklist.Call("AddEventWithInfo", "Forest's Army", 5.1f, (Func<bool>)(() => TGEMWorld.downedForestInvasion), "Summon the forest's army using [i:" + ItemType("AncientLog") + "]");
                bossChecklist.Call("AddBossWithInfo", "Ghastly Ent", 9.4f, (Func<bool>)(() => TGEMWorld.downedGhastlyEnt), "Summon the forest's army using [i:" + ItemType("AncientLog") + "] and defeat it during hardmode, or use a [i:" + ItemType("GhastlySummon") + "]");
				bossChecklist.Call("AddBossWithInfo", "Arterius", 6.3f, (Func<bool>)(() => TGEMWorld.downedArterius), "Use a [i:" + ItemType("BloodClot") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Titan Rock", 7.1f, (Func<bool>)(() => TGEMWorld.downedTitanRock), "Use a [i:" + ItemType("anomalydetector") + "]");
			}

            Mod btfaSongs = ModLoader.GetMod("BTFASongs");
            if (btfaSongs != null)
            {
                songsLoaded = true;
            }
        }
	}
}
