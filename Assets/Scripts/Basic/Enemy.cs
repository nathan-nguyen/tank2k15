using UnityEngine;
using System.Collections;

public class Enemy : AI {

	private Rigidbody2D enemyRigidbody;

	public GameObject gun;

	private bool noState = true;

	public int localDirectionX = 1;
	public int localDirectionY = 0;

	//TODO: Runaway and Fireback Mode


	// Use this for initialization
	void Start () {
		this.SetAllowFire (false);

		enemyRigidbody = GetComponent<Rigidbody2D> ();
		
		enemyRigidbody.velocity = new Vector2 (localDirectionX * this.GetMaxSpeed(), localDirectionY * this.GetMaxSpeed());
		
		this.SetPersonalTag ("second team");
		
		this.ChangeDirection (this.direction);
		
		InitializeAI ();
	}


	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		if (this.GetComponent<Rigidbody2D> ().velocity.magnitude < 1.4 && noState)
			nextState ();
	}

	public void ChangeDirection(int direction){
		this.direction = direction;
		switch (direction) {
		case 0:
			this.image.GetComponent<SpriteRenderer>().transform.eulerAngles = this.UP_DIRECTION;
			break;
		case 1:
			this.image.GetComponent<SpriteRenderer>().transform.eulerAngles = this.RIGHT_DIRECTION;
			break;
		case 2:
			this.image.GetComponent<SpriteRenderer>().transform.eulerAngles = this.LEFT_DIRECTION;
			break;
		case 3:
			this.image.GetComponent<SpriteRenderer>().transform.eulerAngles = this.DOWN_DIRECTION;
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.collider.tag == "wall" && noState)
			nextState ();
		if (col.collider.tag == "ai" && noState)
			StartCoroutine(CrazyMode ());
	}

	void  MovingBackMode(){
		this.localDirectionX = -this.localDirectionX;
		this.localDirectionY = -this.localDirectionY;
		this.ChangeDirection(3 - this.GetDirection());
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (this.localDirectionX * this.GetMaxSpeed(), this.localDirectionY * this.GetMaxSpeed());
		gun.GetComponent<Gun>().Fire(this.GetBulletPower());
		noState = true;
	}

	IEnumerator StopMode(){
		noState = false;
		int initialDirection = this.GetDirection ();
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		for (int i = 0; i < 4; i++) {
			this.ChangeDirection(i);
			gun.GetComponent<Gun>().Fire(this.GetBulletPower());
			yield return new WaitForSeconds(1);
		}

		this.ChangeDirection (initialDirection);
		 MovingBackMode ();
	}

	IEnumerator MoveUpMode() {
		noState = false;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.ChangeDirection(0);
		this.localDirectionX = 0;
		this.localDirectionY = 1;
		gun.GetComponent<Gun>().Fire(this.GetBulletPower());
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (this.localDirectionX * this.GetMaxSpeed(), this.localDirectionY * this.GetMaxSpeed());
		yield return new WaitForSeconds(1);
		noState = true;
	}

	IEnumerator MoveDownMode() {
		noState = false;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.ChangeDirection(3);
		this.localDirectionX = 0;
		this.localDirectionY = -1;
		gun.GetComponent<Gun>().Fire(this.GetBulletPower());
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (this.localDirectionX * this.GetMaxSpeed(), this.localDirectionY * this.GetMaxSpeed());
		yield return new WaitForSeconds(1);
		noState = true;
	}

	IEnumerator MoveRightMode() {
		noState = false;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.ChangeDirection(1);
		this.localDirectionX = 1;
		this.localDirectionY = 0;
		gun.GetComponent<Gun>().Fire(this.GetBulletPower());
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (this.localDirectionX * this.GetMaxSpeed(), this.localDirectionY * this.GetMaxSpeed());
		yield return new WaitForSeconds(1);
		noState = true;
	}

	IEnumerator MoveLeftMode() {
		noState = false;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.ChangeDirection(2);
		this.localDirectionX = -1;
		this.localDirectionY = 0;
		gun.GetComponent<Gun>().Fire(this.GetBulletPower());
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (this.localDirectionX * this.GetMaxSpeed(), this.localDirectionY * this.GetMaxSpeed());
		yield return new WaitForSeconds(1);
		noState = true;
	}

	private void nextState(){
		int state = Random.Range (0, 10);
		switch (state) {
			case 0: 
				StartCoroutine(MoveUpMode());
				break;
			case 1:
				StartCoroutine(MoveRightMode());
				break;
			case 2:
				StartCoroutine(MoveLeftMode());
				break;
			case 3:
				StartCoroutine(MoveDownMode());
				break;
			case 4:
				StartCoroutine(StopMode ());
				break;
			default:
				 MovingBackMode();
				break;
		}
	}

	public void ActivateCrazyMode(){
		StartCoroutine (CrazyMode ());
	}

	IEnumerator CrazyMode(){
		noState = false;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		int initialDirection = this.GetDirection ();
		int fireDirection;
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 5; j++){
				fireDirection = Random.Range (0, 4);
				this.ChangeDirection (fireDirection);
				gun.GetComponent<Gun> ().Fire (this.GetBulletPower ());
				yield return new WaitForSeconds (0.2f);
			}

			yield return new WaitForSeconds (0.5f);
		}
		this.ChangeDirection (initialDirection);
		MovingBackMode ();
	}
	
}
