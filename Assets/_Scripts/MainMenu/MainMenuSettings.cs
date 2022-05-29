using UnityEngine;
using DG.Tweening;

namespace Game.MainMenu
{
	[CreateAssetMenu(fileName = "MainMenuSettings", menuName = "Game/MainMenu/MainMenuSettings")]
	public class MainMenuSettings : ScriptableObject
	{
		[Header("PlayController")]
		[SerializeField] private float scale;
		[SerializeField] private float duration;
		[SerializeField] private Ease ease;
		[SerializeField] private LoopType loopType;

		public float Scale { get => scale; set => scale = value; }
		public float Duration { get => duration; set => duration = value; }
		public Ease Ease { get => ease; set => ease = value; }
		public LoopType LoopType { get => loopType; set => loopType = value; }
	}
}
