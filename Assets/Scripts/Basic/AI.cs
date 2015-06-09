using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AI : MonoBehaviour {

	public GameObject image;

	public Vector3 originalPosition;

	public GameObject bombPrefab;

	private float maxSpeed = 2f;

	private float healthPoint = 100f;

	protected int kill = 0;
	protected int death = 0;

	public int direction = 0;
	private bool isControllable = false;

	private int bulletPower = 1;

	public bool shootable = true;

	private KeyCode fireButton = KeyCode.None;

	private bool allowFire = true;

	private bool invulnerable = false;

	protected Vector3 LEFT_DIRECTION  = new Vector3(0  ,0,  90);
	protected Vector3 RIGHT_DIRECTION = new Vector3(0  ,0, -90);
	protected Vector3 UP_DIRECTION    = new Vector3(0  ,0,  0 );
	protected Vector3 DOWN_DIRECTION  = new Vector3(180 ,0,  0 );

	private List<string> inventory = new List<string> ();

	private string displayItemList = "";

	private string personalTag;

	// Use this for initialization
	void Start () {
		InitializeAI ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void InitializeAI(){
		this.SetControllable (true);
		this.SetMaxSpeed (2f);
		this.SetBulletPower (1);		
	}

	public int GetBulletPower(){
		return this.bulletPower;
	}

	public void SetBulletPower(int bulletPower){
		this.bulletPower = bulletPower;
	}

	public void SetFireButton(KeyCode fireButton){
		this.fireButton = fireButton;
	}

	public KeyCode GetFireButton(){
		return fireButton;
	}

	public bool IsAllowFire(){
		return this.allowFire;
	}

	public void SetAllowFire(bool allowFire){
		this.allowFire = allowFire;
	}

	public void TakeDamage(float damageAmount, AI tankAI){
		if (this.invulnerable)
			return;

		this.healthPoint -= damageAmount;

		if (healthPoint <= 0) {

			if (tankAI.GetPersonalTag() != this.GetPersonalTag())
				tankAI.IncreaseKill();

			this.IncreaseDeath();
			this.invulnerable = true;
			StartCoroutine(WaitToRespawn());

			return;
		}

		if (this.personalTag == "second team")
			this.GetComponent<Enemy> ().ActivateCrazyMode ();
	}

	public int GetDirection(){
		return this.direction;
	}

	public void SetControllable(bool isControllable){
		this.isControllable = isControllable;
	}

	public bool IsControllable(){
		return isControllable;
	}

	public float GetMaxSpeed(){
		return this.maxSpeed;
	}

	public void SetMaxSpeed(float maxSpeed){
		this.maxSpeed = maxSpeed;
	}

	public Vector3 GetDirectionVector(int direction){
		switch (direction) {
		case 0:
			return Vector3.up;
		case 1:
			return Vector3.right;
		case 2:
			return Vector3.left;
		default:
			return Vector3.down;
		}
	}

	public void SetPersonalTag(string personalTag){
		this.personalTag = personalTag;
	}

	public string GetPersonalTag(){
		return this.personalTag;
	}

	public bool IsShootable(){
		return this.shootable;
	}

	public void SetShootable(bool shootable){
		this.shootable = shootable;
	}

	public void AddItem(string item){
	switch (item) {		
		case "Gear" :
			increaseHealth(75);
			break;
		default:
			this.inventory.Add (item);
			if (this.inventory.Count > 3)
				this.inventory.Remove (inventory [0]);
			break;
		}

		UpdateDisplayItemList ();
		if (item != "Bomb" && item != "Rocket" && this.personalTag == "second team")
			this.UseItem (item);
	}

	private void UpdateDisplayItemList(){
		displayItemList = "";
		for (int i = 0; i < inventory.Count; i++)
			displayItemList += inventory [i] + " ";
	}

	public string GetItem(int order){
		if (order >= this.inventory.Count)
			return "null";
		return this.inventory [order];
	}

	protected void RemoveItem(string item){
		if (this.inventory.Contains(item))
			this.inventory.Remove(item);
		UpdateDisplayItemList ();
	}

	protected string GetDisplayItemList(){
		return this.displayItemList;
	}

	private void increaseHealth(int amount){
		this.healthPoint = Mathf.Min (100, this.healthPoint + amount);
	}

	protected float GetHealthPoint(){
		return this.healthPoint;
	}

	protected void Repawn(){
		InitializeAI ();
		this.bulletPower = 1;
		this.transform.position = this.originalPosition;
		this.healthPoint = 100;
		StartCoroutine (InvulnerableStatus ());
		this.SetShootable (true);
	}

	protected void UseItem(string item){
		if (item == null)
			return;
		switch (item) {
			case "Bomb" : 
				GameObject g = Instantiate(bombPrefab, transform.position - this.GetDirectionVector(this.direction), Quaternion.Euler(Vector3.zero)) as GameObject;				
				g.GetComponent<Bomb>().SetShooter(this);
				this.RemoveItem("Bomb");
				break;
			case "TwoPower":
				this.bulletPower = 2;
				this.RemoveItem("TwoPower");
				break;
			case "ThreePower":
				this.bulletPower = 3;
				this.RemoveItem("ThreePower");
				break;
			case "Rocket" :
				this.bulletPower = 4;
				this.RemoveItem("Rocket");
				break;
		}
	}

	IEnumerator InvulnerableStatus(){
		yield return new WaitForSeconds(1);
		this.invulnerable = false;
	}

	IEnumerator WaitToRespawn(){
		this.SetShootable (false);
		this.GetComponent<BoxCollider2D> ().enabled = false;
		this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		this.image.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds(5f);
		this.GetComponent<BoxCollider2D> ().enabled = true;
		this.image.GetComponent<SpriteRenderer> ().enabled = true;
		this.Repawn();
	}

	private void IncreaseKill(){
		kill++;
	}

	private void IncreaseDeath(){
		death++;
	}

}
