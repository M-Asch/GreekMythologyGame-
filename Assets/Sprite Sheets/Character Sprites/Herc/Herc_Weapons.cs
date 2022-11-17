using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herc_Weapons : MonoBehaviour
{

    public float arrowspeed = 20f;

    public float swordDamage = 3f;
    public float bowDamage = 1f;

    public int weapon;

    public float attackTime = 0f;
    public float swordAttackTime = 6f;
    public float bowAttackTime = 12f;
    //public float bowAttackTime = .25;


    public Animator animator;
    
    private Herc_Movement herc;

    // Start is called before the first frame update
    void Start()
    {
        weapon = 1;
        animator.SetInteger("weapon", 1);
        herc = GetComponent<Herc_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){   //swap weapons
            weapon = 2;
            animator.SetInteger("weapon", 2);
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            weapon = 1;
            animator.SetInteger("weapon", 1);
        }

        if (attackTime <= 0){       //let animation/attack finish
            animator.SetBool("is_Attacking", false);
            if (Input.GetKeyDown(KeyCode.Space)){   //attack with weapons
                if (weapon == 2 && (herc.movement.sqrMagnitude < 0.01)){
                    animator.SetBool("is_Attacking", true);
                    attackTime = bowAttackTime;
                }
                else if (weapon == 1){
                    animator.SetBool("is_Attacking", true);
                    attackTime = swordAttackTime;
                }
            }
        }
        else{
            attackTime -= Time.fixedDeltaTime;
        }
    }

    void swordAttack(){

    }
}
