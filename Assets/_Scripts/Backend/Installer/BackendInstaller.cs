using Game.Input;
using Game.UI;
using UnityEngine;
using Zenject;

namespace Game.Backend
{
	public class BackendInstaller : MonoInstaller
	{
		[Header("Input")]
		[SerializeField] private InputDenstist inputGlobal;
		[Header("Audio")]
		[SerializeField] private AudioSource audioEffect;
		[Header("Cameras")]
		[SerializeField] private CamerasManager camerasManager;
		[Header("UI")]
		[SerializeField] private FinishPanel finishPanel;

		public override void InstallBindings()
		{
			InstallInput();
			InstallAudio();
			InstallCameras();
			InstallUI();
		}

		private void InstallInput()
		{
			Container.Bind<InputDenstist>().FromInstance(inputGlobal).AsSingle();
			Container.Bind<InputMaster>().AsSingle();
		}

		private void InstallAudio()
		{
			Container.Bind<AudioManager>().AsSingle().WithArguments(audioEffect);
		}

		private void InstallCameras()
		{
			Container.Bind<CamerasManager>().FromInstance(camerasManager).AsSingle();
		}

		private void InstallUI()
		{
			Container.Bind<FinishPanelController>().AsSingle().WithArguments(finishPanel);
		}
	}
}
