using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class adtrigger : MonoBehaviour
{
    public RawImage rawImage;
    public Button goToBuyButton;
    string userId = "james";

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "sphere")
        {
            Debug.Log("Trigger!");
            FashionAd fd = rawImage.GetComponent<FashionAd>();
            fd.ShowAd();
            goToBuyButton.gameObject.SetActive(true);
        }
 
    }
 
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "sphere")
        {
            Debug.Log("Trigger!");
            rawImage.texture = null;
            goToBuyButton.gameObject.SetActive(false);
        }

    }
}
