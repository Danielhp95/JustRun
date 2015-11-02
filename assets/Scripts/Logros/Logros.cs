using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Logros {
	
	public Logro[] logros;

	public readonly static int NUMERO_LOGROS = 9;
	  
	public Logros(){
		logros = new Logro[NUMERO_LOGROS];
		generarLogros ();
	}

	public Logro ActualizarLogros(EstadoJuego e) {
		Logro logroDesbloqueado = null;
		for (int i = 0; i < logros.Length; i++) {

			if (!logros[i].desbloqueado) {
				logros[i].desbloqueado = logros[i].condicion(e);
				if (logros[i].desbloqueado) {
					logroDesbloqueado = logros[i];
					break;
				}
			}
		}
		return logroDesbloqueado;
	}

<<<<<<< HEAD
	public ArrayList logrosDesbloqueados(EstadoJuego e) {
=======
	private ArrayList logrosDesbloqueados(EstadoJuego e) {
>>>>>>> 5a0ca8ed9abccdc21f587259508852d25fcf29b5
		ArrayList desbloqueados = new ArrayList ();
		for (int i = 0; i < logros.Length; i++) {	
			if (!logros[i].desbloqueado) {
				logros[i].desbloqueado = logros[i].condicion(e);
				if (logros[i].desbloqueado) {
					desbloqueados.Add(logros[i]);
				}
			}
		}
		return desbloqueados;
	}

<<<<<<< HEAD
	public Logro[] getLogros () {
		return logros;
	}

=======
>>>>>>> 5a0ca8ed9abccdc21f587259508852d25fcf29b5
	private void generarLogros() {
		logros [0] = CorreForrest ();
		logros [1] = muchosSeven1 ();
		logros [2] = muchosPadrino1 ();
		logros [3] = muchosVader1 ();
		logros [4] = muchisimosHal90001 ();
		logros [5] = muchosHal90001 ();
		logros [6] = muchosResplandor1 ();
		logros [7] = muchosTitanic1 ();
		logros [8] = muchosHalOResplandor1 ();
	}


/************ LOGROS FORREST GUMP *****************/
	private Logro CorreForrest() {
		Logro l = new Logro("Jump Forrest, Jump!", " / 10 feathers collected", suficientesForrest1, Logro.Movie_Logro.FORREST);
		return l;
	}

	private bool suficientesForrest1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Forrest"] >= 10;
	}

/************ LOGROS SEVEN *****************/
	private Logro muchosSeven1() {
		Logro l = new Logro("77 boxes", "Collect 77 boxes", suficientesSeven1, Logro.Movie_Logro.SEVEN);
		return l;
	}

	private bool suficientesSeven1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Seven"] >= 77;
	}

/************ LOGROS Padrino *****************/
	private Logro muchosPadrino1() {
		Logro l = new Logro("An Oscar you can't refuse", "Collect 1 horse head", suficientesPadrino1, Logro.Movie_Logro.PADRINO);
		return l;
	}

	private bool suficientesPadrino1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Padrino"] >= 1;
	}

/************ LOGROS Hal9000 *****************/
	private Logro muchosHal90001() {
		Logro l = new Logro("SuperComputer", "Collect 100 Hal9000", suficientesHal90001, Logro.Movie_Logro.HAL9000);
		return l;
	}

	private bool suficientesHal90001(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Hal9000"] >= 100;
	}

	private Logro muchisimosHal90001() {
		Logro l = new Logro("Infinite runner master", "Collect 9000 Hal9000!!!", demasiadosHal90001, Logro.Movie_Logro.HAL9000);
		return l;
	}
	
	private bool demasiadosHal90001(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Hal9000"] >= 9000;
	}


/************ LOGROS Star Wars *****************/
	private Logro muchosVader1() {
		Logro l = new Logro("Awkard breathing", "Collect 100 Darth Vader Helmets", suficientesVader1, Logro.Movie_Logro.DARTHVADER );
		return l;
	}

	private bool suficientesVader1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Vader"] >= 100;
	}
	

/************ LOGROS Resplandor *****************/
	
	private Logro muchosResplandor1() {
		Logro l = new Logro("Here come 100 Johnies!", "Collect 100 axes", suficientesResplandor1, Logro.Movie_Logro.RESPLANDOR);
		return l;
	}

	private bool suficientesResplandor1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Resplandor"] >= 100;
	}

/************ LOGROS Titanic (muerte Leonardo) *****************/
	private Logro muchosTitanic1() {
		Logro l = new Logro("The king of the world", " Leonardos who couldn't get the Oscar", suficientesTitanic1, Logro.Movie_Logro.TITANIC);
		return l;
	}
	
	private bool suficientesTitanic1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["MuertesLeonardo"] >= 10;
	}

/************ LOGROS Perspectiva (What) *****************/
	private Logro muchosHalOResplandor1() {
		Logro l = new Logro("A matter of Perspective", " gather 100 itmes, axes or hal9000", suficientesHalOResplandor1, Logro.Movie_Logro.WHAT);
		return l;
	}
	
	private bool suficientesHalOResplandor1(EstadoJuego estadoJuego) {
		int hals = EstadoJuego.estadoJuego.objetos_guardados ["Hal9000"];
		int resplandores = EstadoJuego.estadoJuego.objetos_guardados ["Resplandor"];
		return hals + resplandores >= 100;
	}


}

public delegate bool Condicion(EstadoJuego estadoJuego);

[Serializable]
public class Logro {
	public string nombre;
	public string descripcion;
	public bool desbloqueado;
	public Condicion condicion;
	public Movie_Logro movie_logro;

	public enum Movie_Logro {
		PADRINO, RESPLANDOR, SEVEN, FORREST, HAL9000, DARTHVADER, TITANIC, WHAT
	}

	public Logro(string nombre, string descripcion, Condicion condicion, Movie_Logro movie_logro) {
		this.nombre = nombre;
		this.descripcion = descripcion;
		this.desbloqueado = false;
		this.condicion = condicion;
		this.movie_logro = movie_logro;
	}
}