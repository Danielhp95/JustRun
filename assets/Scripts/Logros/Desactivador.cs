using UnityEngine;
using System.Collections;

public class Desactivador : MonoBehaviour {

	public GameObject objectToDeactivate;
	public float tiempoActivo = 3f;

	//Deactivates this camera after 4 seconds.
	void Awake() {
		Invoke ("desactivar", tiempoActivo);
	}

	void desactivar() {
	    objectToDeactivate.SetActive (false);
	}

}
