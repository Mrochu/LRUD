using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheching : MonoBehaviour
{

    public bool re_gravity = false;

    public GameObject player_postion;
    public bool[,] check_val = new bool[5,3];
    // Start is called before the first frame update
    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = player_postion.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            
        this.transform.position = player_postion.transform.position;
        if(re_gravity == true)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
