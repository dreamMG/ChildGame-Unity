using Game.Input;
using UnityEngine;
using Zenject;

namespace Game.Backend
{
	public class BackendInstaller : MonoInstaller
	{
		[Header("Input")]
		[SerializeField] private InputGlobal inputGlobal;
		[Header("Audio")]
		[SerializeField] private AudioSource audioEffect;
		[Header("Cameras")]
		[SerializeField] private CamerasManager camerasManager;

		public override void InstallBindings()
		{
			InstallInput();
			InstallAudio();
			InstallCameras();
		}

		private void InstallInput()
		{
			Container.Bind<InputGlobal>().FromInstance(inputGlobal).AsSingle();
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
	}
}
