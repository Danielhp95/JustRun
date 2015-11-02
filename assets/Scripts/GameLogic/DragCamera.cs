using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour
{

	public float dragSpeed = 0.3f;
	private Vector3 dragOrigin;

	private float lowerBound = -Logros.NUMERO_LOGROS * 1.3f;
	private float upperBound = 2.0f ;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			dragOrigin = Input.mousePosition;
			return;
		}
		
		if (!Input.GetMouseButton(0)) return;
		
		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(0, pos.y * dragSpeed, 0);

		if (move.y > 0f) {
			if (this.transform.position.y < upperBound) {
				transform.Translate (move, Space.World);  
			}
		} else if (move.y < 0f) {
			if (this.transform.position.y > lowerBound) {
				transform.Translate (move, Space.World);  
			}
		}

	}
}