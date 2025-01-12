using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool visible_check;
    public bool player_move_check = false;

    float timer;
    int waitingTime;
    bool colid_check = false;

    bool change_gravity_col_check = false;
    public bool change_gravity = false;

    public Material defalt_color;

    public enum Direction
    {
        right = 0,
        left = 1,
        up = 2,
        down = 3
    }

    public GameObject check_obj;

    public bool nomal_check = false;
    
    private Animator animator;
    private bool telelport1_check = false;
    private bool telelport2_check = false;
    private bool teleport_rotate_check = true;
    private GameObject teleport_postion;

    public bool gravity_ani_finish_check = false;

    private void OnBecameInvisible()
    {
        visible_check = false;
        map_rotate.rotate_cm.player_move = false;
        Destroy(check_obj);
        this.transform.gameObject.SetActive(false);
        GM.GM_manager.dead_check();
    }
    private void Awake()
    {
        visible_check = true;
        //check_obj = GameObject.Find("check_all");
        animator = GetComponent<Animator>();
    }

    public bool forward = true;
    public bool mouce_time_check = true;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
        //defalt_color = this.GetComponent<Color>();
    }

    void move(int diret)
    {
        
        //있으면 true 없으면 false
        if (check_obj.GetComponent<cheching>().check_val[diret, 1] &&
            check_obj.GetComponent<cheching>().check_val[diret, 2])
        {
            return;
        }
        if (!check_obj.GetComponent<cheching>().check_val[diret, 1])
        {
            if (!check_obj.GetComponent<cheching>().check_val[diret, 0])
            {
                forward = false;
                player_move_check = true;
                //map_rotate.rotate_cm.player_move = true;
                //.animator.SetBool("down", true);
                animator.SetTrigger("down");
                return;
            }
            else
            {
                forward = false;
                player_move_check = true;
                //map_rotate.rotate_cm.player_move = true;
                //.animator.SetBool("noma", true);
                animator.SetTrigger("noma");
                return;
            }
            //Debug.Log(nomal_check);
        }
        else
        {
            if(!check_obj.GetComponent<cheching>().check_val[4, 2])
            {
                player_move_check = true;
                //map_rotate.rotate_cm.player_move = true;
                //animator.SetBool("up", true);
                animator.SetTrigger("up");
                forward = false;
                return;
            }
            else
            {
                return;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(forward);
        /*
        if(Input.GetKey(KeyCode.Q)){
            Thread.Sleep(5000);
        }*/

        if(change_gravity == true)
        {
            check_obj.GetComponent<cheching>().re_gravity = true;
            //transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            check_obj.GetComponent<cheching>().re_gravity = false;

        }

        if (!telelport1_check && !telelport2_check)
        {
            teleport_rotate_check = true;
        }


        //******* 회전시 텔레포트 해주는 코드 만들어야함
        if ((telelport1_check || telelport2_check) && map_rotate.rotate_cm.rotate_check && teleport_rotate_check && forward)
        {
            this.transform.position = teleport_postion.GetComponent<teleport_point>().point.transform.position;
            teleport_rotate_check = false;
        }

        /*
        if (this.transform.position.y < -5)
        {
            GM.GM_manager.next_stage_move();
        }
        */

        if (!map_rotate.rotate_cm.mouse_move&& map_rotate.rotate_cm.rotate_check && forward && 
            !check_obj.GetComponent<cheching>().check_val[4, 0] && !colid_check && !Input.GetMouseButton(0) 
            && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            if (change_gravity == true)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
                
            animator.SetTrigger("gravity");
            //animator.SetTrigger("gravity");
            player_move_check = true;
            //map_rotate.rotate_cm.player_move = true;
            gravity_ani_finish_check = true;
            forward = false;
        }

        
        if (Input.GetMouseButton(0))
        {
            mouce_time_check = false;
            timer = 0;
        }

        if (!Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                mouce_time_check = true;
                //Action
                timer = 0;
            }
        }


        //Debug.Log(forward);

        if (map_rotate.rotate_cm.rotate_check
            && !gravity_ani_finish_check && forward && mouce_time_check &&
            check_obj.GetComponent<cheching>().check_val[4, 0] &&
            !((Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift))))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                this.transform.position = new Vector3(Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
                if(change_gravity == true)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 180);
                    
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                   
                }
                move((int)Direction.right);
                //Debug.Log("nomal_check");
                /*
                if (!check_obj.GetComponent<cheching>().check_val[(int)Direction.right,1] )
                {
                    if(!check_obj.GetComponent<cheching>().check_val[(int)Direction.right, 0])
                    {
                        animator.SetBool("down", true);
                    }
                    else
                    {
                        animator.SetBool("noma", true);
                        forward = false;
                    }
                    //Debug.Log(nomal_check);
                }
                else
                {
                    animator.SetBool("up", true);
                    forward = false;
                }*/

                //this.transform.position = new Vector3(transform.position.x,
                //   transform.position.y, transform.position.z+1); 
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                this.transform.position = new Vector3(Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));

                if (change_gravity == true)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 180);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                move((int)Direction.left);

                //animator.SetBool("noma", true);
                //forward = false;
                //this.transform.position = new Vector3(transform.position.x,
                //  transform.position.y, transform.position.z - 1);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                this.transform.position = new Vector3(Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
                if (change_gravity == true)
                {
                    transform.localRotation = Quaternion.Euler(0, 270, 180);
                    move((int)Direction.down);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 270, 0);
                    move((int)Direction.up);
                }
                
                //animator.SetBool("noma", true);
                //forward = false;
                //this.transform.position = new Vector3(transform.position.x-1,
                //  transform.position.y, transform.position.z);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                this.transform.position = new Vector3(Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
                if (change_gravity == true)
                {
                    transform.localRotation = Quaternion.Euler(0, 90, 180);
                    move((int)Direction.up);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 90, 0);
                    move((int)Direction.down);
                }
                
                //animator.SetBool("noma", true);
                //forward = false;
                //this.transform.position = new Vector3(transform.position.x+1,
                //  transform.position.y, transform.position.z);

            }
        }
    }

    void finish_gravity_ani()
    {
        //animator.SetBool("gravity", false);
        //시프트 떨어질때는 작동 안되게 만들기코드
        /*
         if(check_obj.GetComponent<cheching>().check_val[4, 0])
        {
            if (check_obj.GetComponent<cheching>().check_val[4, 0] == false)
        {

            map_rotate.rotate_cm.player_move = true;
        }
        else
        {
            map_rotate.rotate_cm.player_move = false;
        }
        }
        
         */
        if (check_obj.GetComponent<cheching>().check_val[4, 0])
        {
            if (check_obj.GetComponent<cheching>().check_val[4, 0] == false)
            {
                player_move_check = true;
                //map_rotate.rotate_cm.player_move = true;
            }
            else
            {
                player_move_check = false;
                //map_rotate.rotate_cm.player_move = false;
            }
        }

        //떨어질떄도 시프트 회전을 가능케 하고 싶을시 이코드 활성화 후 위코드 비활성화
        //map_rotate.rotate_cm.player_move = false;
        gravity_ani_finish_check = false;
        forward = true;
        
        if (telelport1_check || telelport2_check)
        {
            //telelport_check = false;
            this.transform.position = teleport_postion.GetComponent<teleport_point>().point.transform.position;
            this.transform.position = new Vector3(Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        }
    }
    /*
    void finish_noma_ani()
    {
        map_rotate.rotate_cm.player_move = false; 
        animator.SetBool("noma", false);
        forward = true;
        if (telelport_check)
        {
            //telelport_check = false;
            this.transform.position = teleport_postion.GetComponent<teleport_point>().point.transform.position;

        }
    }*/

    void finish_ani()
    {
        Debug.Log("FA");
        forward = true;
        if (telelport1_check || telelport2_check)
        {
            this.transform.position = teleport_postion.GetComponent<teleport_point>().point.transform.position;
        }
        this.transform.position = new Vector3(Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));

        player_move_check = false;
        //map_rotate.rotate_cm.player_move = false;

        //animator.SetBool("up", false);
        //animator.SetBool("down", false);
        //animator.SetBool("noma", false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MAP" ) //  && map_rotate.rotate_cm.rotate_check
        {
            
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            colid_check = true;
        }

        if (other.tag == "tel1" && !telelport2_check && forward && map_rotate.rotate_cm.rotate_check)
        {
            telelport1_check = true;
            telelport2_check = false;
            teleport_postion = other.transform.gameObject;
           //forward = false;
            //colid_check = false;
            //Debug.Log("napo");
            //this.transform.localScale = new Vector3(1, 1, 1);
            //this.GetComponent<MeshRenderer>().material.color = defalt_color.color;
        }
        if (other.tag == "tel2" && !telelport1_check && forward && map_rotate.rotate_cm.rotate_check)
        {
            telelport1_check = false;
            telelport2_check = true;
            teleport_postion = other.transform.gameObject;
        }

        if(other.tag == "ch_gra")
        {
            if (change_gravity_col_check == false && forward == true)
            {
                change_gravity_col_check = true;
                change_gravity = !change_gravity;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        

        colid_check = false;
        this.transform.localScale = new Vector3(1,1,1);
        this.GetComponent<MeshRenderer>().material.color = defalt_color.color;
        if (other.tag == "tel1")
        {
            telelport2_check = false;
        }
        if (other.tag == "tel2")
        {
            telelport1_check = false;
        }
        if(other.tag == "ch_gra")
        {
            change_gravity_col_check = false;
        }

    }

}
