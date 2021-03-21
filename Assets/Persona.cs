using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Persona : MonoBehaviour
{
    public Dropdown dropdown;
    public Text null_persona;
    public Text comuication_persona;
    public Text ddarajenge_persona;


    public void EventListening()
    {
        switch (dropdown.value)
        {
            case 0:
                Debug.Log(0);
                null_persona.gameObject.SetActive(true);
                comuication_persona.gameObject.SetActive(false);
                ddarajenge_persona.gameObject.SetActive(false);
                break;
            case 1:
                Debug.Log(1);
                null_persona.gameObject.SetActive(false);
                comuication_persona.gameObject.SetActive(true);
                ddarajenge_persona.gameObject.SetActive(false);
                break;
            case 2:
                Debug.Log(2);
                null_persona.gameObject.SetActive(false);
                comuication_persona.gameObject.SetActive(false);
                ddarajenge_persona.gameObject.SetActive(true);
                break;
            default:
                Debug.Log(0);
                null_persona.gameObject.SetActive(true);
                comuication_persona.gameObject.SetActive(false);
                ddarajenge_persona.gameObject.SetActive(false);
                break;
        }
    }
}
