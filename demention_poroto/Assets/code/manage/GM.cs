using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//using UnityEngine.Windows;

public class GM : MonoBehaviour
{
    public GameObject ani_obj;
    GameObject[] player_arr;
    private Animator animation;
    public static GM GM_manager;
    public static int max_state;
    public int count_act_point;
    int points;
    string next_stage;

    private int stage;
    private bool finish_ani = false;
    float timer;
    float waitingTime;

    bool exit = false;
    //AudioSource audioSource = this.tranceform.gameObject.AddComponent<AudioSource>();
    // Start is called before the first frame updat
    void Awake()
    {
        //Screen.SetResolution(1920, 1080, true);
        ani_obj.SetActive(true);
        GM_manager = this;
        animation = ani_obj.GetComponent<Animator>();
        timer = 0.0f;
        waitingTime = 1.5f;
        stage = 0;
        player_arr = GameObject.FindGameObjectsWithTag("player_obj");

        max_state = 40;
        
        if (SceneManager.GetActiveScene().name.IndexOf("stage") != -1)
        {
            int temp = int.Parse(SceneManager.GetActiveScene().name.Substring(5)) + 1;
            if(temp > max_state)
            {
                PlayerPrefs.SetInt("stage_temp", max_state);
                next_stage = "stage" + max_state.ToString();
            }
            else
            {
                Debug.Log("c "+temp);
                PlayerPrefs.SetInt("stage_temp", temp - 2);
                next_stage = "stage" + temp.ToString();
            }
            
        }


        points = GameObject.FindGameObjectsWithTag("point").Length;

    }

    public void dead_check()
    {
        if(SceneManager.GetActiveScene().name == "tuto")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene" )
        {
            SceneManager.LoadScene("menu_scene");
        }
        else if (SceneManager.GetActiveScene().name == "menu_scene")
        {

        }
        else if (finish_ani == false && exit == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (exit == true)
        {
            SceneManager.LoadScene("menu_scene");
        }
        /*
        for (int i = 0; i < player_arr.Length; i++)
        {
            //Debug.Log("invis");
            if (player_arr[i].activeSelf == true)
            {
                break;
                
                //if (player_arr[i].GetComponent<player>().visible_check == true)
                //{
                //    break;
                //}
            }
            else if ((i + 1) == player_arr.Length)
            {
                if (SceneManager.GetActiveScene().name == "SampleScene")
                {
                    SceneManager.LoadScene("menu_scene");
                }
                else if (SceneManager.GetActiveScene().name == "menu_scene")
                {

                }
                else if (finish_ani == false && exit == false)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else if (exit == true)
                {
                    SceneManager.LoadScene("menu_scene");
                }

            }
        }*/
    }

    public void point_check()
    {
        if (points <= count_act_point)
        {
            if(clear_stage.max_clear <= int.Parse(SceneManager.GetActiveScene().name.Substring(5)) + 1)
            {
                clear_stage.max_plus();
            }


            animation.SetTrigger("finish");
            finish_ani = true;
        }
    }

    public void scene_exit()
    {
        exit = true;
        next_stage_move();
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (finish_ani)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                
                if (SceneManager.GetActiveScene().name == "SampleScene" )
                {
                    SceneManager.LoadScene("menu_scene");
                }
                else if (SceneManager.GetActiveScene().name == "menu_scene")
                {

                }
                else if (SceneManager.GetActiveScene().name == "tuto")
                {
                    SceneManager.LoadScene("SampleScene");
                }
                else
                {
                    //PlayerPrefs.SetInt("stage_temp", max_state);
                    SceneManager.LoadScene(next_stage);
                }

            }
        }

        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.E))
            if (SceneManager.GetActiveScene().name == "menu_scene")
            {

                {
                    Application.Quit();
                }
            }
            else
            {
                scene_exit();
            }
    }

    public void next_stage_move()
    {
        animation.SetTrigger("finish");
        finish_ani = true;
    }
}
