using UnityEngine;
using System.Collections;

public class TankPlayerTwo : AI {

	// Use this for initialization
	void Start () {
		this.SetControllable (true);
		this.SetPersonalTag ("first team");
		this.SetShootable (true);
		this.SetFireButton(KeyCode.JoystickButton0);
		this.direction = 0;
		
		image.transform.eulerAngles = this.UP_DIRECTION;

		this.AddItem ("Rocket");
		this.AddItem ("TwoPower");
		this.AddItem ("ThreePower");

		this.InitializeAI ();
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
			this.UseItem(GetItem (0));
		}
		
		if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
			this.UseItem(GetItem (1));
		}
		
		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			this.UseItem(GetItem (2));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("HorizontalTwo");
		float moveVertical = Input.GetAxis ("VerticalTwo");
		
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
		GUI.Box (new Rect (Screen.width /2 + 20, 10, 100, 20), "" + this.GetHealthPoint());
		GUI.Box (new Rect (Screen.width /2 + 100, 10, 100, 20), "Bullet Power: " + this.GetBulletPower());
		GUI.Box (new Rect (Screen.width /2 + 200, 10, 100, 20), "K/D : " + this.kill + "/" + this.death);
		GUI.Box (new Rect (Screen.width /2 + 20, 30, 250, 20), "Items: " + this.GetDisplayItemList());
	}
}
