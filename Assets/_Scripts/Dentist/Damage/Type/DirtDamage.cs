using System;
using UnityEngine;

namespace Game.Dentist.Damage
{
	[Serializable]
	public class DirtDamage : ToothDamage
	{
		[SerializeField] private SpriteRenderer dirt;

		public SpriteRenderer Dirt => dirt;

		public override void Cause()
		{
			Active = true;
			dirt.gameObject.SetActive(true);
		}

		public override void Complete()
		{
			Active = false;
			OnComplete?.Invoke();
		}
	}
}
