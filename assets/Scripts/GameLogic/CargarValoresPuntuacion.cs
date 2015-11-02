using UnityEngine;
using System.Collections;

public class CargarValoresPuntuacion : MonoBehaviour {

	public TextMesh total;
	public TextMesh record;

	public AdHolder adHolder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable() {
		total.text  = Puntuacion.getPuntuacion().ToString();
		Puntuacion.resetPuntuacion ();
		record.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
		adHolder.Show ();
	}
}
