using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_all : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("tutorial_clear", 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.DeleteAll();
    }
}
