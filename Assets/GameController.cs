using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Vector3 spawnPosition;

    private Dave_Health healthScript;

    // Use this for initialization
    void Start()
    {
        healthScript = this.gameObject.GetComponent<Dave_Health>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DaveDied()
    {
        // Queue Scream

        // Show "You Died" message

        // 7s later Respawn
        this.transform.position = spawnPosition;
        healthScript.health = 3f;
        healthScript.RenderHearts();
        Debug.Log("Dave died");
    }
}
