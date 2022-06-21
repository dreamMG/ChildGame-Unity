using System;

namespace Game.Dentist.Damage
{
	public abstract class ToothDamage
	{
		public Action OnActive;
		public Action OnComplete;

		[Zenject.Inject] protected DentistManager dentistManager;

		public float ValueOfComplete { get; set; }
		public bool Active { get; set; }

		public abstract void Cause();

		public abstract void Complete();
	}
}
