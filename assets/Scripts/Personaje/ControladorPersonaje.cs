using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 100f;
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;
	public int saltos = 2;
	private int saltosdados = 0;
	
	private bool canDoubleJump;
	private Animator animator;

	private bool corriendo = false;
	public float velocidad = 1f;

	//Needed to get personaje's X and Y position
	public Transform personaje;
	public GameObject spring;


	void Awake(){
		animator = GetComponent<Animator> ();
		canDoubleJump = true;

		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
	}

	int clicks = 0;

	void FixedUpdate(){
		if (corriendo) {
			rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
		}
		animator.SetFloat ("SpeedX", rigidbody2D.velocity.x);
	    enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		//Reinicia el cuento de saltos en caso de que toque el suelo
		animator.SetBool ("isGrounded", enSuelo);
		if (Input.GetMouseButtonDown (0) && corriendo) {
			haSaltado = true;
		}

		if (enSuelo) {
			canDoubleJump = true;
			haSaltado = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (corriendo){
				jump();
			}
			else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
			}
		}
	}

	private bool haSaltado;

	void jump() {
		Debug.Log ("Grounded: " + enSuelo + "   DoubleJump: " + canDoubleJump +  "   haSaltado: " + haSaltado);
		if (enSuelo) {
			Debug.Log("salto normal");
			enSuelo = false;
			haSaltado = true;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
			rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
			audio.Play();
			Instantiate (spring, personaje.position, Quaternion.identity);
		} else if (!haSaltado) {
			Debug.Log("salto en caida");
			haSaltado = true;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
			rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
			audio.Play();
			Instantiate (spring, personaje.position, Quaternion.identity);
		} else if (haSaltado && canDoubleJump) {
			Debug.Log("doble salto");
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
			rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
			canDoubleJump = false;
			audio.Play();
			Instantiate (spring, personaje.position, Quaternion.identity);
		}
		//Vector3 position = personaje.position;
		//float offset = collider.bounds.size.x / 2;
		//position.x += offset;

	}


	void IncrementarPuntos(Notification not) {
		this.velocidad += (float) ((int) not.data * 0.07);
	}
}
