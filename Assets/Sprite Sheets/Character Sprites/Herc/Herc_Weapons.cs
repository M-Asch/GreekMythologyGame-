using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herc_Weapons : MonoBehaviour
{

    //Weapon Variables
    public int weapon;

    //bow
    public float arrowspeed = 20f;
    public float arrowCoolDown = 5f;
    public float maxAmmo = 5f;
    public float currentAmmo = 5f;
    public float bowDamage = 1f;
    public float bowAttackTime = 4.5f;

    //Sword
    public float swordDamage = 3f;
    public float attackTime = 0f;
    public float swordAttackTime = 2.5f;
    public float meleeRange = 3f;

    //Relics
    public float currentSpell = 0f;
    public float lionCoolDown = 15f;
    public bool lionUsed = false;
    
    //Objects
    public GameObject Arrow;
    public Animator animator;
    public Vector3 rotation;
    public Vector2 HercPosition;

    private Herc_Movement herc;
    private Herc_Stats hercS;

    //shield stuff 
    public float shieldRange = 2f;
    public float shieldCoolDown = 5f;
    public bool shieldUsed = false;
    Vector2 boxsize = new Vector2(2.0f, 2.0f);
    //public Vector2 shieldSize = Vector2();
    
    // Start is called before the first frame update
    void Start()
    {

        weapon = 1;
        animator.SetInteger("weapon", 1);
        herc = GetComponent<Herc_Movement>();
        hercS = GetComponent<Herc_Stats>();
        HercPosition = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
         HercPosition.x = herc.rigid.position.x;
         HercPosition.y = herc.rigid.position.y;   //get current position 

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
                if (weapon == 2 && (herc.movement.sqrMagnitude < 0.01) && (currentAmmo > 0)){    //shoot arrow
                    animator.SetBool("is_Attacking", true);
                    spawnArrow(HercPosition);
                    attackTime = bowAttackTime;
                }
                else if (weapon == 1){      //swing sword
                    animator.SetBool("is_Attacking", true);
                    meleeAttack(HercPosition);
                    attackTime = swordAttackTime;
                }
            }
        }
        if (attackTime <= 0){       //let animation/attack finish
            animator.SetBool("relic_Casting", false);
            if (Input.GetKeyDown(KeyCode.R) && !lionUsed){   //attack with weapons
                animator.SetBool("relic_Casting", true);
                attackTime = 5f;
                relicCast();
            }
        }
        if (attackTime <= 0){       //let animation/attack finish
            //animator.SetBool("relic_Casting", false);
            if (Input.GetKeyDown(KeyCode.F) && !shieldUsed){   //attack with weapons
                //animator.SetBool("relic_Casting", true);
                attackTime = 5f;
                shieldCast();
            }
        }
        else{
            attackTime -= Time.fixedDeltaTime;
        }
    }

    void spawnArrow(Vector2 HercPosition){
        currentAmmo -= 1;
        if (herc.lastDirectionHor == 0){
            if (herc.lastDirectionVert > 0){
                rotation = new Vector3(0f,0f,90f);
                HercPosition.y += 1;
            } else{
                rotation = new Vector3(0f,0f,-90f);
                HercPosition.y -= 1;
            }
        }
        else{
            if (herc.lastDirectionHor < 0){
                rotation = new Vector3(0f,0f,180f);
                HercPosition.x -= 1;
            } else{
                rotation = new Vector3(0f,0f,0f);
                HercPosition.x += 1;
            }
        }
        //StartCoroutine(pause());
        GameObject ar = Instantiate(Arrow, HercPosition, Quaternion.identity);
        ar.transform.Rotate(rotation);
        ar.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowspeed * herc.lastDirectionHor, arrowspeed * herc.lastDirectionVert), ForceMode2D.Impulse);
    }

    IEnumerator pause()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log(Time.time);
    }

    void meleeAttack(Vector2 HercPosition){
        Vector2 direction = new Vector2(herc.lastDirectionHor, herc.lastDirectionVert);
        RaycastHit2D hit = Physics2D.Raycast(HercPosition + direction, Vector2.zero, meleeRange);
        if (hit.collider != null)       //when herc hits with sword
        {
            Debug.Log(hit.collider.name);
        }
    }

    void relicCast(){
        switch(currentSpell){
            default:
                break;
            case 0:
                hercS.shields += 2;
                lionUsed = true;
                break;
        }
    }

    void shieldCast(){
        shieldUsed = true;
        Vector2 direction = new Vector2(herc.lastDirectionHor, herc.lastDirectionVert);
        RaycastHit2D hit = Physics2D.BoxCast(HercPosition + (direction * 3), boxsize, 0f, direction, shieldRange);
        if (hit.collider != null)       //when herc hits with sword
        {
            Debug.Log(hit.collider.name);
        }
    }
}
