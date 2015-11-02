using UnityEngine;
using System.Collections;

public class CargarLogro : MonoBehaviour {

	public TextMesh nombreLogro;
	
	void OnEnable () {
		nombreLogro.text = '\"' + EstadoJuego.estadoJuego.ultimoLogroDesbloqueado.nombre + '\"';
	}
}
