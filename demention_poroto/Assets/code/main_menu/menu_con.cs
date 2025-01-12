using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menu_con : MonoBehaviour
{
    public TMP_Text tmp;
    private Animator animator;
    private int stage = 1;
    public int max_stage;

    private bool finish_ani = false;
    float timer;
    float waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        //stage = PlayerPrefs.GetInt("clear_state", 1);
        max_stage = clear_stage.max_clear;
        animator = GetComponent<Animator>();
        timer = 0.0f;
        waitingTime = 1.5f;

        if (PlayerPrefs.GetInt("stage_temp") != 0)
        {
            Debug.Log("b " + stage);
            stage = PlayerPrefs.GetInt("stage_temp");
            tmp.text = stage.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {

        }*/

        if (!finish_ani)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("next", true);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                animator.SetBool("reload", true);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetMouseButton(0))
            {
                animator.SetBool("new_sc", true);
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                Debug.Log("a " + stage);
                PlayerPrefs.SetInt("stage_temp", stage);
                SceneManager.LoadScene("stage" + stage.ToString());
                timer = 0;
            }
        }
    }

    void update_count()
    {
        stage++;
        if (stage >= max_stage) {

            stage = max_stage;
            //PlayerPrefs.SetInt("stage_temp", stage);
        }
        tmp.text = stage.ToString();
        animator.SetBool("next", false);
    }

    public void reload_count()
    {
        if(stage <= 1)
        {
            stage = 1;
            //PlayerPrefs.SetInt("stage_temp", stage);
        }
        else
        {
            stage--;
            //PlayerPrefs.SetInt("stage_temp",stage);
        }
        animator.SetBool("reload", false);
        tmp.text = stage.ToString();
    }

    public void road_new_scene()
    {
        GM.GM_manager.next_stage_move();
        finish_ani = true;
    }

}
