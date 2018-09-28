using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyDragon : MonoBehaviour {

	public Vector2 jumpDelay;
	public Vector2 jumpDirection;
	public float maxHealth = 5f;
	public Transform healthBar;
	public GameObject fire;
	public float fireDuration = 1f;
	public float fireDelay = 2f;

	private float lastJumpTime = 0;
	private float lastFireTime = 0;
	private int dirMod = 0;

	private float currentHealth;
	private bool fireOn = false;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		UpdateBar();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > (lastJumpTime + Random.Range(jumpDelay.x,jumpDelay.y))){
			lastJumpTime = Time.time;
			dirMod = Mathf.RoundToInt(Random.Range(-1,1));
			transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirMod * jumpDirection.x, jumpDirection.y));
			Vector3 theScale = transform.localScale;
			if(dirMod<0){
				if(theScale.x<0){
            		theScale.x *= -1;
				}
			} else {
				if(theScale.x>0){
            		theScale.x *= -1;
				}
			}
            transform.localScale = theScale;
		}
		if (fireOn){
		if(Time.time > (lastFireTime + fireDuration)){
			fireOn = false;
			fire.SetActive(false);
		}
		} else {
		if(Time.time > (lastFireTime + fireDelay)){
			fireOn = true;
			lastFireTime = Time.time;
			fire.SetActive(true);
		}
		}
	}

 	public void Damage(float dmg){
		currentHealth -= dmg;
		UpdateBar();
 	}

	void UpdateBar(){
		healthBar.transform.localScale = new Vector3(currentHealth/maxHealth, healthBar.transform.localScale.y,healthBar.transform.localScale.z);
	}
}
