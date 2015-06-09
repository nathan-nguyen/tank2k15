using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {

	public int durability = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReduceDurability(){
		durability--;
		if (durability == 0)
			Destroy (this.gameObject);
	}
}
