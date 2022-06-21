using Game.Backend;
using Game.Dentist.Damage;
using Game.Input;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Dentist.Tools
{
	public abstract class DentistTool : MonoBehaviour, IMoveable, IBackToStartPosition
	{
		[SerializeField] private DentistToolSetting setting;
		[SerializeField] private ParticleSystem particle;

		[Zenject.Inject] private AudioManager audioManager;
		[Zenject.Inject] private InputDenstist inputGlobal;
		[Zenject.Inject] protected DentistManager dentistManager;

		private Vector2 startPos;

		public bool CanUse { get; set; }
		public Sprite Sprite => setting.Sprite;

		private void Awake()
		{
			startPos = transform.position;
		}

		public abstract void Activate();

		public abstract void Stop();

		public abstract List<ToothDamage> GetToothDamages();

		public void Move(Vector2 pos)
		{
			transform.position = pos;
		}
		public void BackToStartPos()
		{
			inputGlobal.Moveable = null;
			transform.position = startPos;
		}

		protected void PlaySound()
		{
			audioManager.PlayClip(setting.AudioClips[Random.Range(0, setting.AudioClips.Length)]);
		}

		protected void SpawnParticles()
		{
			particle.Play();
		}

		protected void StopParticles()
		{
			particle.Stop();
		}
	}
}
