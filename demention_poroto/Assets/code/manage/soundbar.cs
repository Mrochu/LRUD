using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundbar : MonoBehaviour
{
    public Sprite offimg;
    public Sprite onimg;

    bool state = true;
    public void sound_img_onoff()
    {
        if (state) 
        {
            this.gameObject.GetComponent<Image>().sprite = onimg;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = offimg;
        }
        state = !state;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
