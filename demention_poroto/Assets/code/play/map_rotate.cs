using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class map_rotate : MonoBehaviour
{
    public static map_rotate rotate_cm;

    bool col_check = true;

    Vector3 this_rotate = new Vector3(0, 0, 0);
    public bool rotate_check = true;
    bool shift_check = true;

    bool axix_check = true;
    bool rlaxix_check = true;
    bool rlaxix_check2 = true;
    int rlaxix = 0;


    Vector3 start_rotate = new Vector3(0, 0, 0);

    int roate_rc = 0;

    public bool player_move = false;
    

    public bool mouse_move = false;

    Vector3 temp;

    private GameObject[] player;

    // Start is called before the first frame update
    void Start()
    {
        rotate_cm = this;
        player = GameObject.FindGameObjectsWithTag("player_obj");
        //start_rotate =  스타트 로테이트 초기화 필요
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("col_check" + col_check);

        bool temp_player_check = true;

        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].activeSelf == true)
            {
                temp_player_check = temp_player_check && (player[i].GetComponent<player>().player_move_check == false);
            }
        }


        if (!Input.GetMouseButton(0) && temp_player_check && !mouse_move)
        {
            //Debug.Log("rotate x " + this.transform.rotation.eulerAngles.x);
            //Debug.Log("rc" + rotate_check);
            //Debug.Log("srotate" + start_rotate);
            //Debug.Log("trotate" + this_rotate);
            //Debug.Log("nrotate" + this.transform.rotation.eulerAngles);
            if (this.transform.rotation == Quaternion.Euler(this_rotate))
            {
                rotate_check = true;
                roate_rc = 0;
                if (col_check)
                {
                    //시프트로 중력 작용중에 작동 되도록 만들기 위해서는 이코드 활성화 필요
                    //start_rotate = new Vector3(this_rotate.x, this_rotate.y, this_rotate.z);
                }
            }
            else if(rotate_check == false)
            {
                roate_rc++;
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.Euler(this_rotate), Time.deltaTime * 20f);

                if (roate_rc > 30)
                {
                    rotate_check = true;
                    transform.rotation = Quaternion.Euler(this_rotate);
                    roate_rc = 0;
                }
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {

                
                if (shift_check)
                {
                    start_rotate = new Vector3(this_rotate.x, this_rotate.y, this_rotate.z);
                    //Debug.Log("shift1");
                    shift_check = false;
                }

                if (rotate_check)
                {
                    
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        //Debug.Log("shift");
                        //Debug.Log(axix_check + "axix");
                        //Debug.Log("w");
                        temp = new Vector3(0, 0, 90);


                        //if(transform.rotation.eulerAngles.x >= -92
                        //    && transform.rotation.eulerAngles.x <= -88) { temp = new Vector3(90, 0, 0); }
                        //else if (rlaxix_check) { temp = new Vector3(0, 0, 90); }
                        //else { temp = new Vector3(-90, 0, 0); }

                        //StartCoroutine(mapturnlr(new Vector3(0, 0, 90)));
                        

                        this_rotate += temp;
                        rotate_check = false;
                        axix_check = !axix_check;
                    }
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        //Debug.Log("shift");
                        //Debug.Log(axix_check + "axix");
                        //Debug.Log("a");
                        //temp = new Vector3(0, -90, 0);
                        if (axix_check) { temp = new Vector3(0, -90, 0); }
                        else { temp = new Vector3(0, 90, 0); }
                        this_rotate += temp;
                        rotate_check = false;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        //Debug.Log("shift");
                        //Debug.Log(axix_check + "axix");
                        //Vector3 temp = new Vector3(-90, 0, 0);
                        temp = new Vector3(0, 0, -90);
                        //if (transform.rotation.eulerAngles.x >= -92
                        //    && transform.rotation.eulerAngles.x <= -88) { temp = new Vector3(-90, 0, 0); }
                        //else if (rlaxix_check) { temp = new Vector3(0, 0, -90); }
                        //else { temp = new Vector3(90, 0, 0); }

                        this_rotate += temp;
                        rotate_check = false;
                        axix_check = !axix_check;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        //Debug.Log("shift");
                        //Debug.Log(axix_check + "axix");
                        //Debug.Log("d");
                        //temp = new Vector3(0, 90, 0);
                        if (axix_check) { temp = new Vector3(0, 90, 0); }
                        else { temp = new Vector3(0, -90, 0); }
                        this_rotate += temp;
                        rotate_check = false;
                    }
                }
            }
            else
            {
                if (!col_check)
                {
                    //Debug.Log("col_check" + col_check);
                    this_rotate = new Vector3(start_rotate.x, start_rotate.y, start_rotate.z);
                    rotate_check = false;
                }
                
                shift_check = true;
            }

        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            col_check = false;
            rotate_check = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            col_check = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            col_check = false;
            rotate_check = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            col_check = true;
        }
    }

}
