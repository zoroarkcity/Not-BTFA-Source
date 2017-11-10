using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.UI;
using Terraria.ModLoader;
using ForgottenMemories;

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

		
		const int ShakeLength = 5;
		int ShakeCount = 0;
		float previousRotation = 0;
		float targetRotation = 0;
		float previousOffsetX = 0;
		float previousOffsetY = 0;
		float targetOffsetX = 0;
		float targetOffsetY = 0;
		
		public override Matrix ModifyTransformMatrix(Matrix Transform)
		{
			if (!Main.gameMenu)
			{
				TGEMWorld world = GetModWorld<TGEMWorld>();
				if (TGEMWorld.TremorTime > 0)
				{
					if (TGEMWorld.TremorTime % ShakeLength == 0)
					{
						ShakeCount = 0;
						previousRotation = targetRotation;
						previousOffsetX = targetOffsetX;
						previousOffsetY = targetOffsetY;
						targetRotation = (Main.rand.NextFloat() - .5f) * MathHelper.ToRadians(7);
						targetOffsetX = Main.rand.Next(60) - 30;
						targetOffsetY = Main.rand.Next(40) - 20;
						if (TGEMWorld.TremorTime == ShakeLength)
						{
							targetRotation = 0;
							targetOffsetX = 0;
							targetOffsetY = 0;
						}
					}
					float transX = Main.screenWidth / 2;
					float transY = Main.screenHeight / 2;

					float lerp = (float)(ShakeCount) / ShakeLength;
					float rotation = MathHelper.Lerp(previousRotation, targetRotation, lerp);
					float offsetX = MathHelper.Lerp(previousOffsetX, targetOffsetX, lerp);
					float offsetY = MathHelper.Lerp(previousOffsetY, targetOffsetY, lerp);

					TGEMWorld.TremorTime--;
					ShakeCount++;


					return Transform
						* Matrix.CreateTranslation(-transX, -transY, 0f)
						* Matrix.CreateRotationZ(rotation)
						* Matrix.CreateTranslation(transX, transY, 0f)
						* Matrix.CreateTranslation(offsetX, offsetY, 0f);
					//Matrix.CreateFromAxisAngle(new Vector3(Main.screenWidth / 2, Main.screenHeight / 2, 0f), .2f);
					//Matrix.CreateRotationZ(MathHelper.ToRadians(30));
				}
			}
			return Transform;
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
                bossChecklist.Call("AddBossWithInfo", "Ghastly Ent", 9.4f, (Func<bool>)(() => TGEMWorld.downedGhastlyEnt), "Summon the forest's army using [i:" + ItemType("AncientLog") + "] and defeat it during hardmode");
				bossChecklist.Call("AddBossWithInfo", "Arterius", 6.3f, (Func<bool>)(() => TGEMWorld.downedArterius), "Use a [i:" + ItemType("BloodClot") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Titan Rock", 6.9f, (Func<bool>)(() => TGEMWorld.downedTitanRock), "Use a [i:" + ItemType("anomalydetector") + "]");
			}
        }
	}
}
