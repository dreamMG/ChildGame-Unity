using Game.Backend;
using UnityEngine;

namespace Game.Input
{
	public class Raycaster
	{
		public object Raycast<T>(Vector2 pos)
		{
			var worldPoint = Camera.main.ScreenToWorldPoint(pos);
			var hit = Physics2D.Raycast(worldPoint, Vector2.zero);

			if (hit.collider != null && hit.collider.TryGetComponent(typeof(T), out var type))
			{
				if (type is IMoveable moveable)
				{
					return moveable;
				}
			}

			return null;
		}
	}
}
