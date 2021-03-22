using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
using Tentuplay.FashionAd;
public class FashionAd : MonoBehaviour
{
    static string clientId; // 클라이언트(게임사) 아이디 세팅하기 
    static string userId = "james"; // 유저 아이디 갖고오기

    //public FashionAdApi.AdData panelAdData;
    //public FashionAdApi.AdData popUpAdData;

    //public Button BuyButton; // 광고판 광고 구매하러 가기 버튼
    //public FashionAdApi.PanelShape panelShape;

    /*광고판에 광고를 보여주는 메소드*/
    //public void ShowAd()
    //{
    //    StartCoroutine(ShowAdChain(userId, panelShape, (x) => panelAdData = x ) ); ;
    //}

    ///*광고 정보를 받아온 후에 광고판의 이미지를 변경시키기 위해 IEnumerator를 사용*/
    //IEnumerator ShowAdChain(string userId, FashionAdApi.PanelShape panelShape, System.Action<FashionAdApi.AdData> var)// 이 부분에서 ADIMPRESSION 할 때 adData 밖으로 빼야 함 api로 메소드들 다 밖으로 뺀다면
    //{
    //    FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
    //    yield return StartCoroutine(fApi.sendSetImageAdData(userId, panelShape, var));//먼저 광고 정보를 갖고온다
    //    StartCoroutine(fApi.sendShowAd(panelAdData.adSourceUrl));//광고 정보 갖고오면 이미지url넣어서 보여준다.
    //    fApi.AdImpression(userId, panelAdData.adId, panelAdData.ownerId);
    //}

    ///*광고판에 광고 클릭 후 돌아왔을 때 어울리는 옷 팝업광고 보여주기*/
    //public void ShowPopUpAd()
    //{
    //    StartCoroutine(ShowPopUpAdChain());
    //}

    //IEnumerator ShowPopUpAdChain()
    //{
    //    FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();

    //    yield return StartCoroutine(fApi.SetPopUpAdData(userId, panelAdData.adId, (x) => popUpAdData = x));
    //    StartCoroutine(fApi.ShowPopUpAd(popUpAdData.adSourceUrl, popUpAdData, GoPopUpAdSite));
    //    fApi.AdImpression(userId, popUpAdData.adId, popUpAdData.ownerId);
    //}

    ///*광고판 광고에서 구매하러 가기 클릭시 연결된 URL로 이동*/
    //public void GoPanelAdSite()
    //{
    //    FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
    //    if (panelAdData.productUrl != null)
    //    {
    //        string url = panelAdData.productUrl;
    //        Application.OpenURL(url);
    //        fApi.AdClick(userId, panelAdData.adId, panelAdData.ownerId);
    //    }
    //}

    ///*팝업 광고에서 구매하러 가기 클릭시 연결된 URL로 이동*/
    //public void GoPopUpAdSite()
    //{
    //    FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
    //    if (popUpAdData.productUrl != null)
    //    {
    //        string url = popUpAdData.productUrl;
    //        Application.OpenURL(url);
    //        fApi.AdClick(userId, popUpAdData.adId, popUpAdData.ownerId);
    //    }
    //}


    //-------------------------여기부터는 AppNext 전용----------------------------

    public FashionAdApi.NativeAdData panelAdData;

    public void ShowAd()
    {
        string url = "https://global.appnext.com/offerWallApi.aspx?tid=API&did=03382e13-716f-47c0-8b40-10ca1ad1abe1&id=99dd343b-c93a-418f-b393-19f968a387f3&ip=92.38.148.61&cnt=100&lockcat=Social&uagent=Dalvik%2f2.1.0+(Linux%3b+U%3b+Android+9%3b+Redmi+Note+7+Pro+MIUI%2fV10.3.9.0.PFHINXM)";

        StartCoroutine(ShowAdChain(url ,userId, (x) => panelAdData = x)); ;
    }

    /*광고 정보를 받아온 후에 광고판의 이미지를 변경시키기 위해 IEnumerator를 사용*/
    IEnumerator ShowAdChain(string url,string userId, System.Action<FashionAdApi.NativeAdData> var)
    {
        FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
        yield return StartCoroutine(fApi.sendSetImageAdData(url ,userId, var));//먼저 광고 정보를 갖고온다
        StartCoroutine(fApi.sendShowAd(panelAdData.apps[0].urlImgWide, "panel"));//광고 정보 갖고오면 이미지url넣어서 보여준다.
        Debug.Log("urlImgWide는 : " + panelAdData.apps[0].urlImgWide);
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

    //RawImage adPanel;
    //Button goToBuyButton;
    //private bool isUserInTrigArea;
    //private Queue<string> queue = new Queue<string>(); // 5초 지나고 올 메시지 담을 큐
    //private int trigNum; // 몇번째 트리거 안에 들어왔는지
    //private bool isAdPanelSet = false; //광고판에 광고가 세팅되어있는지 아닌지

    //public void OnAdTrigger()
    //{
    //    trigNum++;
    //    Debug.Log("Trigger!");

    //    if (!isAdPanelSet)
    //    {
    //        this.transform.GetComponent<RawImage>
    //        Transform adPanelTF = col.transform.root.Find("RawImage");
    //        adPanel = adPanelTF.GetComponent<RawImage>();
    //        FashionAd fd = adPanelTF.GetComponent<FashionAd>();
    //        fd.ShowAd();
    //        goToBuyButton = col.transform.root.Find("GoToBuyButton").GetComponent<Button>();
    //        goToBuyButton.gameObject.SetActive(true);
    //    }

    //    isUserInTrigArea = true;
    //    isAdPanelSet = true;
    //}
}
