using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Travel : MonoBehaviour
{

    public float arrowSpeed = 24f;
    public Rigidbody2D rigid;

    private float arrowHort;
    private float arrowVert;
    public Vector2 arrowMovement;
    public GameObject herc;
    
    private Herc_Movement hercM;


    // Start is called before the first frame update
    void Start()
    {
        hercM = herc.GetComponent<Herc_Movement>();
        
        arrowMovement = hercM.movement;
        Debug.Log(hercM.walkSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(rigid.position + (arrowMovement * arrowSpeed * Time.fixedDeltaTime));
        //Debug.Log(arrowMovement);
    }
}
