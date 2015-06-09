using UnityEngine;
using System.Collections;

public class TankPlayerOne : AI {

	// Use this for initialization
	void Start () {
		this.SetPersonalTag ("first team");
		image.transform.eulerAngles = this.UP_DIRECTION;
		this.SetShootable (true);
		this.SetFireButton (KeyCode.Space);
		this.direction = 0;

		InitializeAI ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			this.UseItem(GetItem (0));
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			this.UseItem(GetItem (1));
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			this.UseItem(GetItem (2));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveVertical < 0) {
			this.direction = 3;
			image.transform.eulerAngles = this.DOWN_DIRECTION;
		}
		
		if (moveHorizontal > 0) {
			this.direction = 1;
			image.transform.eulerAngles = this.RIGHT_DIRECTION;
		}
		
		if (moveHorizontal < 0) {
			this.direction = 2;
			image.transform.eulerAngles = this.LEFT_DIRECTION;
		}
		
		if (moveVertical > 0) {
			this.direction = 0;
			image.transform.eulerAngles = this.UP_DIRECTION;
		}

		Rigidbody2D characterRigidbody = GetComponent<Rigidbody2D> ();
		characterRigidbody.velocity = new Vector2 (moveHorizontal * this.GetMaxSpeed (), moveVertical * this.GetMaxSpeed ());
	}

	void OnGUI () {
		GUI.Box (new Rect (10, 10, 100, 20), "" + this.GetHealthPoint());
		GUI.Box (new Rect (110, 10, 100, 20), "Bullet Power: " + this.GetBulletPower());
		GUI.Box (new Rect (210, 10, 100, 20), "K/D : " + this.kill + "/" + this.death);
		GUI.Box (new Rect (10, 30, 250, 20), "Items: " + this.GetDisplayItemList());
	}
}
