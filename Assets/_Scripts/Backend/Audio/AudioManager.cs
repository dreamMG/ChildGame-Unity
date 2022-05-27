using UnityEngine;

namespace Game.Backend
{
	public class AudioManager
	{
		[Zenject.Inject] private AudioSource audio;

		public void PlayClip(AudioClip clip)
		{
			audio.PlayOneShot(clip);
		}
	}
}
