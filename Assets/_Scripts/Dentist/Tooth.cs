using System.Collections.Generic;
using UnityEngine;

namespace Game.Dentist
{
	public class Tooth : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private List<TypeOfDamage> typeOfDamages;

		[Zenject.Inject] private DamageOfTooth damageOfTooth;

		public SpriteRenderer SpriteRenderer => spriteRenderer;
		public List<TypeOfDamage> TypeOfDamages => typeOfDamages;

		public float ValueOfComplete { get; set; }

		private void Awake()
		{
			damageOfTooth.CauseDamage(this);
		}
	}
}

