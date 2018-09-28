using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public Vector2 Force;
    public Vector2 HitForce;
    public float Damage = 1f;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(Force);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boss")
        {
            Rigidbody2D Dave;
            Dave = col.GetComponent<Rigidbody2D>();
            if (Dave != null)
            {
                Debug.Log("force");
                Dave.AddForce(HitForce);
            }
            col.GetComponent<JumpyDragon>().Damage(Damage);
            Destroy(this.transform.root.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
