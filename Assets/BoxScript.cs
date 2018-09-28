using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject[] objects;

    private bool open = false;
    private GameObject thing = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObjects()
    {
        if (!open)
        {
            foreach (GameObject item in objects)
            {
                thing = Instantiate(item, transform.position, transform.rotation);
                thing.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,600f));
            }
        }
        open = true;
    }

}
