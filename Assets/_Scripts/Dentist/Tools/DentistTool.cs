//Subclass Sandbox pattern :*

using UnityEngine;

namespace Game.Dentist.Tools
{
	public abstract class DentistTool
	{
        public abstract void Activate();

        protected void Move(float speed)
        {
            Debug.Log("Moving with speed " + speed);
        }

        protected void PlaySound(string coolSound)
        {
            Debug.Log("Playing sound " + coolSound);
        }

        protected void SpawnParticles()
        {

        }
    }
}
