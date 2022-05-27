using UnityEngine;

namespace Game.Backend
{
	public class CamerasManager : MonoBehaviour
	{
		[SerializeField] private Camera[] cameras;

		public Camera MainCamera => cameras[0];
	}
}
