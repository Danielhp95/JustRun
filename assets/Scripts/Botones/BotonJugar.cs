﻿using UnityEngine;
using System.Collections;

public class BotonJugar : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		AdHolder.bannerView.Hide ();
		Application.LoadLevel ("GameScene");
	}


}
