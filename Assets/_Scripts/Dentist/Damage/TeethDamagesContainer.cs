using System.Collections.Generic;
using UnityEngine;

namespace Game.Dentist.Damage
{
	public class TeethDamagesContainer : MonoBehaviour
	{
		[SerializeField] private List<FoodScrapsDamage> foodScrapsDamage;
		[SerializeField] private List<ToothDamagesContainer> toothDamagesContainers;

		[Zenject.Inject] private DentistManager dentistManager;

		public List<FoodScrapsDamage> FoodScrapsDamage => foodScrapsDamage;
		public List<ToothDamagesContainer> ToothDamagesContainers => toothDamagesContainers;

		private void Start()
		{
			toothDamagesContainers.ForEach(x => x.TryActive());
			Active();
		}

		private void Active()
		{
			FoodScrapsDamage.ForEach(x =>
			{
				x.Cause();
				x.OnComplete += CheckTheProgress;
			});
		}

		private void CheckTheProgress()
		{
			dentistManager.OnProgressGetted.Invoke();
		}
	}
}
