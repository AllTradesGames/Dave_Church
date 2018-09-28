using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class momicaScript : MonoBehaviour
{
    public GameObject target;
    public float lerpSpeed = 1;
    public Vector3 targetOffset;

    public string message = "HELP HELP!!! DAVE!!! WE NEED TO SAVE PASTOR BARRY";
    public UnityEngine.UI.Text uitext;
    public UnityEngine.UI.Text nametext;
    public GameObject textbox;
    // Use this for initialization
    void Start()
    {
        target.transform.position = this.transform.position + targetOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, lerpSpeed);
        if ((target.transform.position - this.transform.position).magnitude < 0.1f)
        {
            if ((target.transform.position - this.transform.position).x > 0)
            {
                target.transform.position -= targetOffset;
                transform.Rotate(new Vector3(0, 180));
            }
            else
            {
                target.transform.position += targetOffset;
                transform.Rotate(new Vector3(0, -180));
            }
        }
    }




    IEnumerator textreader()
    {

        while (uitext.text.Length < message.Length)
        {
            uitext.text += message.Substring(uitext.text.Length, 1);
            yield return new WaitForSeconds(0.2f);
        }

    }

void OnTriggerEnter2D(Collider2D coll){
if(coll.gameObject.CompareTag("Player")){
    StartCoroutine("textreader");
    targetOffset=Vector3.zero;
    nametext.text="Monica";
    textbox.SetActive(true);
}
}




}
