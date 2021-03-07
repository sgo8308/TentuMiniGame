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

    string adId;
    public FashionAdApi.AdData panelAdData;
    public FashionAdApi.AdData popUpAdData;

    public Button BuyButton;
    public FashionAdApi.PanelShape panelShape;

    public void ShowAd()
    {
        StartCoroutine(ShowAdChain(userId, panelShape, (x) => panelAdData = x ) ); ;
    }

    IEnumerator ShowAdChain(string userId, FashionAdApi.PanelShape panelShape, System.Action<FashionAdApi.AdData> var)// 이 부분에서 ADIMPRESSION 할 때 adData 밖으로 빼야 함 api로 메소드들 다 밖으로 뺀다면
    {
        FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
        yield return StartCoroutine(fApi.sendSetImageAdData(userId, panelShape, var));//먼저 광고 정보를 갖고온다
        StartCoroutine(fApi.sendShowAd(panelAdData.adSourceUrl));//광고 정보 갖고오면 이미지url넣어서 보여준다.
        fApi.AdImpression(userId, panelAdData.adId, panelAdData.ownerId);
    }

    /*
     광고판에 광고 클릭 후 돌아왔을 때 어울리는 옷 팝업광고 보여주기
     */
    public void ShowPopUpAd()
    {
        StartCoroutine(ShowPopUpAdChain());
    }

    IEnumerator ShowPopUpAdChain()
    {
        FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();

        yield return StartCoroutine(fApi.SetPopUpAdData(userId, "2", (x) => popUpAdData = x));
        StartCoroutine(fApi.ShowPopUpAd(popUpAdData.adSourceUrl, popUpAdData, GoPopUpAdSite));
        fApi.AdImpression(userId, popUpAdData.adId, popUpAdData.ownerId);
    }


    public void GoPanelAdSite()
    {
        FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
        if (panelAdData.productUrl != null)
        {
            string url = panelAdData.productUrl;
            Application.OpenURL(url);
            fApi.AdClick(userId, panelAdData.adId, panelAdData.ownerId);
        }
    }

    public void GoPopUpAdSite()
    {
        FashionAdApi fApi = gameObject.AddComponent<FashionAdApi>();
        if (popUpAdData.productUrl != null)
        {
            string url = popUpAdData.productUrl;
            Application.OpenURL(url);
            fApi.AdClick(userId, popUpAdData.adId, popUpAdData.ownerId);
        }
    }


}
