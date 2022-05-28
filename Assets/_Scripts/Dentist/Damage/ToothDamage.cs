using System;

namespace Game.Dentist.Damage
{
	public abstract class ToothDamage
	{
		public float ValueOfComplete { get; set; }
		public bool Active { get; set; }

		public abstract void Cause();
		public abstract void Complete();
	}
}
