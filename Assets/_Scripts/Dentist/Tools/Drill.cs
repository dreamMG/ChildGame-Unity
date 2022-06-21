using Game.Dentist.Damage;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Dentist.Tools
{
	public class Drill : DentistTool
	{
		public override void Activate()
		{
			//PlaySound();			
			SpawnParticles();
		}

		public override void Stop()
		{
			StopParticles();
		}

		public override List<ToothDamage> GetToothDamages()
		{
			return dentistManager.TeethDamagesContainer.ToothDamagesContainers.Where(x => x.CavitiesDamage.Active).Select(x => (ToothDamage)x.CavitiesDamage).ToList();
		}

		private void Drilling(CavitiesDamage cavitiesDamage)
		{
			cavitiesDamage.ValueOfComplete += Time.deltaTime;
			cavitiesDamage.CavitiesSpriteRenderer.color = Color.Lerp(Color.black, cavitiesDamage.ToothSpriteRenderer.color, cavitiesDamage.ValueOfComplete);

			if (cavitiesDamage.ValueOfComplete > .8f)
			{
				cavitiesDamage.CavitiesSpriteRenderer.gameObject.SetActive(false);
				cavitiesDamage.Complete();
			}
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			if (!CanUse) return;

			if (collision.TryGetComponent<Tooth>(out var tooth))
			{
				if (tooth.ToothDamages.CavitiesDamage.Active)
				{
					Activate();
					Drilling(tooth.ToothDamages.CavitiesDamage);
				}
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			Stop();
		}
	}
}
