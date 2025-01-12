using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_rotate : MonoBehaviour
{
    public static mouse_rotate ms;
    float timer;
    float waitingTime;

    private float speed = 5f;

    public bool state_check = true;

    private GameObject [] player;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 0.5f;
        ms = this;
        player = GameObject.FindGameObjectsWithTag("player_obj");

    }

    // Update is called once per frame
    void Update()
    {
        bool player_check = true;

        for(int i = 0; i < player.Length; i++)
        {
            if (player[i].activeSelf == true)
            {
                player_check = player_check && (player[i].GetComponent<player>().forward == true) &&
                    (player[i].GetComponent<player>().gravity_ani_finish_check == false);
            }
        }

        if(//player[0].GetComponent<player>().forward == true && 
           //player[0].GetComponent<player>().gravity_ani_finish_check == false &&
            player_check &&
            map_rotate.rotate_cm.rotate_check)
        {
            if (Input.GetMouseButton(0))
            {
                transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
                transform.Rotate(-Input.GetAxis("Mouse Y") * speed, 0f, 0f);
                map_rotate.rotate_cm.mouse_move = true;
                state_check = false;

            }
            else
            {
                Vector3 temp = new Vector3(0, 0, 0);
                //transform.rotation = Quaternion.Lerp(transform.rotation,
                //       Quaternion.Euler(temp), Time.deltaTime * 15f);
                Quaternion rotateAmount = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(temp), 160f * Time.deltaTime);
                transform.rotation = rotateAmount;
                if (this.transform.rotation == Quaternion.Euler(temp))
                {
                    map_rotate.rotate_cm.mouse_move = false;
                    for (int i = 0; i < player.Length; i++)
                    {
                        if (player[i].activeSelf == true)
                        {
                            player[i].GetComponent<player>().mouce_time_check = true;
                        }
                    }
                }
            }
        }
        
    }
}
