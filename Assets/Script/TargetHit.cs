using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private bool isTouched;
    public FollowMouse cursor;
    public GameObject border;


    // Update is called once per frame

    private void Start() {
        isTouched = false;
        border.GetComponent<Renderer>().enabled = false;
    }

    
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(GetComponent<SpriteRenderer>().color + "name : " + gameObject.name );
            GetComponent<SpriteRenderer>().color = Color.red;
            border.GetComponent<Renderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other) {

        Debug.Log(GetComponent<SpriteRenderer>().color + "name : " + gameObject.name );
        GetComponent<SpriteRenderer>().color = Color.white;
        border.GetComponent<Renderer>().enabled = false;

    }
}
