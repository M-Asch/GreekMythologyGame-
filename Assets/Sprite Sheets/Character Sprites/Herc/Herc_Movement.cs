using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herc_Movement : MonoBehaviour
{

    //public

    public float walkSpeed = 6f;
    public float shieldSpeed = 0f;

    public Rigidbody2D rigid;
    public Animator animator;

    public float lastDirectionHor = 0;
    public float lastDirectionVert = 1;
    
    public Vector2 movement;
    //private
    private Herc_Weapons herc;

    
    // Start is called before the first frame update
    void Start()
    {
        herc = GetComponent<Herc_Weapons>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!(Mathf.Abs(movement.x)  < 0.01)){                      //save last direction moved to preserve movment
            lastDirectionHor = Input.GetAxisRaw("Horizontal");
            lastDirectionVert = 0;
        }
        else if (!(Mathf.Abs(movement.y)  < 0.01)){
            lastDirectionVert = Input.GetAxisRaw("Vertical");
            lastDirectionHor = 0;
        }

        animator.SetFloat("horizontal", lastDirectionHor);
        animator.SetFloat("vertical", lastDirectionVert);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        rigid.MovePosition(rigid.position + (movement * walkSpeed * Time.fixedDeltaTime));
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
    }
}
