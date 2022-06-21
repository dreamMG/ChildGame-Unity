using Game.Dentist.Tools;
using Game.Dentist.Damage;
using System.Collections.Generic;
using System.Linq;

namespace Game.Dentist
{
	public class DenstistMission : Mission
	{
		private List<ToothDamage> toothDamages;

		public DenstistMission(DentistTool dentistTool)
		{
			dentistTool.CanUse = true;
			toothDamages = dentistTool.GetToothDamages();
			necessaryProgress = toothDamages.Count;
			toothDamages?.ForEach(x => x.OnActive?.Invoke());
		}

		public void GetDamagesToFixByTypeTool(DentistTool dentistTool)
		{
			dentistTool.Activate();
		}

		public DenstistMission(Drill drill, TeethDamagesContainer teethDamagesContainer)
		{
			drill.CanUse = true;

			necessaryProgress = toothDamages.Count;

			toothDamages?.ForEach(x => x.OnActive?.Invoke());
		}



		public void GetProgress()
		{
			currentProgress = toothDamages.Where(x => !x.Active).ToList().Count;
		}
	}
}