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

    public float timer = 0;
    public float prevTimer;
    public float seconds = 0;
    public float timeSinceCooldown = 0f;

    [SerializeField] public TMP_Text Ammo;
    [SerializeField] public GameObject gladius;
    [SerializeField] public GameObject bow;
    [SerializeField] public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        herc = GetComponent<Herc_Weapons>();
    }

    // Update is called once per frame
    void Update()
    {
        /*seconds = (Mathf.Round(timer%60));
        if (seconds < 10){
            Debug.Log((Mathf.Floor(timer/60).ToString()) + " : 0" + seconds.ToString());
        }
        else{
            Debug.Log((Mathf.Floor(timer/60).ToString()) + " : " + seconds.ToString());
        }*/
        Ammo.text = herc.currentAmmo.ToString();
        if (herc.currentAmmo == herc.maxAmmo){
            timer = 0;
        }
        else if (herc.currentAmmo < herc.maxAmmo){
            prevTimer = timer;
            timer += Time.deltaTime;
            seconds = (Mathf.Round(timer%60));
            Debug.Log((Mathf.Floor(timer/60).ToString()) + " : " + seconds.ToString());
            if (prevTimer % herc.arrowCoolDown > 1 && timer % herc.arrowCoolDown < 1 && herc.currentAmmo + 1 <= herc.maxAmmo){
                herc.currentAmmo += 1;
                timer = 0;
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
    }

    void OnCollisionEnter2D(Collision2D collision)      //when herc is hit
    {
        Debug.Log("Collision has occured");
    }
}
