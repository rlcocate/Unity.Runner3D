using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemScript : MonoBehaviour {

	Vector3 novaPosicao;
	Animation ani;

	public float velocidade;
	public GameObject personagem;

	// Use this for initialization
	void Start () {

		// Captura a posição inicial do personagem.
		novaPosicao = transform.position;

		ani = personagem.GetComponent<Animation> ();

		// Define a animação inicial do personagem.
		ani.CrossFade("idle");

	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "item") {
			Destroy (c.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {

		// Touch ou clique do mouse.
		if (Input.GetButton ("Fire1")) {

			// Transforma o clique na tela em coordenada 3D.
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			// Obtem a nova posição.
			if (Physics.Raycast (ray, out hit)) {
				novaPosicao = hit.point;
			}

			// Move o personagem.
			transform.position = Vector3.MoveTowards (transform.position, novaPosicao, velocidade * Time.deltaTime);

			// Animação de run quando clicar na tela.
			ani.CrossFade("run");

			// Olha no ponto onde apontou o mouse.
			transform.LookAt (hit.point);

		} else {

			// Animação de idle quando parar de clicar.
			ani.CrossFade("idle");

		}

	}
}
