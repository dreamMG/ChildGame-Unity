using System;
using UnityEngine;

namespace Game.Dentist.Damage
{
	[Serializable]
	public class FoodScrapsDamage : ToothDamage
	{
		[SerializeField] private Transform scrapsTransform;

		public Transform ScrapsTransform => scrapsTransform;

		public override void Cause()
		{
			Active = true;
			scrapsTransform.gameObject.SetActive(true);
		}

		public override void Complete()
		{
			Active = false;
		}
	}
}
