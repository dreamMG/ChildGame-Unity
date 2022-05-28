using Game.Dentist.Damage;
using UnityEngine;

namespace Game.Dentist.Tools
{
	public class Brush : DentistTool
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

		private void Brushing(YellownessDamage yellownessDamage)
		{
			yellownessDamage.ValueOfComplete += Time.deltaTime;
			yellownessDamage.SpriteRenderer.color = Color.Lerp(Color.yellow, Color.white, yellownessDamage.ValueOfComplete * .8f);

			if (yellownessDamage.ValueOfComplete > .8f)
			{
				yellownessDamage.Active = false;
				yellownessDamage.SpriteRenderer.color = Color.white;
			}
		}

		private void Brushing(DirtDamage dirtDamage)
		{
			dirtDamage.ValueOfComplete += Time.deltaTime;
			dirtDamage.Dirt.color = Color.Lerp(dirtDamage.Dirt.color, new Color(1, 1, 1, 0), dirtDamage.ValueOfComplete * .8f);

			if (dirtDamage.ValueOfComplete > .8f)
			{
				dirtDamage.Dirt.gameObject.SetActive(false);
				dirtDamage.Complete();
			}
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			if (!CanUse) return;

			if (collision.TryGetComponent<Tooth>(out var tooth))
			{
				if (tooth.ToothDamages.YellownessDamage.Active)
				{
					Activate();
					Brushing(tooth.ToothDamages.YellownessDamage);
				}

				if (tooth.ToothDamages.DirtDamage.Active)
				{
					Activate();
					Brushing(tooth.ToothDamages.DirtDamage);
				}
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			Stop();
		}
	}
}
