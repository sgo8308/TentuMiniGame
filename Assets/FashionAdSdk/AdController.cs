using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
using Tentuplay.FashionAdApi;
public class AdController : MonoBehaviour
{
    static string clientId; // 클라이언트(게임사) 아이디 세팅하기 
    static string userId = "james"; // 유저 아이디 갖고오기

    string adId;
    FashionAd.AdData adData;

    public Button BuyButton;
    public FashionAd.PanelShape panelShape;
    public RawImage rawimage;

    public void ShowAd()
    {
        FashionAd fd = gameObject.AddComponent<FashionAd>();
        StartCoroutine(fd.SendShowAd2(userId, panelShape, adData, rawimage));
    }

    public void GoToWebSite()
    {
        if (adData.productUrl != null)
        {
            string url = adData.productUrl;
            Application.OpenURL(url);
        }
    }



    public int ttt;
    public void Test(out int num)
    {
        num = 11;
    }

    public void test2()
    {
        Test(out ttt);
        Debug.Log("테스트 결과는" + ttt);
    }

    private void Start()
    {
        test2();
    }

}
