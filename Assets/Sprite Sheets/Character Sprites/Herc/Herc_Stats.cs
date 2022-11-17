using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herc_Stats : MonoBehaviour
{

    public float health = 6;
    public int shields = 3;

    public int exp = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision has occured");
    }
}
