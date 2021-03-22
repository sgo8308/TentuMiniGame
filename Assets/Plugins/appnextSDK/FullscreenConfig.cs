using UnityEngine;

namespace appnext
{
	public class FullscreenConfig : VideoConfig
    {
        public bool BackButtonCanClose { get; set; }
        public bool ShowClose { get; set; }
        public long Delay { get; set; }

        public FullscreenConfig() : base()
        {
			#if UNITY_ANDROID
			AndroidJavaObject instance = new AndroidJavaObject ("com.appnext.ads.fullscreen.FullscreenConfig");
			initParamsFromAndroidJavaObject(instance);
       
            #elif UNITY_IPHONE
            #endif
        }

    
        #if UNITY_ANDROID
        protected override void initParamsFromAndroidJavaObject(AndroidJavaObject instance)
        {
            
            base.initParamsFromAndroidJavaObject(instance);
            Delay = 100;
            ShowClose = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isShowClose", "()Z"), new jvalue[0] { });
            BackButtonCanClose = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isBackButtonCanClose", "()Z"), new jvalue[0] { });
        }
        #elif UNITY_IPHONE
        #endif
    }

}
