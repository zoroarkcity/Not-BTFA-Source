using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ForgottenMemories;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;

namespace ForgottenMemories
{
	public class ForgottenMemories : Mod 
	{
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
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/ForestArmy");
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
				bossChecklist.Call("AddBossWithInfo", "Acheron", 5.5f, (Func<bool>)(() => TGEMWorld.downedAcheron), "Use a [i:" + ItemType("Unstable Wisp") + "] in the Underworld");
				bossChecklist.Call("AddBossWithInfo", "Magnoliac", 4.1f, (Func<bool>)(() => TGEMWorld.downedMag), "Summon the forest's army using [i:" + ItemType("AncientLog") + "]");
				bossChecklist.Call("AddEventWithInfo", "Forest's Army", 4.1f, (Func<bool>)(() => TGEMWorld.downedForestInvasion), "Summon the forest's army using [i:" + ItemType("AncientLog") + "]");
                bossChecklist.Call("AddBossWithInfo", "Ghastly Ent", 9.4f, (Func<bool>)(() => TGEMWorld.downedGhastlyEnt), "Summon the forest's army using [i:" + ItemType("AncientLog") + "] and defeat it during hardmode");
				bossChecklist.Call("AddBossWithInfo", "Arterius", 6.3f, (Func<bool>)(() => TGEMWorld.downedArterius), "Use a [i:" + ItemType("BloodClot") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Titan Rock", 6.9f, (Func<bool>)(() => TGEMWorld.downedTitanRock), "Use a [i:" + ItemType("anomalydetector") + "]");
			}
        }
	}
}
