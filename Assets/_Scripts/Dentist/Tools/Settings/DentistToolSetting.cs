using UnityEngine;

namespace Game.Dentist.Tools
{
	[CreateAssetMenu(fileName ="DentistTool", menuName ="Game/Dentist/DentistTool")]
	public class DentistToolSetting : ScriptableObject
	{
		[SerializeField] private AudioClip[] audioClips;

		public AudioClip[] AudioClips => audioClips;
	}
}