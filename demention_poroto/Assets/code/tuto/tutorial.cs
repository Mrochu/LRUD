using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{

    public GameObject map;
    
    public GameObject mouse_ui;
    public GameObject arrow;
    public GameObject shift;

    float timer;
    int waitingTime;
    bool endtuto = false;
    int tuto_check;
    // Start is called before the first frame update
    void Start()
    {
        tuto_check = PlayerPrefs.GetInt("tutorial_clear", 0);
        if(tuto_check == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        timer = 0f;
        waitingTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (endtuto)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                map.gameObject.SetActive(false);
            }
        }

        if (Input.GetMouseButton(0))
        {
            mouse_ui.gameObject.SetActive(false);
            arrow.gameObject.SetActive(true);
            shift.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                arrow.gameObject.SetActive(false);
                shift.gameObject.SetActive(false);
                endtuto = true;
                PlayerPrefs.SetInt("tutorial_clear", 1);
                //map.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                arrow.gameObject.SetActive(false);
                shift.gameObject.SetActive(false);
                endtuto = true;
                PlayerPrefs.SetInt("tutorial_clear", 1);
                //map.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                arrow.gameObject.SetActive(false);
                shift.gameObject.SetActive(false);
                endtuto = true;
                PlayerPrefs.SetInt("tutorial_clear", 1);
                //map.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                arrow.gameObject.SetActive(false);
                shift.gameObject.SetActive(false);
                endtuto = true;
                PlayerPrefs.SetInt("tutorial_clear", 1);
                //map.gameObject.SetActive(false);
            }
        }
    }


}
