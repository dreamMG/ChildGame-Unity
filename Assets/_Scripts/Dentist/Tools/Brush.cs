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

		private void Brushing(Tooth tooth)
		{
			tooth.ValueOfComplete += Time.deltaTime;
			tooth.SpriteRenderer.color = Color.Lerp(Color.yellow, Color.white, tooth.ValueOfComplete);

			if(tooth.ValueOfComplete > 1)
			{
			}
		}

		private void OnTriggerStay2D(UnityEngine.Collider2D collision)
		{
			if (collision.TryGetComponent<Tooth>(out var tooth))
			{
				if (tooth.TypeOfDamages.Contains(TypeOfDamage.Yellowness))
				{
					Activate();
					Brushing(tooth);
				}
			}
		}

		private void OnTriggerExit2D(UnityEngine.Collider2D collision)
		{
			Stop();
		}
	}
}
