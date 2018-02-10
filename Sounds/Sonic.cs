using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Sounds
{
	public class Sonic : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * .5f;
			soundInstance.Pan = pan;
			soundInstance.Pitch = -1.0f; //Make sure you want to change the pitch dudes, I thought this was necessary but it just messes up the speed and sound
			return soundInstance;
		}
	}
}
