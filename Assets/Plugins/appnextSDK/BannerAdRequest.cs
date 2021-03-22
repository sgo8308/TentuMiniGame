using System;
using UnityEngine;

namespace appnext
{

    public class BannerAdRequest : MonoBehaviour
    {
        [SerializeField]
        public String Postback;

        [SerializeField]
        public String Categories;

        [SerializeField]
        public String Position = "buttom";

        public BannerAdRequest() 
        {
#if UNITY_ANDROID
            AndroidJavaObject instance = new AndroidJavaObject("com.appnext.banners.BannerAdRequest");
            initParamsFromAndroidJavaObject(instance);
#elif UNITY_IPHONE
#endif
        }

#if UNITY_ANDROID

        protected virtual void initParamsFromAndroidJavaObject(AndroidJavaObject instance)
        {
            Categories = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getCategories", "()Ljava/lang/String"), new jvalue[0] { });
            Postback = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getPostback", "()Ljava/lang/String"), new jvalue[0] { });            
        }

#elif UNITY_IPHONE


#endif

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }

    }
}
