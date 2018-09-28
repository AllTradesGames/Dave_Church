using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpyattack : MonoBehaviour
{
    public float jumpX = 1;
    public float jumpY = 1;
    public float jumpDelay = 1;
    private float lastJumpTime = 0;
    private Transform Dave;
    // Use this for initialization
    void Start()
    {
        Dave = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (lastJumpTime + jumpDelay))
        {
            if (0 < (Dave.position.x - this.transform.position.x))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpX, jumpY));
            }
            else
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-jumpX, jumpY));
            }
            lastJumpTime = Time.time;
        }
    }
}
