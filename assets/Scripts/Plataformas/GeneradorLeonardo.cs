using UnityEngine;
using System.Collections;

public class GeneradorLeonardo : MonoBehaviour {

	public GameObject Leonardo;
	//GameObject oscar = GameObject.Find ("Player");
	private bool fin = false;

	// Use this for initialization
	void Start () {
		GenerarLeo ();
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		//NotificationCenter.DefaultCenter().AddObserver(this, "LeonardoHaMuerto");
	}

	void PersonajeHaMuerto(){
		fin = true;
	}

	void PersonajeEmpiezaACorrer(Notification noficacion){
		Generar ();
	}

	/*void LeonardoHaMuerto(Notification noficacion){
		Generar ();
	}*/
	
	// Update is called once per frame
	/*void Update () {
		if (GameObject.Find("Leonardo(Clone)")== null) {
			Generar ();
		}
	}*/

	void Generar(){
		while(!fin){ 
			GenerarLeo ();
		} 
	}
	void GenerarLeo(){
		if (GameObject.Find ("Leonardo(Clone)") == null) {
			Instantiate (Leonardo, transform.position, Quaternion.identity);
		}
	}

	/*
	void Generar(){
		if (!fin && GameObject.Find ("Leonardo(Clone)") == null) {
			Instantiate (Leonardo, transform.position, Quaternion.identity);
		}
	}
	 */

}
