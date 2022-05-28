using Game.Dentist.Damage;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Dentist
{
	public class Tooth : MonoBehaviour
	{
		[SerializeField] private ToothDamagesContainer toothDamages;

		public ToothDamagesContainer ToothDamages => toothDamages;
	}
}

