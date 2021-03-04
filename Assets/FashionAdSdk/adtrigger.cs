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
 
            //ť�� ���� �ٲ���
            
 
            rawImage.GetComponent<FashionAd>().ShowAd();


        }
 
    }
 
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "sphere")
        {
            Debug.Log("Trigger!");

            //ť�� ���� �ٲ���

            rawImage.texture = null;
        }
 
    }
}
