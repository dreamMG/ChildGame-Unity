using DG.Tweening;
using System.Collections;
using UnityEngine;
using Game.Dentist.Damage;
using System.Collections.Generic;
using System.Linq;

namespace Game.Dentist.Tools
{
	public class Tweezers : DentistTool
	{
		[Header("Tweezers")]
		[SerializeField] private Transform deckTransform;

		private Transform takedScrap;

		public override void Activate()
		{
			deckTransform.DOMove(deckTransform.position + new Vector3(3, 0), .5f);
		}

		public override List<ToothDamage> GetToothDamages()
		{
			return dentistManager.TeethDamagesContainer.FoodScrapsDamage.Select(x => (ToothDamage)x).ToList();
		}

		public override void Stop()
		{
			if (takedScrap == null) return;

			var foodScrapsDamage = dentistManager.TeethDamagesContainer.FoodScrapsDamage.Find(x => x.ScrapsTransform == takedScrap);

			if (foodScrapsDamage != null)
			{
				foodScrapsDamage.Complete();
			}

			takedScrap.SetParent(deckTransform);
			takedScrap.localPosition = Vector3.zero;
			dentistManager.TeethDamagesContainer.FoodScrapsDamage.Find(x => x.ScrapsTransform == takedScrap).Active = false;
			takedScrap = null;

			BackToStartPos();
			deckTransform.DOMove(deckTransform.position - new Vector3(3, 0), .5f);
		}

		private void Tweezing(Transform foodScraps)
		{
			takedScrap = foodScraps;
			takedScrap.GetComponent<SpriteRenderer>().sortingLayerName = "UnderUI";
			takedScrap.GetComponent<SpriteRenderer>().sortingOrder = 100;
			StartCoroutine(FollowTweezers());
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (!CanUse) return;

			if (collision.CompareTag("Scraps") && takedScrap == null)
			{
				Activate();
				Tweezing(collision.transform);
			}

			if (collision.CompareTag("Deck") && takedScrap != null)
			{
				Stop();
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			//Stop();
		}

		private IEnumerator FollowTweezers()
		{
			while (takedScrap != null)
			{
				takedScrap.position = transform.position + new Vector3(0, 1.25f);
				yield return new WaitForEndOfFrame();
			}
		}
	}
}
