using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace appnext
{
    public class Banner : MonoBehaviour, IDisposable
    {

        private static int gameObjectCount = 0;
        protected GameObject bannerGameObject;
        protected static WeakDictionary<string, Banner> gameObjectNameToAdDictionary = new WeakDictionary<string, Banner>();

        public delegate void OnBannerLoadedDelegate(Banner banner);
        public event OnBannerLoadedDelegate onBannerLoadedDelegate;

        public delegate void OnBannerErrorDelegate(Banner banner, string error);
        public event OnBannerErrorDelegate onBannerErrorDelegate;

        public delegate void OnBannerClickedDelegate(Banner banner);
        public event OnBannerClickedDelegate onBannerClickedDelegate;

        public delegate void OnBannerImpressionReportedDelegate(Banner banner);
        public event OnBannerImpressionReportedDelegate onBannerImpressionReportedDelegate;

        #if UNITY_ANDROID
               protected AndroidJavaObject instance;
        #elif UNITY_IPHONE
            string adKey;
        #endif

        public Banner(string placement)
        {
            createInstance(placement);
            createGameObject();
            registerBannerGameObjectForEvents();
        }

        private void createInstance( string placementID)
        {
             #if UNITY_ANDROID
                using (var pluginClass = new AndroidJavaClass("com.appnext.unityplugin.AdBuilder"))
                    instance = pluginClass.CallStatic<AndroidJavaObject>("getBanner", placementID);
                Debug.Log("createInstance");
            #elif UNITY_IPHONE
                    adKey = AppnextIOSSDKBridge.createBanner(placementID);
            #endif
        }
        
        public void loadAd(BannerAdRequest adRequest)
        {
            if(adRequest == null) {
                adRequest = new BannerAdRequest();
            }
            #if UNITY_ANDROID
                 instance.Call("loadAd", adRequest.ToJSON());
            #elif UNITY_IPHONE      
                AppnextIOSSDKBridge.loadBanner(adKey, adRequest.ToJSON());
            #endif
        }

        private void createGameObject()
        {
            string gameObjectName = Banner.CreateAdGameObjectName();
            bannerGameObject = new GameObject(gameObjectName);
            GameObject.DontDestroyOnLoad(bannerGameObject);
            bannerGameObject.AddComponent(GetType());
            Banner.gameObjectNameToAdDictionary.Put(bannerGameObject.name, this);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static string CreateAdGameObjectName()
        {
            string gameObjectName = "AppnextUnityBannerGameObject_" + gameObjectCount.ToString();
            gameObjectCount++;
            return gameObjectName;
        }

        private void registerBannerGameObjectForEvents()
        {
            setOnBannerLoadedCallback(bannerGameObject.transform.name, "OnBannerLoadedCallback");
            setOnBannerErrorCallback(bannerGameObject.transform.name, "OnBannerErrorCallback");
            setOnBannerdClickedCallback(bannerGameObject.transform.name, "OnBannerdClickedCallback");
            setOnBannerImpressionReportedCallback(bannerGameObject.transform.name, "OnBannerImpressionReportedCallback");

        }


        private void setOnBannerLoadedCallback(string gameObject, string method)
        {
            #if UNITY_ANDROID
                instance.Call("setOnAdLoadedCallback", gameObject, method);
            #elif UNITY_IPHONE
                AppnextIOSSDKBridge.setOnBannerLoadedCallback(adKey, gameObject, method);
            #endif
        }

        private void setOnBannerErrorCallback(string gameObject, string method)
        {
            #if UNITY_ANDROID
               instance.Call("setOnAdErrorCallback", gameObject, method);
            #elif UNITY_IPHONE
                AppnextIOSSDKBridge.setOnBannerErrorCallback(adKey, gameObject, method);
            #endif
        }



        private void setOnBannerdClickedCallback(string gameObject, string method)
        {   
            #if UNITY_ANDROID
               instance.Call("setOnAdClickedCallback", gameObject, method);
            #elif UNITY_IPHONE
                AppnextIOSSDKBridge.setOnBannerClickedCallback(adKey, gameObject, method);
            #endif
        }

        private void setOnBannerImpressionReportedCallback(string gameObject, string method)
        {
            #if UNITY_ANDROID
                instance.Call("setOnAdImpressionReportedCallback", gameObject, method);
            #elif UNITY_IPHONE
                AppnextIOSSDKBridge.setOnBannerImpressionReportedCallback(adKey, gameObject, method);
            #endif
        }

        //callbacks 

        private void OnBannerLoadedCallback(string message)
        {
            Banner thisBanner;
            bool success = Banner.gameObjectNameToAdDictionary.TryGetValue(this.name, out thisBanner);
            if (success)
            {
                if (thisBanner.onBannerLoadedDelegate != null)
                {
                    thisBanner.onBannerLoadedDelegate(thisBanner);
                }
            }
        }

        private void OnBannerErrorCallback(string error)
        {
            Banner thisBanner;
            bool success = Banner.gameObjectNameToAdDictionary.TryGetValue(this.name, out thisBanner);
            if (success)
            {
                if (thisBanner.onBannerErrorDelegate != null)
                {
                    thisBanner.onBannerErrorDelegate(thisBanner, error);
                }
            }
        }

        private void OnBannerdClickedCallback(string message)
        {
            Banner thisBanner;
            bool success = Banner.gameObjectNameToAdDictionary.TryGetValue(this.name, out thisBanner);
            if (success)
            {
                if (thisBanner.onBannerClickedDelegate != null)
                {
                    thisBanner.onBannerClickedDelegate(thisBanner);
                }
            }
        }

        private void OnBannerImpressionReportedCallback(string message)
        {
            Banner thisBanner;
            bool success = Banner.gameObjectNameToAdDictionary.TryGetValue(this.name, out thisBanner);
            if (success)
            {
                if (thisBanner.onBannerImpressionReportedDelegate != null)
                {
                    thisBanner.onBannerImpressionReportedDelegate(thisBanner);
                }
            }
        }


        public void destroy()
        {
            #if UNITY_ANDROID
			     instance.Call("destroy");
			#elif UNITY_IPHONE
			    AppnextIOSSDKBridge.disposeBanner(adKey);
			#endif
        }

        public void Dispose()
        {
            destroy();
            //throw new NotImplementedException();// call banner onDestroy
        }
    }
}
