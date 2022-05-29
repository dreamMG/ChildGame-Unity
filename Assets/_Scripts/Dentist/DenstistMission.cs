using Game.Dentist.Tools;
using Game.Dentist.Damage;
using System.Collections.Generic;
using System.Linq;

namespace Game.Dentist
{
	public class DenstistMission : Mission
	{
		private List<ToothDamage> toothDamages;

		public DenstistMission(DentistTool dentistTool, TeethDamagesContainer teethDamagesContainer)
		{
			dentistTool.CanUse = true;

			if (dentistTool is Brush)
			{
				toothDamages = teethDamagesContainer.ToothDamagesContainers.Where(x => x.DirtDamage.Active).Select(x => (ToothDamage)x.DirtDamage).ToList();
				toothDamages.AddRange(teethDamagesContainer.ToothDamagesContainers.Where(x => x.YellownessDamage.Active).Select(x => (ToothDamage)x.YellownessDamage).ToList());

				necessaryProgress = toothDamages.Count;
			}

			if (dentistTool is Tweezers)
			{
				toothDamages = teethDamagesContainer.FoodScrapsDamage.Select(x => (ToothDamage)x).ToList();
				necessaryProgress = toothDamages.Count;
			}

			if (dentistTool is Drill)
			{
				toothDamages = teethDamagesContainer.ToothDamagesContainers.Where(x => x.CavitiesDamage.Active).Select(x => (ToothDamage)x.CavitiesDamage).ToList();
				necessaryProgress = toothDamages.Count;
			}

			toothDamages?.ForEach(x => x.onActive?.Invoke());
		}

		public void GetProgress()
		{
			currentProgress = toothDamages.Where(x => !x.Active).ToList().Count;
		}
	}
}