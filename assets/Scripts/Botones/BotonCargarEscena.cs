using UnityEngine;
using System.Collections;

public class BotonCargarEscena : MonoBehaviour {

	public string escena;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void OnMouseDown(){
		if (AdHolder.bannerView != null) {
			AdHolder.bannerView.Hide();
		}
		Application.LoadLevel (escena);
	}
}
