using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    public Vector2 bouncySnek;
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Rigidbody2D Dave;
            Dave = col.GetComponent<Rigidbody2D>();
            if (Dave != null)
            {
                Debug.Log("force");
                Dave.AddForce(bouncySnek);
            }
            Destroy(this.transform.root.gameObject);
        }
    }
}
