using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_check : MonoBehaviour
{
    public GameObject fa;

    public int arrow;
    public int flow;

    // Start is called before the first frame update
    void Awake()
    {
        
        //fa = GameObject.Find("check_all");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //
        //check_S[arrow][flow] = true;
        //check_val = true;

        if(other.tag == "MAP")
        {
            fa.GetComponent<cheching>().check_val[arrow, flow] = true;
        }

        
        //실행문
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MAP")
        {
            fa.GetComponent<cheching>().check_val[arrow, flow] = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MAP")
        {
            fa.GetComponent<cheching>().check_val[arrow, flow] = false;
            //check_val = false;
            //fa.GetComponent<player>().nomal_check = false;
            //실행문
        }
    }

}
