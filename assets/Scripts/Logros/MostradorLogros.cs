using UnityEngine;
using System.Collections;

public class MostradorLogros : MonoBehaviour {

	//Logros totales.
	private Logro[] logros;


	//Posiciones iniciales, numeros magicos que han probado quedar bien
	private float initial_x = 0f;
	private float initial_y = 4.840927f;

	//Altura de cada contenedor de logro. Necesario para ver donde colocar el proximo logro.
	private float offset_y = 0f;

	// Use this for initialization
	void Start () {
		this.logros = EstadoJuego.estadoJuego.logros.getLogros();
		mostrarLogros ();
	}

	//Itera sobre la lista de logros y crea una nueva "tile" (contenedor) con el logro y sus caracteristicas.
	public void mostrarLogros() {
		offset_y = initial_y; 
		foreach (Logro l in logros) {
			string logroToShow = getLogroToShow(l);
			GameObject contenedor = Instantiate(Resources.Load("Logros/" + logroToShow), new Vector2(initial_x, offset_y), transform.rotation)
				                    as GameObject;
			contenedor.GetComponent<ContenedorLogro>().Create(l.nombre, l.descripcion, l.desbloqueado);

			offset_y -= 2.45333f;
		}
	}
	
	string getLogroToShow(Logro l) {
		string s = "";
		switch (l.movie_logro) {
		case Logro.Movie_Logro.PADRINO: 
			s = "PadrinoLogro";
			break;
		case Logro.Movie_Logro.RESPLANDOR: 
			s = "ResplandorLogro";
			break;
		case Logro.Movie_Logro.SEVEN: 
			s = "SevenLogro";
			break;
		case Logro.Movie_Logro.FORREST:
			s = "ForrestLogro";
			break;
		case Logro.Movie_Logro.HAL9000: 
			s = "Hal9000Logro";
			break;
		case Logro.Movie_Logro.DARTHVADER: 
			s = "DarthVaderLogro";
			break;
		case Logro.Movie_Logro.TITANIC: 
			s = "TitanicLogro";
			break;
		case Logro.Movie_Logro.WHAT:
			s = "WhatLogro";
			break;
		default:
			break;
		}
		return s;
	}
}
