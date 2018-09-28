using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDave : MonoBehaviour
{

    public float amount = 1f;
    private Dave_Health healthScript;
    // Use this for initialization
    void Start()
    {
        healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Dave_Health>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            healthScript.heal(amount);
        }

    }
}
