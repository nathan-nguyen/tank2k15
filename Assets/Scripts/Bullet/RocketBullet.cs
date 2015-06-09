using UnityEngine;
using System.Collections;

public class RocketBullet : GeneralBullet {

	Animator animator;

	// Use this for initialization
	void Start () {
		this.SetDamage (45);
		this.SetBulletSpeed (4f);
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.tag == "spawner")
			return;

		animator.SetTrigger ("Explode");

		//this.GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<BoxCollider2D> ().transform.localScale = new Vector2 (0.4f, 0.2f);
		//GetComponent<SpriteRenderer> ().sprite = null;
		
		if (col.tag == "ai")
				col.GetComponent<AI>().TakeDamage(this.damage, this.shooter);		
		
		if (col.tag == "destroyable-object")
			col.GetComponent<DestroyableObject> ().ReduceDurability ();
		
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		
		Destroy (this.gameObject, 1f);
	}
}
