using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adtrigger : MonoBehaviour
{
   public GameObject cube;


    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "sphere")
        {
            Debug.Log("Trigger!");
 
            //ť�� ���� �ٲ���
            
 
              cube.GetComponent<Renderer>().material.color = Color.red;
        }
 
    }
 
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "sphere")
        {
            Debug.Log("Trigger!");
 
            //ť�� ���� �ٲ���
 
 
            cube.GetComponent<Renderer>().material.color = Color.yellow;
        }
 
    }
}
