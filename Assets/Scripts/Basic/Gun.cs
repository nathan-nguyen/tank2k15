using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject originalBulletInstance;
	public GameObject originalRocketInstance;
		
	public AI tankAI;

	private Rigidbody2D bullet;
	private Rigidbody2D rocket;

	private bool allowFire = true;

	// Use this for initialization
	void Start () {
		bullet = originalBulletInstance.GetComponent<Rigidbody2D> ();
		rocket = originalRocketInstance.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (allowFire && tankAI.IsControllable() && tankAI.GetFireButton()!= KeyCode.None && Input.GetKeyDown (tankAI.GetFireButton()) && tankAI.IsShootable()) {
			Fire(tankAI.GetBulletPower());
		}

	}

	private void FireOne(){

		Rigidbody2D bulletInstance;
		switch (tankAI.GetDirection()){
		case 0:		//UP
			bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,270))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(0, bulletInstance.GetComponent<Bullet>().GetBulletSpeed());
			break;
		case 1:		//RIGHT
			bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(bulletInstance.GetComponent<Bullet>().GetBulletSpeed(), 0);
			break;
		case 2:		//LEFT
			bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-bulletInstance.GetComponent<Bullet>().GetBulletSpeed(), 0);
			break;
		default:	//DOWN
			bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(0, -bulletInstance.GetComponent<Bullet>().GetBulletSpeed());
			break;
		}
		bulletInstance.GetComponent<Bullet>().SetDamage(33);
		bulletInstance.GetComponent<Bullet> ().SetShooter (tankAI);

	}

	private void FireRocket(){
		float bulletSpeed = 3f;
		Rigidbody2D rocketInstance;

		switch (tankAI.GetDirection()){
		case 0:		//UP
			rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			rocketInstance.velocity = new Vector2(0, bulletSpeed);
			break;
		case 1:		//RIGHT
			rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,270))) as Rigidbody2D;
			rocketInstance.velocity = new Vector2(bulletSpeed, 0);
			break;
		case 2:		//LEFT
			rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
			rocketInstance.velocity = new Vector2(-bulletSpeed, 0);
			break;
		default:	//DOWN
			rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
			rocketInstance.velocity = new Vector2(0, -bulletSpeed);
			break;
		}

		rocketInstance.GetComponent<RocketBullet>().SetBulletSpeed (bulletSpeed);
		rocketInstance.GetComponent<RocketBullet>().SetDamage(33);
		rocketInstance.GetComponent<RocketBullet> ().SetShooter (tankAI);
		
	}

	private void FireTwo(){
		
		Rigidbody2D bulletInstanceOne, bulletInstanceTwo;
		switch (tankAI.GetDirection()){
		case 0:		//UP
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.left, Quaternion.Euler(new Vector3(0,0,270))) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.right, Quaternion.Euler(new Vector3(0,0,270))) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(0, bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed());
			bulletInstanceTwo.velocity = new Vector2(0, bulletInstanceTwo.GetComponent<Bullet>().GetBulletSpeed());
			break;
		case 1:		//RIGHT
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.up, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.down, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed(), 0);
			bulletInstanceTwo.velocity = new Vector2(bulletInstanceTwo.GetComponent<Bullet>().GetBulletSpeed(), 0);
			break;
		case 2:		//LEFT
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.up, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.down, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(-bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed(), 0);
			bulletInstanceTwo.velocity = new Vector2(-bulletInstanceTwo.GetComponent<Bullet>().GetBulletSpeed(), 0);
			break;
		default:	//DOWN
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.right, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.left, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(0, -bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed());
			bulletInstanceTwo.velocity = new Vector2(0, -bulletInstanceTwo.GetComponent<Bullet>().GetBulletSpeed());
			break;
		}

		bulletInstanceOne.GetComponent<Bullet>().SetDamage(20);
		bulletInstanceTwo.GetComponent<Bullet>().SetDamage(20);
		bulletInstanceOne.GetComponent<Bullet> ().SetShooter (tankAI);
		bulletInstanceTwo.GetComponent<Bullet> ().SetShooter (tankAI);
	}

	private void FireThree(){
		
		Rigidbody2D bulletInstanceOne, bulletInstanceTwo, bulletInstanceThree;
		switch (tankAI.GetDirection()){
		case 0:		//UP
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.left, Quaternion.Euler(new Vector3(0,0,270))) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.right, Quaternion.Euler(new Vector3(0,0,270))) as Rigidbody2D;
			bulletInstanceThree = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,270))) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(0, bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed());
			bulletInstanceTwo.velocity = new Vector2(0, bulletInstanceTwo.GetComponent<Bullet>().GetBulletSpeed());
			bulletInstanceThree.velocity = new Vector2(0, bulletInstanceThree.GetComponent<Bullet>().GetBulletSpeed());
			break;
		case 1:		//RIGHT
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.up, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.down, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			bulletInstanceThree = Instantiate(bullet, transform.position, Quaternion.Euler(Vector3.zero)) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed(), 0);
			bulletInstanceTwo.velocity = new Vector2(bulletInstanceTwo.GetComponent<Bullet>().GetBulletSpeed(), 0);
			bulletInstanceThree.velocity = new Vector2(bulletInstanceThree.GetComponent<Bullet>().GetBulletSpeed(), 0);
			break;
		case 2:		//LEFT
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.up, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.down, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
			bulletInstanceThree = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(-bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed(), 0);
			bulletInstanceTwo.velocity = new Vector2(-bulletInstanceTwo.GetComponent<Bullet>().GetBulletSpeed(), 0);
			bulletInstanceThree.velocity = new Vector2(-bulletInstanceThree.GetComponent<Bullet>().GetBulletSpeed(), 0);
			break;
		default:	//DOWN
			bulletInstanceOne = Instantiate(bullet, transform.position + 0.2f * Vector3.right, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
			bulletInstanceTwo = Instantiate(bullet, transform.position + 0.2f * Vector3.left, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
			bulletInstanceThree = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,90))) as Rigidbody2D;
			bulletInstanceOne.velocity = new Vector2(0, -bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed());
			bulletInstanceTwo.velocity = new Vector2(0, -bulletInstanceOne.GetComponent<Bullet>().GetBulletSpeed());
			bulletInstanceThree.velocity = new Vector2(0, -bulletInstanceThree.GetComponent<Bullet>().GetBulletSpeed());
			break;
		}

		bulletInstanceOne.GetComponent<Bullet>().SetDamage(15);
		bulletInstanceTwo.GetComponent<Bullet>().SetDamage(15);
		bulletInstanceThree.GetComponent<Bullet>().SetDamage(15);

		bulletInstanceOne.GetComponent<Bullet> ().SetShooter (tankAI);
		bulletInstanceTwo.GetComponent<Bullet> ().SetShooter (tankAI);
		bulletInstanceThree.GetComponent<Bullet> ().SetShooter (tankAI);
	}

	public void Fire(int power){
		StartCoroutine (FireCoroutine (power));
	}

	IEnumerator FireCoroutine(int power){
		if (tankAI.IsShootable ()) {
			allowFire = false;
			float fireRate = 0.6f;
			switch (power) {
			case 2:
				FireTwo ();
				fireRate = 0.5f;
				break;
			case 3:
				FireThree ();
				fireRate = 0.4f;
				break;
			case 4:
				FireRocket ();
				fireRate = 1.75f;
				break;
			default:
				FireOne ();
				break;
			}
			yield return new WaitForSeconds (fireRate);
			allowFire = true;
		}
	}
}
