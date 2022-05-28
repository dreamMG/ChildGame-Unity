using Game.Backend;
using Game.Input;
using UnityEngine;

namespace Game.Dentist.Tools
{
	public abstract class DentistTool : MonoBehaviour, IMoveable, IBackToStartPosition
	{
        [SerializeField] private DentistToolSetting setting;
        [SerializeField] private ParticleSystem particle;

        [Zenject.Inject] private AudioManager audioManager;
        [Zenject.Inject] private InputGlobal inputGlobal;
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
