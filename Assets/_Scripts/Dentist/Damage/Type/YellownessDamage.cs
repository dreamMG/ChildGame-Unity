using System;
using UnityEngine;

namespace Game.Dentist.Damage
{
	[Serializable]
	public class YellownessDamage : ToothDamage
	{
		[SerializeField] private SpriteRenderer spriteRenderer;

		public SpriteRenderer SpriteRenderer => spriteRenderer;

		public override void Cause()
		{
			Active = true;
			spriteRenderer.color = Color.yellow;
		}

		public override void Complete()
		{
			Active = false;
		}
	}
}
