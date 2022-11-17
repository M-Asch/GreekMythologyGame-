using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Herc_Stats : MonoBehaviour
{

    public float health = 6;
    public int shields = 3;

    public int exp = 0;
    public Herc_Weapons herc;

    public float timeFire = 0;
    public float prevtimeFire;

    public float timeLion = 0;
    public float prevTimeLion;

    [SerializeField] public TMP_Text Ammo;
    [SerializeField] public GameObject gladius;
    [SerializeField] public GameObject bow;
    [SerializeField] public GameObject shield;
    [SerializeField] public GameObject lionrelic;
    // Start is called before the first frame update
    void Start()
    {
        herc = GetComponent<Herc_Weapons>();
    }

    // Update is called once per frame
    void Update()
    {
        Ammo.text = herc.currentAmmo.ToString();
        if (herc.currentAmmo == herc.maxAmmo){
            timeFire = 0;
        }
        else if (herc.currentAmmo < herc.maxAmmo){
            prevtimeFire = timeFire;
            timeFire += Time.deltaTime;
            if (prevtimeFire % herc.arrowCoolDown > 1 && timeFire % herc.arrowCoolDown < 1 && herc.currentAmmo + 1 <= herc.maxAmmo){
                herc.currentAmmo += 1;
                timeFire = 0;
            }
        }

        if (!herc.lionUsed){
            timeLion = 0;
        }
        else if (herc.lionUsed){
            prevTimeLion = timeLion;
            timeLion += Time.deltaTime;
            if (prevTimeLion % herc.lionCoolDown > 1 && timeLion % herc.lionCoolDown < 1){
                herc.lionUsed = false;
                timeLion = 0;
            }
        }

        if (herc.weapon == 1){
            bow.GetComponent<Renderer>().enabled = false;
            gladius.GetComponent<Renderer>().enabled = true;
        }
        else if (herc.weapon == 2){
            bow.GetComponent<Renderer>().enabled = true;
            gladius.GetComponent<Renderer>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.R)){
            lionrelic.GetComponent<Renderer>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)      //when herc is hit
    {
        Debug.Log("Collision has occured");
    }
}
