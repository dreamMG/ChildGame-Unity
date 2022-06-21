using UnityEngine;
using Zenject;

namespace Game.Dentist
{
	public class DentistInstaller : MonoInstaller
	{
		[SerializeField] private DentistManager dentistManager;

		public override void InstallBindings()
		{
			Container.Bind<DentistManager>().FromInstance(dentistManager).AsSingle();
		}
	}
}
