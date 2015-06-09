using UnityEngine;
using System.Collections;

public class GeneralBullet : MonoBehaviour {

	protected AI shooter;
	protected int damage;

	private float bulletSpeed = 10f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetShooter(AI shooter){
		this.shooter = shooter;
	}

	public void SetDamage(int damage){
		if (damage > 0)
			this.damage = damage;
	}

	public float GetBulletSpeed(){
		return this.bulletSpeed;
	}

	public void SetBulletSpeed(float bulletSpeed){
		this.bulletSpeed = bulletSpeed;
	}
}
