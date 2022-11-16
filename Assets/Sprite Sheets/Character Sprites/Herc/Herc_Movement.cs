using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herc_Movement : MonoBehaviour
{

    //public

    public float walkSpeed = 18f;
    public float shieldSpeed = 0f;

    public Rigidbody2D rigid;
    public Animator animator;
    
    //private
    
    private Vector2 movement;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        rigid.MovePosition(rigid.position + (movement * walkSpeed * Time.fixedDeltaTime));
        
    }
}
