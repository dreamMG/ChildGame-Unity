using System.Collections.Generic;
using UnityEngine;

namespace Game.Dentist.Damage
{
	public class ToothDamagesContainer : MonoBehaviour
	{
		[SerializeField] private CavitiesDamage cavitiesDamage;
		[SerializeField] private YellownessDamage yellownessDamage;
		[SerializeField] private DirtDamage dirtDamage;

		private List<ToothDamage> toothDamages;

		public CavitiesDamage CavitiesDamage => cavitiesDamage;
		public YellownessDamage YellownessDamage => yellownessDamage;
		public DirtDamage DirtDamage => dirtDamage;

		private void Awake()
		{
			toothDamages = new List<ToothDamage> { cavitiesDamage, yellownessDamage, dirtDamage };

			TryActive();
		}

		private void TryActive()
		{
			foreach (var toothDamage in toothDamages)
			{
				if(Random.value < .5f)
				{
					toothDamage.Cause();
				}
			}
		}
	}
}
