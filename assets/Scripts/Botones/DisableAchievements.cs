using UnityEngine;
using System.Collections;
using System.IO;

public class DisableAchievements : BotonCargarEscena {

	public TextMesh achievements;
	private bool active;

	// Use this for initialization
	void Awake () {
		if (!File.Exists(Application.persistentDataPath + "/datosJuego.dat")) {
			active = false;
			achievements.color = Color.gray;
		} else {
			active = true;
		}
	}

	protected override  void OnMouseDown() {
		if (!active) {
			//Do Nothing
		} else {
			if (AdHolder.bannerView != null) {
				AdHolder.bannerView.Hide ();
			}
			Application.LoadLevel (escena);
		}
	}
}