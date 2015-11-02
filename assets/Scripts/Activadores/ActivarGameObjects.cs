using UnityEngine;
using System.Collections;

public class ActivarGameObjects : MonoBehaviour {

	public GameObject cameraGameOver;
	public GameObject cameraLogroDesbloqueado;
	
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver (this, "PersonajeHaMuerto");
		NotificationCenter.DefaultCenter().AddObserver (this, "LogroDesbloqueado");
	}
	
	void PersonajeHaMuerto(Notification not) {
		cameraGameOver.SetActive(true);
	}

	void LogroDesbloqueado(Notification not) {
		cameraLogroDesbloqueado.SetActive(true);
	}

}
