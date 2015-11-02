using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

	public GameObject cameraGameOver;
	public GameObject cameraUnlockedAchievement;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver (this, "LogroDesbloqueado");
		NotificationCenter.DefaultCenter().AddObserver (this, "PersonajeHaMuerto");
	}

	void LogroDesbloqueado(Notification not) {
		cameraUnlockedAchievement.SetActive(true);
	}

	void PersonajeHaMuerto(Notification not) {
		cameraGameOver.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
