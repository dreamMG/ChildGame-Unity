using System;
using UnityEngine;

namespace Game.Dentist.Damage
{
	[Serializable]
	public class CavitiesDamage : ToothDamage
	{
		[SerializeField] private SpriteRenderer cavitiesSpriteRenderer;
		[SerializeField] private SpriteRenderer toothSpriteRenderer;

		public SpriteRenderer CavitiesSpriteRenderer => cavitiesSpriteRenderer;
		public SpriteRenderer ToothSpriteRenderer => toothSpriteRenderer;

		public override void Cause()
		{
			Active = true;
			cavitiesSpriteRenderer.gameObject.SetActive(true);
		}

		public override void Complete()
		{
			Active = false;
		}
	}
}
