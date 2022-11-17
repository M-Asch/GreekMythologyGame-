using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Travel : MonoBehaviour
{

    public float timeAlive = 0f;

    // Update is called once per frame
    void Start(){

    }

    void Update()
    {
        if (timeAlive > 20){
            Destroy(gameObject);
        }
        timeAlive += Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)   //when arrow hits something
    {
        Debug.Log("i hit something");
        Destroy(gameObject);
    }
}
