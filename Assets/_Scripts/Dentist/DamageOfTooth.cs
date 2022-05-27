using UnityEngine;

namespace Game.Dentist
{
	public class DamageOfTooth
	{
		public void CauseDamage(Tooth tooth)
		{
			foreach (var typeOfDamage in tooth.TypeOfDamages)
			{
				switch (typeOfDamage)
				{
					case TypeOfDamage.Yellowness:
						CauseYellowness(tooth);
						break;
					case TypeOfDamage.Cavities:
						break;
					default:
						break;
				}
			}
			
		}

		private void CauseYellowness(Tooth tooth)
		{
			tooth.SpriteRenderer.color = Color.yellow;
		}
	}
}
