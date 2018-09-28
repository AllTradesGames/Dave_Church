using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watergun : MonoBehaviour {

	public GameObject BulletPrefab;
	public Vector3 BulletPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
				Instantiate(BulletPrefab,transform.position +BulletPosition,Quaternion.identity);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "Player")
        {
            this.transform.parent = coll.transform;
            this.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
            this.transform.localPosition = new Vector3(0.426f, -0.113f, 0f);
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
