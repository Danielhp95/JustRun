using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public bool IniciarEnMovimiento = false;
	public float velocidad = 0f; 
	private bool enMovimiento = false;
	private float tiempoIn= 0f;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		if (IniciarEnMovimiento) {
			PersonajeEmpiezaACorrer();		
		}
	}

	void PersonajeEmpiezaACorrer(){
		enMovimiento = true;
		tiempoIn = Time.time;
	}

	void PersonajeHaMuerto(){
		enMovimiento = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enMovimiento) {
			renderer.material.mainTextureOffset = new Vector2 (((Time.time - tiempoIn) * velocidad)%1, 0);
		}
	}
}
