using UnityEngine;
using System.Collections;

public class Bomb : GeneralBullet {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ai") {

			animator.SetTrigger ("Explode");

			GetComponent<BoxCollider2D> ().transform.localScale = new Vector2 (0.5f, 0.5f);

			col.GetComponent<AI>().TakeDamage(50, this.shooter);

			Destroy (this.gameObject, 1f);
		}
	}
}
