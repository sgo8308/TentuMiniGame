using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PptControl : MonoBehaviour
{
    public Image ppt;
    public List<Sprite> pptpage = new List<Sprite>();
    int i = 0;


    void Start()
    {
        ppt.sprite = pptpage[i];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (i <= 0)
            {
                return;
            }
            else {
                i -= 1;
                ppt.sprite = pptpage[i];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
             if (i >= 12)
             {
                 return;
             }
             else
             {
                 i += 1;
                 ppt.sprite = pptpage[i];
             }
        }
    }
}