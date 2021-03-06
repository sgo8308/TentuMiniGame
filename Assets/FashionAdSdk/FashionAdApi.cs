//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Newtonsoft.Json;
//using UnityEngine.Networking;

//namespace Tentuplay.FashionAd
//{
//    public class FashionAdApi : MonoBehaviour
//    {
//        public IEnumerator SendShowAd2(string userId, PanelShape panelShape)// 이 부분에서 ADIMPRESSION 할 때 adData 밖으로 빼야 함 api로 메소드들 다 밖으로 뺀다면
//        {
//            yield return StartCoroutine(sendSetImageAdData(userId, panelShape));//먼저 광고 정보를 갖고온다
//            StartCoroutine(sendShowAd(adData.adSourceUrl));//광고 정보 갖고오면 이미지url넣어서 보여준다.
//            AdImpression(userId, adData.adId);
//        }

//        IEnumerator sendShowAd(string url)
//        {
//            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
//            yield return www.SendWebRequest();

//            if (www.isNetworkError || www.isHttpError)
//            {
//                Debug.Log(www.error);
//            }
//            else
//            {
//                this.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
//            }
//        }

//        public void AdClick(string userId, string adId)
//        {
//            StartCoroutine(sendAdClick(userId, adId));
//        }
//        public void AdImpression(string userId, string adId)
//        {
//            StartCoroutine(sendAdImpression(userId, adId));
//        }
//        //보조 메소드
//        private IEnumerator sendAdClick(string userId, string adId)
//        {
//            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
//            formData.Add(new MultipartFormDataSection("adId", adId));
//            formData.Add(new MultipartFormDataSection("userId", userId));
//            formData.Add(new MultipartFormDataSection("type", "adClick"));
//            formData.Add(new MultipartFormDataSection("clientId", "clientId"));

//            UnityWebRequest www = UnityWebRequest.Post("http://52.79.143.149/DataProcessing/putAdData.php", formData);
//            yield return www.SendWebRequest();

//            if (www.isNetworkError || www.isHttpError)
//            {
//                Debug.Log(www.error);
//            }
//            else
//            {
//                Debug.Log("Form upload complete!");
//                Debug.Log(www.downloadHandler.text);
//            }
//        }
//        private IEnumerator sendAdImpression(string userId, string adId)
//        {
//            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
//            formData.Add(new MultipartFormDataSection("adId", adId));
//            formData.Add(new MultipartFormDataSection("userId", userId));
//            formData.Add(new MultipartFormDataSection("type", "adImpression"));
//            formData.Add(new MultipartFormDataSection("clientId", "clientId"));

//            UnityWebRequest www = UnityWebRequest.Post("http://52.79.143.149/DataProcessing/putAdData.php", formData);
//            yield return www.SendWebRequest();

//            if (www.isNetworkError || www.isHttpError)
//            {
//                Debug.Log(www.error);
//            }
//            else
//            {
//                Debug.Log("Form upload complete!");
//            }
//        }
//        private IEnumerator sendSetImageAdData(string userId, PanelShape adPanelShape)
//        {
//            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
//            formData.Add(new MultipartFormDataSection("userId", userId));
//            formData.Add(new MultipartFormDataSection("adPanelShape", adPanelShape.ToString()));
//            formData.Add(new MultipartFormDataSection("clientId", "clientId"));

//            UnityWebRequest www = UnityWebRequest.Post("http://52.79.143.149/DataProcessing/getAdData.php", formData);
//            yield return www.SendWebRequest();

//            if (www.isNetworkError || www.isHttpError)
//            {
//                Debug.Log(www.error);
//            }
//            else
//            {
//                Debug.Log("Form upload complete!");
//                string data = www.downloadHandler.text;
//                Debug.Log(data);
//                adData = JsonConvert.DeserializeObject<AdData>(data);
//            }
//        }

//        //보조 enum ,calss
//        public class AdData
//        {
//            public string adId;
//            public string adSourceUrl;
//            public string productUrl;
//        }
//        public enum Category
//        {
//            man_knit,
//            man_tShirts,
//            man_shirts,
//            man_cardigan,
//            man_jumper,
//            man_jacket,
//            man_coat,
//            man_blueJean,
//            man_pants,
//            man_sweatPants,
//            man_sweatShirts,
//            man_sneakers,
//            man_boots,
//            man_slipper,
//            man_moccasin,
//            man_sportsShoes,
//            man_worker,
//            man_dressShoes,
//            woman_knit,
//            woman_cardigan,
//            woman_onePiece,
//            woman_tShirts,
//            woman_blouse,
//            woman_jumper,
//            woman_jacket,
//            woman_coat,
//            woman_blueJean,
//            woman_skirt,
//            woman_leggings,
//            woman_pants,
//            woman_sweatPants,
//            woman_sweatShirts,
//            woman_boots,
//            woman_worker,
//            woman_heel,
//            woman_sportsShoes,
//            woman_flatShoes,
//            woman_bootie,
//            woman_sneakers,
//        }
//        public enum PanelShape
//        {
//            img11,
//            img43,
//            img34
//        }
//    }
//}


