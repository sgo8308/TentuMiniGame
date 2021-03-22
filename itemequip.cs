using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum BtnTypeEquip
{
    Buy,
    Sell,       
    Equip,
    UnEquip,
    StorageIn,
    StorageOut
}


public class itemequip : MonoBehaviour
{
    public BtnTypeEquip currentTypeEquip;

     
    public void OnBtnClick()
    {
        switch (currentTypeEquip)
        {
            case BtnTypeEquip.Buy:
                Debug.Log("����");  //����:equip, ��������:unequip,  ����:buy, �Ǹ�:sell â��in: storagein, â��out:storageout

                UserPreferenceCalculate("MINIGAME", "james", "JJJ", "man_knitwear", "buy");

                break;

            case BtnTypeEquip.Sell:
                Debug.Log("�Ǹ�");

                UserPreferenceCalculate("MINIGAME", "james", "JJJ", "man_knitwear", "sell");

                break;

            case BtnTypeEquip.Equip:
                Debug.Log("����");
               
                UserPreferenceCalculate("MINIGAME", "james", "JJJ", "man_knitwear", "equip");

                break;

            case BtnTypeEquip.UnEquip:
                Debug.Log("��������");

                UserPreferenceCalculate("MINIGAME", "james", "JJJ", "man_knitwear", "unequip");

                break;

           

            case BtnTypeEquip.StorageIn:
                Debug.Log("â��ֱ�");

                UserPreferenceCalculate("MINIGAME", "james", "JJJ", "man_knitwear", "storagein");

                break;

            case BtnTypeEquip.StorageOut:
                Debug.Log("â����");

                UserPreferenceCalculate("MINIGAME", "james", "JJJ", "man_knitwear", "storageout");

                break;

        }

    }
    
    
    public void UserPreferenceCalculate(String GameID, String UserId, String ItemID, String Category, String Action)
    {

        StartCoroutine(WebItemEquip(GameID, UserId, ItemID, Category, Action));

    }



    public IEnumerator WebItemEquip(String GameID, String UserId, String ItemID, String Category, String Action)
    {
        WWWForm form = new WWWForm();
        form.AddField("ID", GameID);
        form.AddField("UserId", UserId);
        form.AddField("ItemID", ItemID);
        form.AddField("Category", Category);
        form.AddField("Action", Action);


        using (UnityWebRequest www = UnityWebRequest.Post("http://52.79.143.149/kimtest/ItemPreference_Test.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

}
