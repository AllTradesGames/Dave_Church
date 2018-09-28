using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfrom : MonoBehaviour {
    public GameObject target;
    public float lerpSpeed = 1f;
    public Vector3 targetOffset;

    // Use this for initialization
    void Start()
    {
        target.transform.position = this.transform.position + targetOffset;
    }
    
  // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((target.transform.position-this.transform.position).normalized * Time.deltaTime * lerpSpeed);
        if ((target.transform.position - this.transform.position).magnitude < 0.1f)
        {
            if ((target.transform.position - this.transform.position).x > 0)
            {
                target.transform.position -= targetOffset;
            }
            else
            {
                target.transform.position += targetOffset;
            }
        }
    }
}
