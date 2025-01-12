using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_count : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "player_obj" && map_rotate.rotate_cm.rotate_check == true)
        {
            GM.GM_manager.count_act_point++;
            GM.GM_manager.point_check();
            this.gameObject.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "player_obj" && map_rotate.rotate_cm.rotate_check == true 
            && !((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))))
        {

            GM.GM_manager.count_act_point++;
            GM.GM_manager.point_check();
            this.gameObject.SetActive(false);
        }
    }

}
