using Game.Backend;
using UnityEngine;

namespace Game.Dentist.Tools
{
	public abstract class DentistTool : MonoBehaviour, IMoveable, IBackToStartPosition
	{
        [SerializeField] private DentistToolSetting setting;
        [SerializeField] private ParticleSystem particle;

        [Zenject.Inject] private AudioManager audioManager;

        private Vector2 startPos;

		private void Awake()
		{
            startPos = transform.position;
        }

		public abstract void Activate();

		public abstract void Stop();

        public void Move(Vector2 pos)
        {
            transform.position = pos;
        }

        public void BackToStartPos()
		{
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
