using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.ChooseGame
{
	public class MiniGame : MonoBehaviour
	{
		[SerializeField] private Button playButton;
		[SerializeField] private int sceneIndex;

		private void OnEnable()
		{
			playButton.onClick.AddListener(LoadScene);
		}

		private void OnDisable()
		{
			playButton.onClick.RemoveListener(LoadScene);
		}

		public void LoadScene()
		{
			SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
		}

		public void ActiveTween()
		{
			playButton.transform.DOScale(1.25f, .5f).SetLoops(-1, LoopType.Yoyo);
		}

		public void StopTween()
		{
			playButton.transform.DOKill();
			playButton.transform.DOScale(1f, .5f);
		}
	}
}