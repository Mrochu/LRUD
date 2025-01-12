using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_col : MonoBehaviour
{

    public GameObject player_postion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player_postion.transform.position;
    }
}
