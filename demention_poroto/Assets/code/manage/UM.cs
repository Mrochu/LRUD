using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UM : MonoBehaviour
{
    public GameObject axix;

    bool axix_state = true;
    bool sound_state = true;

    public void reatart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void sound_onoff()
    {
        sound_state = !sound_state;
    }

    public void exit_Stage()
    {
        GM.GM_manager.scene_exit();
    }

    public void axix_onoff()
    {
        if (axix_state)
        {
            axix.gameObject.SetActive(false);
        }
        else
        {
            axix.gameObject.SetActive(true);
        }
        axix_state = !axix_state;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            axix_onoff();
        }
    }
}
