using System.Collections.Generic;
using UnityEngine;

namespace Game.Dentist.Damage
{
	public class TeethDamagesContainer : MonoBehaviour
	{
		[SerializeField] private List<FoodScrapsDamage> foodScrapsDamage;
		[SerializeField] private List<ToothDamagesContainer> toothDamagesContainers;

		public List<FoodScrapsDamage> FoodScrapsDamage => foodScrapsDamage;
		public List<ToothDamagesContainer> ToothDamagesContainers => toothDamagesContainers;

		private void Awake()
		{
			Active();
		}

		private void Active()
		{
			FoodScrapsDamage.ForEach(x => x.Cause());
		}
	}
}
