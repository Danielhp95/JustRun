using UnityEngine;
using System.Collections.Generic;

public static class Utilidad {

	public static Dictionary<string, int> crearDiccionarioPuntuacion() {
		Dictionary<string, int> diccionario = new Dictionary<string,int> ();
		diccionario.Add ("Plataforma", 0);
		diccionario.Add ("Forrest", 0);
		diccionario.Add ("Hal9000", 0);
		diccionario.Add ("Seven", 0);
		diccionario.Add ("Vader", 0);
		diccionario.Add ("Resplandor", 0);
		diccionario.Add ("Padrino", 0);
		diccionario.Add ("MuertesPersonaje", 0);
		diccionario.Add ("MuertesLeonardo", 0);
		return diccionario;
	}
}
