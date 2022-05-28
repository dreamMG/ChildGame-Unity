using UnityEngine;

namespace Game.Dentist.Tools
{
	[CreateAssetMenu(fileName ="DentistTool", menuName ="Game/Dentist/DentistTool")]
	public class DentistToolSetting : ScriptableObject
	{
		[SerializeField] private AudioClip[] audioClips;
		[SerializeField] private Sprite sprite;

		public AudioClip[] AudioClips => audioClips;
		public Sprite Sprite => sprite;
	}
}