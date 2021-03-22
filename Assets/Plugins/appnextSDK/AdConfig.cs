using UnityEngine;

namespace appnext
{
	public abstract class AdConfig
	{

        public string Categories { get; set; }
        public string Postback { get; set; }
        public string Orientation { get; set; }
        public bool Mute { get; set; }


        public AdConfig()
		{
			#if UNITY_ANDROID
			#elif UNITY_IPHONE
			initConfig();
			#endif
		}

		#if UNITY_ANDROID

		protected virtual void initParamsFromAndroidJavaObject(AndroidJavaObject instance)
		{
			Categories = AndroidJNI.CallStringMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "getCategories", "()Ljava/lang/String"), new jvalue[0] { });
			Postback = AndroidJNI.CallStringMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "getPostback", "()Ljava/lang/String"), new jvalue[0] { });
			Orientation = AndroidJNI.CallStringMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "getOrientation", "()Ljava/lang/String"), new jvalue[0] { });
			Mute = AndroidJNI.CallBooleanMethod (instance.GetRawObject (), AndroidJNIHelper.GetMethodID (instance.GetRawClass (), "getMute", "()Z"), new jvalue[0] { });
		}

		#elif UNITY_IPHONE

		protected virtual void initConfig()
		{
	
            Categories = AppnextIOSSDKBridge.getConfigDefaultString(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_CATEGORIES);
            Postback = AppnextIOSSDKBridge.getConfigDefaultString(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_POSTBACK);
            Orientation = AppnextIOSSDKBridge.getConfigDefaultString(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_ORIENTATION);
            Mute = AppnextIOSSDKBridge.getConfigDefaultBool(AppnextIOSSDKBridge.AD_CONFIG_DEFAULT_MUTE);
		}

		#endif

	
	}
}
