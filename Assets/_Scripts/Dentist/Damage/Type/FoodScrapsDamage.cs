using System;
using UnityEngine;

namespace Game.Dentist.Damage
{
	[Serializable]
	public class FoodScrapsDamage : ToothDamage
	{
		[SerializeField] private Collider2D collider2D;

		public Transform ScrapsTransform => collider2D.transform;

		public override void Cause()
		{
			Active = true;
			collider2D.gameObject.SetActive(true);
		}

		public override void Complete()
		{
			collider2D.enabled = false;

			Active = false;
			OnComplete?.Invoke();
		}
	}
}
