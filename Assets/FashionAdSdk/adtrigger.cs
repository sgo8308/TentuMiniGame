using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adtrigger : MonoBehaviour
{
   public GameObject cube;
    public RawImage rawImage;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "sphere")
        {
            Debug.Log("Trigger!");
 
            //Å¥ºê »ö±ò ¹Ù²î¾î¶ó
            
 
            rawImage.GetComponent<FashionAd>().ShowAd();


        }
 
    }
 
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "sphere")
        {
            Debug.Log("Trigger!");

            //Å¥ºê »ö±ò ¹Ù²î¾î¶ó

            rawImage.texture = null;
        }
 
    }
}
