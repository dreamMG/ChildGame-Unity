using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Dentist.Damage
{
	public class ToothDamagesContainer : MonoBehaviour
	{
		[SerializeField] private CavitiesDamage cavitiesDamage;
		[SerializeField] private YellownessDamage yellownessDamage;
		[SerializeField] private DirtDamage dirtDamage;
		[Header("Other")]
		[SerializeField] private SpriteRenderer activeRender;

		[Zenject.Inject] private DentistManager dentistManager;

		private List<ToothDamage> toothDamages;

		public CavitiesDamage CavitiesDamage => cavitiesDamage;
		public YellownessDamage YellownessDamage => yellownessDamage;
		public DirtDamage DirtDamage => dirtDamage;

		private void Awake()
		{
			toothDamages = new List<ToothDamage> { cavitiesDamage, yellownessDamage, dirtDamage };
		}

		public void TryActive()
		{
			foreach (var toothDamage in toothDamages)
			{
				if (Random.value > .5f)
				{
					toothDamage.Cause();
					toothDamage.OnActive += Active;
					toothDamage.OnComplete += Disactive;
					toothDamage.OnComplete += CheckTheProgress;
				}
			}
		}

		private void Active()
		{
			activeRender.gameObject.SetActive(true);

			if (!DOTween.IsTweening(activeRender))
			{
				activeRender.DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo);
			}
		}

		private void Disactive()
		{
			activeRender.gameObject.SetActive(false);
			activeRender.DOKill();
			activeRender.color = new Color(activeRender.color.r, activeRender.color.g, activeRender.color.b, 1);
		}

		private void CheckTheProgress()
		{
			dentistManager.OnProgressGetted.Invoke();
		}
	}
}
