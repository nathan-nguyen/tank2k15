using UnityEngine;
using System.Collections;

public class FuelTank : GeneralBullet {

	Animator animator;

	private bool exploding = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		this.SetDamage (50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "bullet" && !exploding) {	
			exploding = true;

			animator.SetTrigger ("Explode");
		
			GetComponent<BoxCollider2D> ().transform.localScale = new Vector2 (0.5f, 0.25f);
		
			Destroy (this.gameObject, 1f);
		}

		if (col.tag == "ai" && exploding)
			col.GetComponent<AI> ().TakeDamage (this.damage, this.shooter);		
	}
}
