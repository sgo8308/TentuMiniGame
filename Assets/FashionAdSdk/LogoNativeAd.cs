using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
using Tentuplay.FashionAd;
public class LogoNativeAd : MonoBehaviour
{
    static string clientId; // 클라이언트(게임사) 아이디 세팅하기 
    static string userId = "james"; // 유저 아이디 갖고오기
    GameObject goToBuyButton;
    GameObject titleText;
    GameObject descText;

    private void Update()
    {
        goToBuyButton = this.transform.root.Find("GoToBuyButton").gameObject;
        titleText = this.transform.root.Find("Title").gameObject;
        descText = this.transform.root.Find("Desc").gameObject;

        if (goToBuyButton.activeSelf)
        {
            titleText.SetActive(true);
            descText.SetActive(true);
        }
        else
        {
            titleText.SetActive(false);
            descText.SetActive(false);
        }
    }

    public FashionAdApi.NativeAdData panelAdData;

    public void ShowAd()
    {
        string url = "";
        if (Persona.persona == "communication")
        {
            url = "https://global.appnext.com/offerWallApi.aspx?tid=API&did=03382e13-716f-47c0-8b40-10ca1ad1abe1&id=99dd343b-c93a-418f-b393-19f968a387f3&ip=92.38.148.61&lockcat=Social&uagent=Dalvik%2f2.1.0+(Linux%3b+U%3b+Android+9%3b+Redmi+Note+7+Pro+MIUI%2fV10.3.9.0.PFHINXM)";
        }
        else if (Persona.persona == "fashionItemPrefer")
        {
            url = "https://global.appnext.com/offerWallApi.aspx?tid=API&did=03382e13-716f-47c0-8b40-10ca1ad1abe1&id=99dd343b-c93a-418f-b393-19f968a387f3&ip=92.38.148.61&lockcat=Shopping&uagent=Dalvik%2f2.1.0+(Linux%3b+U%3b+Android+9%3b+Redmi+Note+7+Pro+MIUI%2fV10.3.9.0.PFHINXM)";
        }
        else if(Persona.persona == "tracker")
        {
            url = "https://global.appnext.com/offerWallApi.aspx?tid=API&did=03382e13-716f-47c0-8b40-10ca1ad1abe1&id=99dd343b-c93a-418f-b393-19f968a387f3&ip=92.38.148.61&lockcat=Travel&uagent=Dalvik%2f2.1.0+(Linux%3b+U%3b+Android+9%3b+Redmi+Note+7+Pro+MIUI%2fV10.3.9.0.PFHINXM)";
        }
        else
        {
            url = "https://global.appnext.com/offerWallApi.aspx?tid=API&did=03382e13-716f-47c0-8b40-10ca1ad1abe1&id=99dd343b-c93a-418f-b393-19f968a387f3&ip=92.38.148.61&lockcat=Sports&uagent=Dalvik%2f2.1.0+(Linux%3b+U%3b+Android+9%3b+Redmi+Note+7+Pro+MIUI%2fV10.3.9.0.PFHINXM)";
        }

        StartCoroutine(ShowAdChain(url ,userId, (x) => panelAdData = x)); ;
    }

    /*광고 정보를 받아온 후에 광고판의 이미지를 변경시키기 위해 IEnumerator를 사용*/
    IEnumerator ShowAdChain(string url,string userId, System.Action<FashionAdApi.NativeAdData> var)
    {
        FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
        yield return StartCoroutine(fApi.sendSetImageAdData(url ,userId, var));//먼저 광고 정보를 갖고온다
        StartCoroutine(fApi.sendShowAd(panelAdData.apps[0].urlImg, "logo"));//광고 정보 갖고오면 이미지url넣어서 보여준다.
        this.transform.root.Find("Title").GetComponent<Text>().text = panelAdData.apps[0].title;
        this.transform.root.Find("Desc").GetComponent<Text>().text = panelAdData.apps[0].desc;

        Debug.Log("urlImg는 : " + panelAdData.apps[0].urlImg);
    }


    /*광고판 광고에서 구매하러 가기 클릭시 연결된 URL로 이동*/
    public void GoPanelAdSite()
    {
        FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
        if (panelAdData.apps[0].urlApp != null)
        {
            string url = panelAdData.apps[0].urlApp;
            Application.OpenURL(url);
        }
    }
}
