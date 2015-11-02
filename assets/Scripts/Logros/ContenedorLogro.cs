using UnityEngine;
using System.Collections;

public class ContenedorLogro : MonoBehaviour {

	public TextMesh nombreTexto;
	public TextMesh descripcionTexto;
	public TextMesh desbloqueado;

	public void Create (string nombre, string descripcion, bool desbloqueado) {
		nombreTexto.text       = nombre;
		descripcionTexto.text  = descripcion;
		this.desbloqueado.text = desbloqueado ? "Unlocked" : "Locked";
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
