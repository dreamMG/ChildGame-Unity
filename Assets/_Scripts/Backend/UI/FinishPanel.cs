using DG.Tweening;
using Game.Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class FinishPanel : MonoBehaviour
	{
		[SerializeField] private CanvasGroup canvasGroup;
		[SerializeField] private Button retryButton;
		[SerializeField] private Button exitButton;

		public void Subscribe()
		{
			retryButton.onClick.AddListener(() => ScenesManager.LoadScene(SceneName.Dentist));
			exitButton.onClick.AddListener(() => ScenesManager.LoadScene(SceneName.MiniGames));
		}

		public void Unsubscribe()
		{
			retryButton.onClick.RemoveAllListeners();
			exitButton.onClick.RemoveAllListeners();
		}

		public void AnimationOnShow()
		{
			canvasGroup.transform.localScale = Vector3.zero;
			canvasGroup.alpha = 0;

			canvasGroup.transform.DOScale(1, .5f).SetEase(Ease.InOutBack);
			canvasGroup.DOFade(1, .25f);
		}
	}
}
