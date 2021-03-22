using UnityEngine;

namespace appnext
{
	public class InterstitialConfig : AdConfig
    {

        public string ButtonColor {  get; set; }
        public string CreativeType { get; set; }
        public string SkipText { get; set; }
        public bool AutoPlay { get; set; }
        public bool BackButtonCanClose { get; set; }

        public InterstitialConfig() : base()
        {
			#if UNITY_ANDROID
			AndroidJavaObject instance = new AndroidJavaObject ("com.appnext.ads.interstitial.InterstitialConfig");
			initParamsFromAndroidJavaObject(instance);
			#elif UNITY_IPHONE
			#endif
		}

		#if UNITY_ANDROID

		protected override void initParamsFromAndroidJavaObject(AndroidJavaObject instance)
		{
			base.initParamsFromAndroidJavaObject(instance);
			this.CreativeType = AndroidJNI.CallStringMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "getCreativeType", "()Ljava/lang/String"), new jvalue[0] { });
			this.SkipText = AndroidJNI.CallStringMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "getSkipText", "()Ljava/lang/String"), new jvalue[0] { });
			this.AutoPlay = AndroidJNI.CallBooleanMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "isAutoPlay", "()Z"), new jvalue[0] { });
            this.ButtonColor = AndroidJNI.CallStringMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "getButtonColor", "()Ljava/lang/String"), new jvalue[0] { });
            this.BackButtonCanClose = AndroidJNI.CallBooleanMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "isBackButtonCanClose", "()Z"), new jvalue[0] { });

        }

#elif UNITY_IPHONE

		protected override void initConfig()
		{
			base.initConfig ();
            CreativeType = AppnextIOSSDKBridge.getConfigDefaultString(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_CREATIVE_TYPE);
		    SkipText = AppnextIOSSDKBridge.getConfigDefaultString(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_SKIP_TEXT);
		    AutoPlay = AppnextIOSSDKBridge.getConfigDefaultBool(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_AUTO_PLAY);
		}

#endif


    }
}
