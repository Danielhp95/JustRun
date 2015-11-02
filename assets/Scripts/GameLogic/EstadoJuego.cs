using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima;

	public static EstadoJuego estadoJuego;
	private String directorioArchivo;

	public Dictionary<string, int> objetos_guardados;

	public Logros logros;
	public Logro ultimoLogroDesbloqueado;

	void Awake() {
		directorioArchivo = Application.persistentDataPath + "/datosJuego.dat";
		//Impide que se destruya EstadoObjto al cambiar de escena
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
			objetos_guardados = Utilidad.crearDiccionarioPuntuacion();
		} else if (estadoJuego != this) {
			Destroy(gameObject);		       
		}
	}

	// Use this for initialization
	void Start () {
		Cargar ();
		//Llama a actualizar logros cada segundo pasados 3 segundos.
		InvokeRepeating ("ActualizarLogros", 3, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Cargar() {
		if (File.Exists(directorioArchivo)) {
		    BinaryFormatter bf = new BinaryFormatter ();
		    FileStream file = File.Open (directorioArchivo, FileMode.Open);

		    DatosAGuardar datos = (DatosAGuardar) bf.Deserialize (file);

		    puntuacionMaxima = datos.puntuacionMaxima;
			objetos_guardados = datos.objetos_conseguidos;
			logros = datos.logros;
		} else {
			//Primera vez que se ejecuta el juego.
			puntuacionMaxima = 0;

		}

	}

	public void Guardar() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(directorioArchivo);

		DatosAGuardar datos = new DatosAGuardar (puntuacionMaxima, objetos_guardados, logros);

		bf.Serialize (file, datos);
		file.Close ();
	}

	//Detecta si se ha desbloqueado un logro
	private void ActualizarLogros() {
		Logro logroDesbloqueado = logros.ActualizarLogros (estadoJuego);
		//If achievement has been unlocked, lunch the notification
		if (logroDesbloqueado != null) {
			ultimoLogroDesbloqueado = logroDesbloqueado;
			NotificationCenter.DefaultCenter().PostNotification(this, "LogroDesbloqueado");
		}
	}

}

[Serializable]
class DatosAGuardar {

	public Logros logros;

	public int puntuacionMaxima;
	public Dictionary<string, int> objetos_conseguidos;

	public DatosAGuardar(int puntuacionMaxima, Dictionary<string, int> objetos_conseguidos, Logros logros) {
		this.puntuacionMaxima = puntuacionMaxima;
		this.objetos_conseguidos = objetos_conseguidos;
		this.logros = logros;
	}
}
