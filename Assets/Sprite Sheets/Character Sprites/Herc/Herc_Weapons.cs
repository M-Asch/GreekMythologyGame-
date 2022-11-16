using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herc_Weapons : MonoBehaviour
{

    public float arrowspeed = 20f;

    public int weapon;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        weapon = 1;
        animator.SetInteger("weapon", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            weapon = 2;
            animator.SetInteger("weapon", 2);
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            weapon = 1;
            animator.SetInteger("weapon", 1);
        }
    }
}
