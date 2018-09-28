using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dave_Health : MonoBehaviour
{

    public float health = 3f;
    public bool isInvincible = false;
    private float invincibleDuration = 1f;
    private float invincibleStartTime = 0f;
    public float heartOffset;
    public Vector3 heartstartPosition;
    public GameObject heartPrefabLeft;
    public GameObject heartPrefabRight;
    public Sprite opensprite;

    private GameObject temp;
    private GameController controlScript;

    // Use this for initialization
    void Start()
    {
        controlScript = this.gameObject.GetComponent<GameController>();
        RenderHearts();
    }

    public void RenderHearts()
    {

        foreach (Transform child in this.transform.Find("Hearts"))
        {
            GameObject.Destroy(child.gameObject);
        }
        for (float ii = 0.5f; ii <= health; ii += 0.5f)
        {
            if (Mathf.Round(ii) == ii)
            {
                temp = Instantiate(heartPrefabRight, Vector3.zero, Quaternion.identity, this.transform.Find("Hearts"));
                temp.transform.localPosition = new Vector3(heartstartPosition.x + (ii * 2f * heartOffset), heartstartPosition.y, heartstartPosition.z);
            }
            else
            {
                temp = Instantiate(heartPrefabLeft, Vector3.zero, Quaternion.identity, this.transform.Find("Hearts"));
                temp.transform.localPosition = new Vector3(heartstartPosition.x + (ii * 2f * heartOffset), heartstartPosition.y, heartstartPosition.z);
            }
        }







    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - invincibleStartTime > invincibleDuration)
        {
            isInvincible = false;
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "DEATH")
        {
            controlScript.DaveDied();
        }
        if (coll.gameObject.tag == "baby dont hurt me no more" && !isInvincible)
        {
            heal(-1f);
        }
        if (coll.gameObject.tag == "nomnom")
        {
            heal(1f);
            Destroy(coll.gameObject);
        }

    }


    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Respawn")
        {
            controlScript.spawnPosition = coll.transform.position;
        }

        if (coll.gameObject.tag == "ClosedBox")
        {
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = opensprite;
            coll.GetComponent<BoxScript>().SpawnObjects();
        }

        if (coll.gameObject.tag == "door")
        {
            Debug.Log("door");
            SceneManager.LoadScene("Pride", LoadSceneMode.Single);
        }
    }

    public void heal(float amount)
    {
        Debug.Log("heal "+amount);
        health += amount;
        RenderHearts();
        if (amount < 0)
        {
            invincibleStartTime = Time.time;
            isInvincible = true;
        }
        if (health <= 0f) { controlScript.DaveDied(); }
    }




}
