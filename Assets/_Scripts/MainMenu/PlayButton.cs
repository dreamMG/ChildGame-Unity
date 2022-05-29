using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.MainMenu
{
	public class PlayButton : Button
	{
		[SerializeField] private MainMenuSettings menuSettings;
		[SerializeField] private TextMeshProUGUI text;

		[SerializeField] private Animator animator;
		[SerializeField] private Image fade;

		protected override void Awake()
		{
			base.Awake();
			transform.DOScale(menuSettings.Scale, menuSettings.Duration).SetEase(menuSettings.Ease).SetLoops(-1, menuSettings.LoopType);
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			transform.DOKill();
			transform.DOScale(1, menuSettings.Duration).OnComplete(() =>
			{
				animator.gameObject.SetActive(true);
				animator.Play("PlayAnimation");
				text.enabled = false;

				fade.DOFade(1, 2f).SetDelay(3f).OnComplete(() =>
				{
					SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
				});
			});
		}
	}
#if UNITY_EDITOR
	[CustomEditor(typeof(PlayButton))]
	public class PlayButtonEditor : Editor
	{
	}
#endif
}