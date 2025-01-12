using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial2 : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;

    public GameObject s_left;
    public GameObject s_right;
    public GameObject s_up;
    public GameObject s_down;

    public GameObject map;
    // Start is called before the first frame update
    bool s1 = false;
    bool s2 = false;
    bool s3 = false;
    bool s4 = false;
    void Start()
    {
        //PlayerPrefs.DeleteKey("stage_temp");
        //PlayerPrefs.SetInt("stage_temp",0);
        StartCoroutine("count");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("menu_scene");
        }
        if (!(Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift)))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                //Debug.Log("left");
                left.GetComponent<Animator>().SetBool("exit", true);
                s_left.transform.gameObject.SetActive(true);
                s_left.GetComponent<Animator>().SetTrigger("start");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                right.GetComponent<Animator>().SetBool("exit", true);
                s_right.transform.gameObject.SetActive(true);
                s_right.GetComponent<Animator>().SetTrigger("start");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                up.GetComponent<Animator>().SetBool("exit", true);
                s_up.transform.gameObject.SetActive(true);
                s_up.GetComponent<Animator>().SetTrigger("start");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                down.GetComponent<Animator>().SetBool("exit", true);
                s_down.transform.gameObject.SetActive(true);
                s_down.GetComponent<Animator>().SetTrigger("start");
            }
        }

        if((Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift)))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                s_left.GetComponent<Animator>().SetTrigger("exit");
                s1 = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                s_right.GetComponent<Animator>().SetTrigger("exit");
                s2 = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                s_up.GetComponent<Animator>().SetTrigger("exit");
                s3 = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                s_down.GetComponent<Animator>().SetTrigger("exit");
                s4 = true;
            }

            if(s1 && s2 && s3 && s4)
            {
                StartCoroutine("count2");
            }

        }
        
    }
    IEnumerator count2()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("menu_scene");
        // 함수 내용
    }
    IEnumerator count()
    {
        yield return new WaitForSeconds(120f);
        SceneManager.LoadScene("menu_scene");
        // 함수 내용
    }
}
