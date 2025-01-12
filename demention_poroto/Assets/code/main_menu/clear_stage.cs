using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear_stage : MonoBehaviour
{
    public static int max_clear = PlayerPrefs.GetInt("clear_state", 1);

    public static void max_plus()
    {
        max_clear++;
        PlayerPrefs.SetInt("clear_state", max_clear);
       
        //public static void save();
        
    }

    void Start()
    {
        max_clear = PlayerPrefs.GetInt("clear_state", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
