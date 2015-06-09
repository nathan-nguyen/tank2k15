using UnityEngine;
using System.Collections;
using System;

public class Bullet : GeneralBullet {


	Animator anim;





	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.tag == "spawner")
			return;

		//TODO: Find out why the anim is null
		try {
			anim.SetTrigger ("Explode");
		}
		catch (Exception e)
		{
			//Debug.LogException(e, this);
			//print ("Exception");
		}

		this.GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<BoxCollider2D> ().isTrigger = false;

		if (col.tag == "ai" && shooter.GetPersonalTag () != col.GetComponent<AI> ().GetPersonalTag ()) {
			col.GetComponent<AI> ().TakeDamage (this.damage, this.shooter);		
			if (col.GetComponent<AI> ().GetPersonalTag() == "second team")
				col.GetComponent<Enemy>().ActivateCrazyMode();
		}

		if (col.tag == "destroyable-object")
			col.GetComponent<DestroyableObject> ().ReduceDurability ();

		GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		Destroy (this.gameObject, 0.5f);
	}
}
