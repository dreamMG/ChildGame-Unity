using Game.Backend;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
	public class InputGlobal : MonoBehaviour
	{
		[Zenject.Inject] private InputMaster inputActions;

		private readonly Raycaster raycaster = new Raycaster();
		private IMoveable moveable;

		public Vector2 InputPos => inputActions.Player.InputPosition.ReadValue<Vector2>();

		private void OnEnable()
		{
			inputActions.Player.Fire.started += GetRaycaster;
			inputActions.Player.Fire.canceled += RemoveRaycaster;

			inputActions.Enable();
		}

		private void OnDisable()
		{
			inputActions.Player.Fire.started -= GetRaycaster;
			inputActions.Player.Fire.canceled -= RemoveRaycaster;

			inputActions.Disable();
		}

		private void GetRaycaster(InputAction.CallbackContext callbackContext)
		{
			var hit = raycaster.Raycast<IMoveable>(InputPos);

			if(hit is IMoveable moveable)
			{
				this.moveable = moveable;
				StartCoroutine(StartMove());
				return;
			}
		}

		private void RemoveRaycaster(InputAction.CallbackContext callbackContext)
		{
			if (this.moveable is IBackToStartPosition back)
			{
				back.BackToStartPos();
			}

			this.moveable = null;
		}

		private IEnumerator StartMove()
		{
			while (moveable != null)
			{
				moveable.Move(Camera.main.ScreenToWorldPoint(InputPos));

				yield return new WaitForEndOfFrame();
			}
		}
	}
}
