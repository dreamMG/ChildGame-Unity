namespace Game.UI
{
	public class FinishPanelController
	{
		[Zenject.Inject] private FinishPanel finishPanel;

		public void Open()
		{
			finishPanel.Subscribe();
			finishPanel.gameObject.SetActive(true);
			finishPanel.AnimationOnShow();
		}

		public void Close()
		{
			finishPanel.Unsubscribe();
			finishPanel.gameObject.SetActive(false);
		}
	}
}
