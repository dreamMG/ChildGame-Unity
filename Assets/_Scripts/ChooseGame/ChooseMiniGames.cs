using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.ChooseGame
{
	public class ChooseMiniGames : MonoBehaviour
	{
		[SerializeField] private MiniGame[] miniGames;
		[Header("Buttons")]
		[SerializeField] private Button leftButton;
		[SerializeField] private Button rightButton;
		[SerializeField] private Image fade;

		private int currentIndex;

		private void Awake()
		{
			miniGames[currentIndex].ActiveTween();
			fade.DOFade(0, 3f);
		}

		private void OnEnable()
		{
			leftButton.onClick.AddListener(() => SwitchMiniGames(leftButton.transform, -1));
			rightButton.onClick.AddListener(() => SwitchMiniGames(rightButton.transform, 1));
		}

		private void OnDisable()
		{
			leftButton.onClick.RemoveListener(() => SwitchMiniGames(leftButton.transform, -1));
			rightButton.onClick.RemoveListener(() => SwitchMiniGames(rightButton.transform, 1));
		}

		private void SwitchMiniGames(Transform transform, int index)
		{
			if (!DOTween.IsTweening(transform))
			{
				transform.DOScale(1.3f, .15f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutBack);
			}
			miniGames[currentIndex].StopTween();
			currentIndex = (currentIndex + index) % miniGames.Length;

			if (currentIndex == -1) currentIndex = miniGames.Length - 1;

			MoveToCurrentIndex();
		}

		private void MoveToCurrentIndex()
		{
			transform.DOLocalMove(new Vector3(-1080 * currentIndex, 0), .25f);
			miniGames[currentIndex].ActiveTween();
		}

#if UNITY_EDITOR
		private void Reset()
		{
			miniGames = FindObjectsOfType<MiniGame>();
			var buttons = FindObjectsOfType<Button>();

			for (int i = 0; i < buttons.Length; i++)
			{
				if (buttons[i].name == "LeftButton")
				{
					leftButton = buttons[i];
				}

				if (buttons[i].name == "RightButton")
				{
					rightButton = buttons[i];
				}
			}
		}
#endif
	}
}
