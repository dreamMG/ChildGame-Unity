using Zenject;

namespace Game.Dentist
{
	public class DentistInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<DamageOfTooth>().AsSingle();
		}
	}
}
